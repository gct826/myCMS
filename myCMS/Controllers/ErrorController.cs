using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using myCMS.Helpers;

namespace myCMS.Controllers
{
    public class ErrorController : BaseController
    {
        public ErrorController(IRouteService routeService) : base(routeService)
        {
        }
        //
        // GET: /Error/

        public ActionResult Index()
        {
            return View("Error");
        }

    }
}
