using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace WebApplication2
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                "login",
                "login",
                new { controller = "UsuarioAcesso", action = "Login" });

            routes.MapRoute(
                "cadastro",
                "cadastro",
                new { controller = "UsuarioAcesso", action = "Signup" });

            routes.MapRoute(
                "gerenciarUsuarios",
                "gerenciar-usuarios",
                new { controller = "UsuarioAcesso", action = "Index" });

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "UsuarioAcesso", action = "Login", id = UrlParameter.Optional }
            );
        }
    }
}
