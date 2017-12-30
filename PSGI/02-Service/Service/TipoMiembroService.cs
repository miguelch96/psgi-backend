using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model.Domain.Estatico;
using NLog;
using Persistence.DbContextScope;
using Persistence.Repository;

namespace Service
{
    public interface ITipoMiembroService
    {
        IEnumerable<TipoMiembro> GetAll();
    }

    class TipoMiembroService : ITipoMiembroService
    {
        private static ILogger logger = LogManager.GetCurrentClassLogger();
        private readonly IDbContextScopeFactory _dbContextScopeFactory;
        private readonly IRepository<TipoMiembro> _tipoMiembroRepository;

        public TipoMiembroService(IDbContextScopeFactory dbContextScopeFactory, IRepository<TipoMiembro> tipoMiembroRepository)
        {
            _dbContextScopeFactory = dbContextScopeFactory;
            _tipoMiembroRepository = tipoMiembroRepository;
        }


        public IEnumerable<TipoMiembro> GetAll()
        {
            var result = new List<TipoMiembro>();

            try
            {
                using (var ctx = _dbContextScopeFactory.CreateReadOnly())
                {
                    result = _tipoMiembroRepository.GetAll().ToList();
                }
            }
            catch (Exception e)
            {
                logger.Error(e.Message);
            }

            return result;
        }
    }
   
}
