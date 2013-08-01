﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Routing;
using System.Web.Optimization;
using myCMS.Binders;
using myCMS.IoC;
using myCMS.Helpers;
using Ninject;

namespace myCMS
{
    // Note: For instructions on enabling IIS6 or IIS7 classic mode, 
    // visit http://go.microsoft.com/?LinkId=9394801
    public class MvcApplication : System.Web.HttpApplication
    {
        private static IKernel _kernel;
        public IKernel Kernel
        {
            get { return _kernel; }
        }

        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();

            _kernel = new StandardKernel(new BaseModule());
            DependencyResolver.SetResolver(new NinjectDependencyResolver(_kernel));

            // use model binding when your action method needs to receive these
            // values as a parameter
            ModelBinders.Binders.Add(typeof(RouteValues), new RouteBinder());


            WebApiConfig.Register(GlobalConfiguration.Configuration);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);

        }
    }
}