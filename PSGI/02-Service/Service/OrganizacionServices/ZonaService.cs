using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model.Domain.Organizacion;
using NLog;
using Persistence.DbContextScope;
using Persistence.Repository;

namespace Service.OrganizacionServices
{
    public interface IZonaService
    {
        IEnumerable<Zona> GetAll();
        IEnumerable<Zona> GetByArea(int areaId);
    }

    class ZonaService : IZonaService
    {
        private static ILogger logger = LogManager.GetCurrentClassLogger();
        private readonly IDbContextScopeFactory _dbContextScopeFactory;
        private readonly IRepository<Zona> _zonaRepository;

        public ZonaService(IDbContextScopeFactory dbContextScopeFactory, IRepository<Zona> zonaRepository)
        {
            _dbContextScopeFactory = dbContextScopeFactory;
            _zonaRepository = zonaRepository;
        }


        public IEnumerable<Zona> GetAll()
        {
            var result = new List<Zona>();

            try
            {
                using (var ctx = _dbContextScopeFactory.CreateReadOnly())
                {
                    result = _zonaRepository.GetAll().ToList();
                }
            }
            catch (Exception e)
            {
                logger.Error(e.Message);
            }

            return result;
        }

        public IEnumerable<Zona> GetByArea(int areaId)
        {
            var result = new List<Zona>();

            try
            {
                using (var ctx = _dbContextScopeFactory.CreateReadOnly())
                {
                    result = _zonaRepository.GetAll().Where(x => x.AreaId == areaId).ToList();
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
