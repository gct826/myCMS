using System.Web.Mvc;
using myCMS.Helpers;
using myCMS.Models;

namespace myCMS.Controllers
{
    public class HomeController : BaseController
    {
        public HomeController(IRouteService routeService) : base(routeService)
        {
        }
        
        //
        // GET: /Home/
        public ActionResult Index()
        {
            RouteValues routeValues = RouteValue;

            var translation = new TranslationHelper();
            //var defaultTranslation = translation.DefaultTranslation();
            
            if (!translation.ValidTranslation(routeValues.Language))
            {
                ViewBag.Test = "Invalid Language Route";
            }
            //ViewBag.Test = defaultTranslation;

            ViewBag.langRV = routeValues.Language;
            ViewBag.contRV = routeValues.Controller;
            ViewBag.actiRV = routeValues.Action;
            ViewBag.idRV = routeValues.Id;
            ViewBag.Title = "myCMS";

            return View();
        }

        public ActionResult Page(string permalink)
        {
            RouteValues routeValues = RouteValue;
            ViewBag.langRV = routeValues.Language;
            ViewBag.contRV = routeValues.Controller;
            ViewBag.actiRV = routeValues.Action;
            ViewBag.idRV = routeValues.Id;
            ViewBag.Title = "myCMS";

            return View();

        }

    }
}
