using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace FrontEnd
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute("Territorios",
                "Organizacion/Territorios",
                new {controller = "Organizacion", action = "Territorios"});

            routes.MapRoute("Areas",
                "Organizacion/Areas/{territorioId}",
                new { controller = "Organizacion", action = "Areas", territorioId = "" });

            routes.MapRoute("Zonas",
                "Organizacion/Zonas/{areaId}",
                new { controller = "Organizacion", action = "Zonas", areaId = "" });

            routes.MapRoute("Sector",
                "Organizacion/Sectores/{zonaId}",
                new { controller = "Organizacion", action = "Sectores", zonaId = "" });

            routes.MapRoute("Grupo",
                "Organizacion/Grupos/{sectorId}",
                new { controller = "Organizacion", action = "Grupos", sectorId = "" });

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );

           
        }
    }
}
