using SkiWorld.Data.Models;
using SkiWorld.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SkiWorld.MVC.Controllers
{
    public class MenuController : Controller
    {
        MenuService ms = new MenuService();
        RestoService rs = new RestoService();
        // GET: Menu
        public ActionResult Index()
        {
            var m = ms.GetAll();
            return View(m);
        }

        // GET: Menu/Details/5
        public ActionResult Details(int id)
        {
            return View(ms.GetById(id));
        }

        // GET: Menu/Create
        public ActionResult Create()
        {
            IEnumerable<restaurant> list = rs.GetAll();
            SelectList sl = new SelectList(list, "idRestaurant", "name");
            ViewBag.rss = sl;

            return View();
        }

        // POST: Menu/Create
        [HttpPost]
        public ActionResult Create(menu menu)
        {
            //ms.Add(menu);
            //ms.Commit();
            //return RedirectToAction("../menu/create");
            menu c = new menu
            {
                name = menu.name,
                orderNumber = menu.orderNumber,
                price = menu.orderNumber,
                idRestaurant=menu.idRestaurant,


            };
            if (ModelState.IsValid)
            {
                ms.Add(c);
                ms.Commit();
            }
            return RedirectToAction("Index");
        }

        // GET: Menu/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Menu/Edit/5
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

        // GET: Menu/Delete/5
        public ActionResult Delete(int id)
        {
            return View(ms.GetById(id));
        }

        // POST: Menu/Delete/5
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
    }
}
