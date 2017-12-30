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
    public interface ISectorService
    {
        IEnumerable<Sector> GetAll();
        IEnumerable<Sector> GetByZona(int zonaId);
    }

    class SectorService : ISectorService
    {
        private static ILogger logger = LogManager.GetCurrentClassLogger();
        private readonly IDbContextScopeFactory _dbContextScopeFactory;
        private readonly IRepository<Sector> _sectorRepository;

        public SectorService(IDbContextScopeFactory dbContextScopeFactory, IRepository<Sector> sectorRepository)
        {
            _dbContextScopeFactory = dbContextScopeFactory;
            _sectorRepository = sectorRepository;
        }


        public IEnumerable<Sector> GetAll()
        {
            var result = new List<Sector>();

            try
            {
                using (var ctx = _dbContextScopeFactory.CreateReadOnly())
                {
                    result = _sectorRepository.GetAll().ToList();
                }
            }
            catch (Exception e)
            {
                logger.Error(e.Message);
            }

            return result;
        }

        public IEnumerable<Sector> GetByZona(int zonaId)
        {
            var result = new List<Sector>();

            try
            {
                using (var ctx = _dbContextScopeFactory.CreateReadOnly())
                {
                    result = _sectorRepository.GetAll().Where(x => x.ZonaId == zonaId).ToList();
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
