using SkiWorld.Data.Models;
using SkiWorld.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SkiWorld.MVC.Controllers
{
    public class RestaurantController : Controller
    {
        RestaurantService rs = null;
        
        // GET: Restaurant
        public RestaurantController()
            {
            rs = new RestaurantService();
           


        }
        public ActionResult Index()
        {
            var r = rs.GetAll();
            return View(r);
        }

        // GET: Restaurant/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Restaurant/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Restaurant/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Restaurant/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Restaurant/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Restaurant/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Restaurant/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
        public ActionResult Tablesresto(int id)

        {
            skiworldContext sc = new skiworldContext();
            var query = from c in sc.restotable.Where(c => c.restaurant_idRestaurant == id)
                        select c;


            return View(query);

        }

        public ActionResult Menustable(int id)

        {
            skiworldContext sc = new skiworldContext();

            var query = from c in sc.menu.Where(c=> c.idRestaurant==id)
                        select c;

            return View(query);
        }



    }
}
