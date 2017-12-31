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
    public interface IAreaService
    {
        IEnumerable<Area> GetAll();
        IEnumerable<Area> GetByTerritorio(int terriotorioId);
    }

    class AreaService : IAreaService
    {
        private static ILogger logger = LogManager.GetCurrentClassLogger();
        private readonly IDbContextScopeFactory _dbContextScopeFactory;
        private readonly IRepository<Area> _areaRepository;

        public AreaService(IDbContextScopeFactory dbContextScopeFactory, IRepository<Area> areaRepository)
        {
            _dbContextScopeFactory = dbContextScopeFactory;
            _areaRepository = areaRepository;
        }


        public IEnumerable<Area> GetAll()
        {
            var result = new List<Area>();

            try
            {
                using (var ctx = _dbContextScopeFactory.CreateReadOnly())
                {
                    result = _areaRepository.GetAll().ToList();
                }
            }
            catch (Exception e)
            {
                logger.Error(e.Message);
            }

            return result;
        }

        public IEnumerable<Area> GetByTerritorio(int territorioId)
        {
            var result = new List<Area>();

            try
            {
                using (var ctx = _dbContextScopeFactory.CreateReadOnly())
                {
                    result = _areaRepository.GetAll().Where(x=>x.TerritorioId== territorioId).ToList();
                    Console.Write(result);
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
