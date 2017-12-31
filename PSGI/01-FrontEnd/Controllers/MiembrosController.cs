using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Common;
using FrontEnd.ViewModels.VMMiembro;
using Model.Domain;
using Service;
using Service.OrganizacionServices;

namespace FrontEnd.Controllers
{
    [Authorize]
    public class MiembrosController : Controller
    {
        private readonly IMiembroService _miembroService = DependecyFactory.GetInstance<IMiembroService>();
        private readonly IDivisionService _divisionService = DependecyFactory.GetInstance<IDivisionService>();
        private readonly IEstadoService _estadoService = DependecyFactory.GetInstance<IEstadoService>();
        private readonly ITipoDocumentoService _tipodocumentoService = DependecyFactory.GetInstance<ITipoDocumentoService>();
        private readonly ITipoMiembroService _tipomiembroService = DependecyFactory.GetInstance<ITipoMiembroService>();
        private readonly ITerritorioService _territorioService = DependecyFactory.GetInstance<ITerritorioService>();


        // GET: Miembro
        public ActionResult Index()
        {
            return View(_miembroService.GetAll());
        }

        // GET: Miembro
        public ActionResult AddEditMiembro()
        {
            var vm = new AddEditMiembroViewModel
            {
                Divisiones = _divisionService.GetAll(),
                Estados = _estadoService.GetAll(),
                TiposDocumento = _tipodocumentoService.GetAll(),
                TiposMiembro = _tipomiembroService.GetAll(),
                Territorios = _territorioService.GetAll()
            };
            return View(vm);
        }

        // GET: Miembro
        [HttpPost]
        public ActionResult AddEditMiembro(AddEditMiembroViewModel model)
        {
            if (!ModelState.IsValid)
            {
                TryUpdateModel(model);
                return View(model);
            }

            var rh = _miembroService.InsertOrUpdate(model.Miembro);
            if (rh.Response)
            {
                return RedirectToAction("Index");
            }
            return View(model);
        }

        // GET: Miembro
        public ActionResult Deleted(int id)
        {
            _miembroService.Delete(id);
            return RedirectToAction("Index");
        }
    }
}