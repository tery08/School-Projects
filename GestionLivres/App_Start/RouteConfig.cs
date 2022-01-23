using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace GestionLivres
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Livres", action = "Index", id = UrlParameter.Optional }
            );
            routes.MapRoute(
                name: "GestionLivres",
                url: "GestionLivres",
                defaults: new { controller = "Livres", action = "GestionLivres" }
            );
            routes.MapRoute(
                name: "Enregistrer",
                url: "Enregistrer",
                defaults: new { controller = "Livres", action = "Enregistrer" }
            );
            routes.MapRoute(
                name: "Modifier",
                url: "Modifier",
                defaults: new { controller = "Livres", action = "Modifier" }
            );
            routes.MapRoute(
                name: "GestionMembres",
                url: "GestionMembres",
                defaults: new { controller = "Membres", action = "GestionMembres" }
            );
            routes.MapRoute(
                name: "EnregistrerMembre",
                url: "EnregistrerMembre",
                defaults: new { controller = "Membres", action = "EnregistrerMembre" }
            );
            routes.MapRoute(
                name: "ModifierMembre",
                url: "ModifierMembre",
                defaults: new { controller = "Membres", action = "ModifierMembre" }
            );
            routes.MapRoute(
                name: "ListePrets",
                url: "ListePrets",
                defaults: new { controller = "Pret", action = "ListePrets" }
            );
            routes.MapRoute(
                name: "EnregistrerPret",
                url: "EnregistrerPret",
                defaults: new { controller = "Pret", action = "EnregistrerPret" }
            );
            routes.MapRoute(
                name: "EnregistrerRetour",
                url: "EnregistrerRetour",
                defaults: new { controller = "Pret", action = "EnregistrerRetour" }
            );
        }
    }
}
