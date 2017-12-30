using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Common;
using FrontEnd.ViewModels.VMMiembro;
using Model.Domain;
using Service;

namespace FrontEnd.Controllers
{
    public class MiembrosController : Controller
    {
        private readonly IMiembroService _miembroService = DependecyFactory.GetInstance<IMiembroService>();
        private readonly IDivisionService _divisionService = DependecyFactory.GetInstance<IDivisionService>();
        private readonly IEstadoService _estadoService = DependecyFactory.GetInstance<IEstadoService>();
        private readonly ITipoDocumentoService _tipodocumentoService = DependecyFactory.GetInstance<ITipoDocumentoService>();
        private readonly ITipoMiembroService _tipomiembroService = DependecyFactory.GetInstance<ITipoMiembroService>();

        // GET: Miembro
        public ActionResult Index()
        {
            return View(_miembroService.GetAll());
        }

        // GET: Miembro
        public ActionResult New()
        {
            var vm = new AddEditMiembroViewModel();
            vm.Divisiones = _divisionService.GetAll();
            vm.Estados = _estadoService.GetAll();
            vm.TiposDocumento = _tipodocumentoService.GetAll();
            vm.TiposMiembro = _tipomiembroService.GetAll();
            return View(vm);
        }

        // GET: Miembro
        [HttpPost]
        public ActionResult Create(Miembro model)
        {
            _miembroService.InsertOrUpdate(model);
            return RedirectToAction("Index");
        }

        // GET: Miembro
        public ActionResult Deleted(int id)
        {
            _miembroService.Delete(id);
            return RedirectToAction("Index");
        }
    }
}