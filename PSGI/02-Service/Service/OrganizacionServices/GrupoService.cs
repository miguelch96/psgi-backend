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
    public interface IGrupoService
    {
        IEnumerable<Grupo> GetAll();
        IEnumerable<Grupo> GetBySector(int sectorId);
    }

    class GrupoService : IGrupoService
    {
        private static ILogger logger = LogManager.GetCurrentClassLogger();
        private readonly IDbContextScopeFactory _dbContextScopeFactory;
        private readonly IRepository<Grupo> _grupoRepository;

        public GrupoService(IDbContextScopeFactory dbContextScopeFactory, IRepository<Grupo> grupoRepository)
        {
            _dbContextScopeFactory = dbContextScopeFactory;
            _grupoRepository = grupoRepository;
        }


        public IEnumerable<Grupo> GetAll()
        {
            var result = new List<Grupo>();

            try
            {
                using (var ctx = _dbContextScopeFactory.CreateReadOnly())
                {
                    result = _grupoRepository.GetAll().ToList();
                }
            }
            catch (Exception e)
            {
                logger.Error(e.Message);
            }

            return result;
        }

        public IEnumerable<Grupo> GetBySector(int sectorId)
        {
            var result = new List<Grupo>();

            try
            {
                using (var ctx = _dbContextScopeFactory.CreateReadOnly())
                {
                    result = _grupoRepository.GetAll().Where(x => x.SectorId == sectorId).ToList();
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
