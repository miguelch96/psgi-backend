using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Common;
using Model.Domain;
using Service;

namespace FrontEnd.Controllers
{
    public class MiembrosController : Controller
    {
        private readonly IMiembroService _miembroService = DependecyFactory.GetInstance<IMiembroService>();

        // GET: Miembro
        public ActionResult Index()
        {
            return View(_miembroService.GetAll());
        }

        // GET: Miembro
        public ActionResult New()
        {
            return View();
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