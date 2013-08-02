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
    public class PageHeaderController : BaseController
    {
        public PageHeaderController(IRouteService routeService)
            : base(routeService)
        {
        }

        private MongoHelper<PageHeader> _pageHeaders;

        //
        // GET: /Admin/PageHeader/

        public ActionResult Index()
        {
            RouteValues routeValues = RouteValue;
            ViewBag.langRV = routeValues.Language;
            ViewBag.contRV = routeValues.Controller;
            ViewBag.actiRV = routeValues.Action;
            ViewBag.idRV = routeValues.Id;

            ViewBag.Title = "PageHeader List";
            _pageHeaders = new MongoHelper<PageHeader>();

            var pageHeaders = _pageHeaders.Collection.FindAll();

            return View(pageHeaders.ToList());
        }

        //
        // GET: /Admin/PageHeader/Details?name

        public ActionResult Details(string name)
        {
            ViewBag.Title = "PageHeader Details";
            _pageHeaders = new MongoHelper<PageHeader>();

            var pageHeaderQuery = Query<PageHeader>.EQ(g => g.Name, name);
            var foundPageHeader = _pageHeaders.Collection.FindOne(pageHeaderQuery);

            return View(foundPageHeader);
        }

        //
        // GET: /Admin/PageHeader/Create

        public ActionResult Create()
        {
            ViewBag.Title = "PageHeader Create New";
            return View();
        }

        //
        // POST: /Admin/PageHeader/Create

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(PageHeader pageHeader)
        {
            ViewBag.Title = "PageHeader Create New";
            if (ModelState.IsValid)
            {
                _pageHeaders = new MongoHelper<PageHeader>();

                pageHeader.Permalink = pageHeader.Permalink.ToLower();
                _pageHeaders.Collection.Save(pageHeader);

                return RedirectToAction("Index");
            }

            return View(pageHeader);

        }

        //
        // GET: /Admin/PageHeader/Edit?name

        public ActionResult Edit(string name)
        {
            ViewBag.Title = "PageHeader Edit Existing";
            _pageHeaders = new MongoHelper<PageHeader>();

            var pageHeaderQuery = Query<PageHeader>.EQ(g => g.Name, name);
            var foundPageHeader = _pageHeaders.Collection.FindOne(pageHeaderQuery);

            if (foundPageHeader == null)
            {
                return HttpNotFound();
            }

            ViewBag.ObjectId = foundPageHeader.Id;

            return View(foundPageHeader);
        }

        //
        // POST: /Admin/PageHeader/Edit?name

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(string refId, PageHeader pageHeader)
        {
            _pageHeaders = new MongoHelper<PageHeader>();

            ObjectId test = new ObjectId();
            test = ObjectId.Parse(refId);

            var pageHeaderQuery = Query<PageHeader>.EQ(g => g.Id, test);
            var foundPageHeader = _pageHeaders.Collection.FindOne(pageHeaderQuery);
            pageHeader.Id = foundPageHeader.Id;

            //if (ModelState.IsValid)
            //{
            _pageHeaders = new MongoHelper<PageHeader>();

            pageHeader.Permalink = pageHeader.Permalink.ToLower();

            _pageHeaders.Collection.Save(pageHeader);

            return RedirectToAction("Index");

            //}
            //return View(language);
        }



    }
}
