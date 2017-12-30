using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Common;
using Model.Domain;
using NLog;
using Persistence.DbContextScope;
using Persistence.Repository;

namespace Service
{
    public interface IMiembroService
    {
        IEnumerable<Miembro> GetAll();
        Miembro Get(int id);
        ResponseHelper InsertOrUpdate(Miembro model);
        ResponseHelper Delete(int id);
    }
    public class MiembroService : IMiembroService
    {
        private static ILogger logger = LogManager.GetCurrentClassLogger();
        private readonly IDbContextScopeFactory _dbContextScopeFactory;
        private readonly IRepository<Miembro> _miembroRepository;

        public MiembroService(
            IDbContextScopeFactory dbContextScopeFactory,
            IRepository<Miembro> miembroRepository
            )
        {
            _dbContextScopeFactory = dbContextScopeFactory;
            _miembroRepository = miembroRepository;
        }
        public IEnumerable<Miembro> GetAll()
        {
            var result = new List<Miembro>();

            try
            {
                using (var ctx = _dbContextScopeFactory.CreateReadOnly())
                {
                    result = _miembroRepository.GetAll().ToList();
                }
            }
            catch (Exception e)
            {
                logger.Error(e.Message);
            }

            return result;
        }

        public Miembro Get(int id)
        {
            var result = new Miembro();

            try
            {
                using (var ctx = _dbContextScopeFactory.Create())
                {
                    result = _miembroRepository.SingleOrDefault(x => x.MiembroId == id);
                }
            }
            catch (Exception e)
            {
                logger.Error(e.Message);
            }

            return result;
        }

        public ResponseHelper InsertOrUpdate(Miembro model)
        {
            var rh = new ResponseHelper();

            try
            {
                using (var ctx = _dbContextScopeFactory.Create())
                {
                    if (model.MiembroId == 0)
                    {
                        _miembroRepository.Insert(model);
                    }
                    else
                    {
                        _miembroRepository.Update(model);
                    }

                    ctx.SaveChanges();
                    rh.SetResponse(true);
                }
            }
            catch (Exception e)
            {
                logger.Error(e.Message);
            }

            return rh;
        }

        public ResponseHelper Delete(int id)
        {
            var rh = new ResponseHelper();

            try
            {
                using (var ctx = _dbContextScopeFactory.Create())
                {
                    var model = _miembroRepository.SingleOrDefault(x => x.MiembroId == id);
                    _miembroRepository.Delete(model);

                    ctx.SaveChanges();
                    rh.SetResponse(true);
                }
            }
            catch (Exception e)
            {
                logger.Error(e.Message);
            }

            return rh;
        }
    }
}
