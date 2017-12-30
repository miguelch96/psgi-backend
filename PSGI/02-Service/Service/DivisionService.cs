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
    public interface IDivisionService
    {
        IEnumerable<Division> GetAll();
    }

    class DivisionService : IDivisionService
    {
        private static ILogger logger = LogManager.GetCurrentClassLogger();
        private readonly IDbContextScopeFactory _dbContextScopeFactory;
        private readonly IRepository<Division> _divisionRepository;

        public DivisionService(IDbContextScopeFactory dbContextScopeFactory, IRepository<Division> divisionRepository)
        {
            _dbContextScopeFactory = dbContextScopeFactory;
            _divisionRepository = divisionRepository;
        }


        public IEnumerable<Division> GetAll()
        {
            var result = new List<Division>();

            try
            {
                using (var ctx = _dbContextScopeFactory.CreateReadOnly())
                {
                    result = _divisionRepository.GetAll().ToList();
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
