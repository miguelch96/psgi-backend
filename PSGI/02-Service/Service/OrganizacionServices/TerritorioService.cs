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
    public interface ITerritorioService
    {
        IEnumerable<Territorio> GetAll();
    }

    class TerritorioService : ITerritorioService
    {
        private static ILogger logger = LogManager.GetCurrentClassLogger();
        private readonly IDbContextScopeFactory _dbContextScopeFactory;
        private readonly IRepository<Territorio> _TerritorioRepository;

        public TerritorioService(IDbContextScopeFactory dbContextScopeFactory, IRepository<Territorio> TerritorioRepository)
        {
            _dbContextScopeFactory = dbContextScopeFactory;
            _TerritorioRepository = TerritorioRepository;
        }


        public IEnumerable<Territorio> GetAll()
        {
            var result = new List<Territorio>();

            try
            {
                using (var ctx = _dbContextScopeFactory.CreateReadOnly())
                {
                    result = _TerritorioRepository.GetAll().ToList();
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
