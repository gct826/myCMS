using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MongoDB.Bson;
using MongoDB.Driver.Builders;
using myCMS.Helpers;
using myCMS.Models;

namespace myCMS.Controllers
{
    public class TranslationController : BaseController
    {
        public TranslationController(IRouteService routeService) : base(routeService)
        {
        }

        private MongoHelper<Translation> _translations; 

        //
        // GET: /Admin/Translation/

        public ActionResult Index()
        {
            RouteValues routeValues = RouteValue;
            ViewBag.langRV = routeValues.Language;
            ViewBag.contRV = routeValues.Controller;
            ViewBag.actiRV = routeValues.Action;
            ViewBag.idRV = routeValues.Id;
            
            ViewBag.Title = "Translations List";
            _translations = new MongoHelper<Translation>();

            var translations = _translations.Collection.FindAll();

            return View(translations.ToList());
        }

        //
        // GET: /Translation/Details?name

        public ActionResult Details(string name)
        {
            RouteValues routeValues = RouteValue;
            ViewBag.langRV = routeValues.Language;
            ViewBag.contRV = routeValues.Controller;
            ViewBag.actiRV = routeValues.Action;
            ViewBag.idRV = routeValues.Id;

            ViewBag.Title = "Language Details";
            _translations = new MongoHelper<Translation>();

            var translationQuery = Query<Translation>.EQ(g => g.Name, name);
            var foundTranslation = _translations.Collection.FindOne(translationQuery);

            return View(foundTranslation);
        }

        //
        // GET: /Translation/Create

        public ActionResult Create()
        {
            RouteValues routeValues = RouteValue;
            ViewBag.langRV = routeValues.Language;
            ViewBag.contRV = routeValues.Controller;
            ViewBag.actiRV = routeValues.Action;
            ViewBag.idRV = routeValues.Id;

            ViewBag.Title = "Translation Create New";
            return View();
        }

        //
        // POST: /Translation/Create

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Translation translation)
        {
            ViewBag.Title = "Translation Create New";
            if (ModelState.IsValid)
            {
                _translations = new MongoHelper<Translation>();
                
                translation.Code = translation.Code.ToLower();

                _translations.Collection.Save(translation);

                return RedirectToAction("Index");
            }

            return View(translation);

        }

        //
        // GET: /Translation/Edit?name

        public ActionResult Edit(string name)
        {
            RouteValues routeValues = RouteValue;
            ViewBag.langRV = routeValues.Language;
            ViewBag.contRV = routeValues.Controller;
            ViewBag.actiRV = routeValues.Action;
            ViewBag.idRV = routeValues.Id;

            ViewBag.Title = "Translation Edit Existing";
            _translations = new MongoHelper<Translation>();

            var translationQuery = Query<Translation>.EQ(g => g.Name, name);
            var foundTranslation = _translations.Collection.FindOne(translationQuery);

            if (foundTranslation == null)
            {
                return HttpNotFound();
            }

            ViewBag.ObjectId = foundTranslation.Id;

            return View(foundTranslation);
        }

        //
        // POST: /Translation/Edit?name

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(string refId, Translation translation)
        {
            _translations = new MongoHelper<Translation>();

            ObjectId test = new ObjectId();
            test = ObjectId.Parse(refId);

            var translationQuery = Query<Translation>.EQ(g => g.Id, test);
            var foundTranslation = _translations.Collection.FindOne(translationQuery);
            translation.Id = foundTranslation.Id;     
            
            //if (ModelState.IsValid)
            //{
            _translations = new MongoHelper<Translation>();

            translation.Code = translation.Code.ToLower();
            _translations.Collection.Save(translation);

                return RedirectToAction("Index");

            //}
            //return View(language);
        }



    }
}
