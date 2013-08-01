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

            //var translation = new TranslationHelper();
            //var defaultTranslation = translation.DefaultTranslation();
            
            //ViewBag.Test = defaultTranslation;

            ViewBag.langRV = routeValues.Language;
            ViewBag.contRV = routeValues.Controller;
            ViewBag.actiRV = routeValues.Action;
            ViewBag.Title = "myCMS";

            return View();
        }

    }
}
