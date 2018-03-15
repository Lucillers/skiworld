using SkiWorld.Data.Models;
using SkiWorld.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SkiWorld.MVC.Controllers
{
    public class ClaimController : Controller
    {
        ClaimService cs = new ClaimService();
        // GET: Claim
        public ActionResult Index()
        {
            return View();
        }

        // GET: Claim/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Claim/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Claim/Create
        [HttpPost]
        public ActionResult Create(claim cl)
        {
            cs.Add(cl);
            cs.Commit();
            return RedirectToAction("../claim/create");
        }

        // GET: Claim/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Claim/Edit/5
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

        // GET: Claim/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Claim/Delete/5
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
