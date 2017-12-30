using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model.Domain;
using Model.Domain.Estatico;
using NLog;
using Persistence.DbContextScope;
using Persistence.Repository;

namespace Service
{
    public interface ITipoDocumentoService
    {
        IEnumerable<TipoDocumento> GetAll();
    }

    class TipoDocumentoService: ITipoDocumentoService
    {
        private static ILogger logger = LogManager.GetCurrentClassLogger();
        private readonly IDbContextScopeFactory _dbContextScopeFactory;
        private readonly IRepository<TipoDocumento> _tipodocumentoRepository;

        public TipoDocumentoService(IDbContextScopeFactory dbContextScopeFactory, IRepository<TipoDocumento> tipodocumentoRepository)
        {
            _dbContextScopeFactory = dbContextScopeFactory;
            _tipodocumentoRepository = tipodocumentoRepository;
        }

        public IEnumerable<TipoDocumento> GetAll()
        {
            var result = new List<TipoDocumento>();

            try
            {
                using (var ctx = _dbContextScopeFactory.CreateReadOnly())
                {
                    result = _tipodocumentoRepository.GetAll().ToList();
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
