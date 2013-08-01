using Ninject.Modules;
using System.Web.Mvc;
using myCMS.Helpers;

namespace myCMS.IoC
{
    public class BaseModule : NinjectModule 
    {
        public override void Load()
        {
            Bind<IController>().To<Controller>();
            Bind<IRouteService>().To<RouteService>();
        }
    }
}