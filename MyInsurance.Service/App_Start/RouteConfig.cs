using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace MyInsurance.Service
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                name: "TeklifAl",
                url: "teklif-al",
                defaults: new { Controller = "Offer", action = "GetOffer" }
            );

            routes.MapRoute(
                name: "Teklifler",
                url: "teklifler",
                defaults: new { Controller = "Offer", action = "OfferList", offerList = UrlParameter.Optional }
            );

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}

