using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Common;
using Service;
using Service.OrganizacionServices;

namespace FrontEnd.Controllers
{
    [Authorize]
    public class OrganizacionController : Controller
    {
        private readonly ITerritorioService _territorioService = DependecyFactory.GetInstance<ITerritorioService>();
        private readonly IAreaService _areaService = DependecyFactory.GetInstance<IAreaService>();
        private readonly IZonaService _zonaService = DependecyFactory.GetInstance<IZonaService>();
        private readonly ISectorService _sectorService = DependecyFactory.GetInstance<ISectorService>();
        private readonly IGrupoService _grupoService = DependecyFactory.GetInstance<IGrupoService>();


        public JsonResult Territorios()
        {
            var territorios = _territorioService.GetAll();
            return Json(territorios,JsonRequestBehavior.AllowGet);
        }

        //[Route("~/Organizacion/Areas/{territorioId:int}")]
        public JsonResult Areas(int territorioId)
        {
            var areas = _areaService.GetByTerritorio(territorioId);
            return Json(areas,JsonRequestBehavior.AllowGet);
        }

        public JsonResult Zonas(int areaId)
        {
            var zonas = _zonaService.GetByArea(areaId);
            return Json(zonas, JsonRequestBehavior.AllowGet);
        }

        public JsonResult Sectores(int zonaId)
        {
            var sector = _sectorService.GetByZona(zonaId);
            return Json(sector, JsonRequestBehavior.AllowGet);
        }

        public JsonResult Grupos(int sectorId)
        {
            var grupos = _grupoService.GetBySector(sectorId);
            return Json(grupos, JsonRequestBehavior.AllowGet);
        }
    }
}