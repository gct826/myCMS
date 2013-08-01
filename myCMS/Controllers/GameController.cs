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
    public class GameController : BaseController
    {
        public GameController(IRouteService routeService) : base(routeService)
        {
        }

        private MongoHelper<Game> _games; 

        //
        // GET: /Game/

        public ActionResult Index()
        {
            ViewBag.Title = "Games Index";   
            _games = new MongoHelper<Game>();

            var games = _games.Collection.FindAll();

            return View(games.ToList());
        }

        //
        // GET: /Game/Details?name

        public ActionResult Details(string name)
        {
            ViewBag.Title = "Details";
            _games = new MongoHelper<Game>();

            var gameQuery = Query<Game>.EQ(g => g.Name, name);
            var foundGame = _games.Collection.FindOne(gameQuery);

            return View(foundGame);
        }

        //
        // GET: /Game/Create

        public ActionResult Create()
        {
            ViewBag.Title = "Create";   
            return View();
        }

        //
        // POST: /Game/Create

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Game game)
        {
            ViewBag.Title = "Create";   
            if (ModelState.IsValid)
            {
                _games = new MongoHelper<Game>();

                _games.Collection.Save(game);

                return RedirectToAction("Index");
            }

            return View(game);
        }

        //
        // GET: /Game/Edit?name

        public ActionResult Edit(string name)
        {
            ViewBag.Title = "Edit";  
            _games = new MongoHelper<Game>();

            var gameQuery = Query<Game>.EQ(g => g.Name, name);
            var foundGame = _games.Collection.FindOne(gameQuery);
            
            if (foundGame == null)
            {
                return HttpNotFound();
            }
            ViewBag.Objectid = foundGame.Id;

            return View(foundGame);
        }

        //
        // POST: /Game/Edit?name

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(string refId, Game game)
        {
            ViewBag.Title = "Edit";  
            _games = new MongoHelper<Game>();

            ObjectId test = new ObjectId();
            test = ObjectId.Parse(refId);

            var gameQuery = Query<Game>.EQ(g => g.Id, test);
            var foundGame = _games.Collection.FindOne(gameQuery);
            game.Id = foundGame.Id;     

            if (game.ReleaseDate == new DateTime(0001,1,1))
            {
                game.ReleaseDate = foundGame.ReleaseDate;
            }
            
            //if (ModelState.IsValid)
            //{
                _games = new MongoHelper<Game>();

                _games.Collection.Save(game);

                return RedirectToAction("Index");

            //}
            return View(game);
        }



    }
}
