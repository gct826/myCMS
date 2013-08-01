using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using myCMS.Helpers;
using myCMS.Models;
using MongoDB.Driver.Builders;


namespace myCMS
{
    public class RouteConfig
    {
        public class CmsUrlConstraint : IRouteConstraint
        {
            private MongoHelper<PageHeader> _pageheaders;

            public bool Match(HttpContextBase httpContext, Route route, string parameterName, RouteValueDictionary values, RouteDirection routeDirection)
            {
                _pageheaders = new MongoHelper<PageHeader>();

                if (values[parameterName] != null)
                {
                    var permalink = values[parameterName].ToString();
                    var permalinkQuery = Query<PageHeader>.EQ(g => g.Permalink, permalink);

                    if (_pageheaders.Collection.FindOne(permalinkQuery) != null)
                    {
                        return true;
                    }
                }
                
                return false;
            }
        }

        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                name: "CmsRoute",
                url: "{language}/Home/{*permalink}",
                defaults: new { language = "en", controller = "Page", action = "Index" },
                constraints: new { permalink = new CmsUrlConstraint() }
            );

            routes.MapRoute(
                name: "Default",
                url: "{language}/{controller}/{action}/{id}",
                defaults: new { language = "en", controller = "Home", action = "Index", id = UrlParameter.Optional }
            );
        }

    }
}