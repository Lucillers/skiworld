using SkiWorld.Data.Models;
using SkiWorld.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SkiWorld.MVC.Controllers
{
    public class RestoController : Controller
    {
        RestoService rs = null;
        RestoService rss = new RestoService();
        public RestoController ()
        {
            rs = new RestoService();
        }
        
        // GET: Resto
        //public ActionResult Index()
        //{
        //    var r = rs.GetAll();
        //    return View(r);
        //}
        // GET: Resto
        public ActionResult Index(string searchString)
        {
            IEnumerable<restaurant> rst = rs.GetAll();

            if (!String.IsNullOrEmpty(searchString))
            {
                rst = rst.Where(s => s.name.Contains(searchString));
            }

            return View(rst);
        }
        // GET: Resto/Details/5
        public ActionResult Details(int id)
        {
            return View(rs.GetById(id));
        }

        // GET: Resto/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Resto/Create
        [HttpPost]
        public ActionResult Create(restaurant rest)
        {
            rss.Add(rest);
            rss.Commit();
            return RedirectToAction("../Resto/create");
        }

        // GET: Resto/Edit/5
        public ActionResult Edit(int id)
        {
            restaurant rest = rss.GetById(id);
            restaurant rst = new restaurant
            {
                closeDate = rest.closeDate,
                openDate = rest.openDate,
                location = rest.location,
                name = rest.name,
                phone = rest.phone,
                starRating = rest.starRating

            };
            return View(rest);
        }

        // POST: Resto/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, restaurant rest)
        {
            restaurant r = rss.GetById(id);
            r.closeDate = rest.closeDate;
            r.openDate = rest.openDate;
            r.location = rest.location;
            r.name = rest.name;
            r.phone = rest.phone;
            rss.Update(r);
            rss.Commit();
            return RedirectToAction("Index");
        }

        // GET: Resto/Delete/5
        public ActionResult Delete(int id)
        {
            return View(rss.GetById(id));
        }

        // POST: Resto/Delete/5
        [HttpPost]
        public ActionResult Delete(int id,restaurant rest)
        {
            rest = rss.GetById(id);
            rss.Delete(rest);
            rss.Commit();
            return RedirectToAction("Index");
        }
    }
}
