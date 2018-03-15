using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SkiWorld.Service;
using SkiWorld.Data.Models;

namespace SkiWorld.MVC.Controllers
{
    public class EvenementController : Controller
    {
        EvenementServices Clr = null;
        EvenementServices ST = new EvenementServices();

        public EvenementController()
        {
            Clr = new EvenementServices();
        }

        // GET: Evenement
        //search a Category
        public ActionResult Index(string searchString)
        {

            IEnumerable<evenement> movies = Clr.GetAll();

            if (!String.IsNullOrEmpty(searchString))
            {
                movies = movies.Where(s => s.name.Contains(searchString));
            }

            return View(movies);
        }

        // GET: Evenement/Details/5
        public ActionResult Details(int id)
        {
            return View(Clr.GetById(id));
        }

        // GET: Evenement/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Evenement/Create
        [HttpPost]
        public ActionResult Create(evenement c)
        {
            evenement cl = new evenement();

            cl.idEvent = c.idEvent;
            cl.name = c.name;
            cl.dateEvent = c.dateEvent;
            cl.place = c.place;
            cl.numberGuests = c.numberGuests;
            
            Clr.Add(cl);
            Clr.Commit();
            //List<evenement> developpeurs = Session["evenement"] as List<evenement>;

           // if (developpeurs == null)
            //{ developpeurs = new List<Developpeur>(); }

           // developpeurs.Add(cl);
           // Session["Developpeur"] = developpeurs;

            return RedirectToAction("../Evenement/Create");
        }

        // GET: Evenement/Edit/5
        public ActionResult Edit(int id)
        {
            evenement sc = Clr.GetById(id);
            evenement cvm = new evenement
            {

                name = sc.name,
                dateEvent = sc.dateEvent,
                numberGuests = sc.numberGuests,
                place = sc.place

            };

            return View(cvm);
        }

        // POST: Evenement/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, evenement evenement)
        {
            evenement c = Clr.GetById(id);
            c.name = evenement.name;
            c.dateEvent = evenement.dateEvent;
            c.place = evenement.place;
            c.numberGuests = evenement.numberGuests;

            Clr.Update(c);
            Clr.Commit();
            return RedirectToAction("Index");
        }

        // GET: Evenement/Delete/5
        public ActionResult Delete(int id)
        {
            return View(Clr.GetById(id));
        }

        // POST: Evenement/Delete/5
        [HttpPost, ActionName("Delete")]
        public ActionResult Delete(int id, evenement evenement)
        {
            if (ModelState.IsValid)
                

            {
                
                evenement = Clr.GetById(id);
                Clr.Delete(evenement);
                Clr.Commit();
            }
            return RedirectToAction("Index");
        }


        
    }
}
