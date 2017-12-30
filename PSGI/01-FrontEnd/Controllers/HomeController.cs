using System.Web.Mvc;
using Common;
using NLog;
using Service;

namespace FrontEnd.Controllers
{
    public class HomeController : Controller
    {
        //private readonly IMiembroService _miembroService = DependecyFactory.GetInstance<IMiembroService>();
        public ActionResult Index()
        {
            //var miembros = _miembroService.GetAll();
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}