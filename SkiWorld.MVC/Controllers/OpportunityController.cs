using SkiWorld.Data.Models;
using SkiWorld.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SkiWorld.MVC.Controllers
{
    public class OpportunityController : Controller
    {
        OpportunityService op = null;

        public OpportunityController()
        {
            op = new OpportunityService();
        }
        // GET: Opportunity
        public ActionResult Index()
        {
            var o = op.GetAll();
            return View(o);
        }

        // GET: Opportunity/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Opportunity/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Opportunity/Create
        [HttpPost]
        public ActionResult Create(opportunity opportunity)
        {

            op.Add(opportunity);
            op.Commit();

                return RedirectToAction("Index");
          
        }

        // GET: Opportunity/Edit/5
        public ActionResult Edit(int id)
        {
            var  o = op.GetById(id);
            opportunity opp = new opportunity
            {
                description = o.description,

            };
            return View(o);
        }

        // POST: Opportunity/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, opportunity opportunity)
        {
            opportunity p = op.GetById(id);
            p.description = opportunity.description;
            op.Update(p);
            op.Commit();
                return RedirectToAction("Index");
          
        }

        // GET: Opportunity/Delete/5
        public ActionResult Delete(int id)
        {
            return View(op.GetById(id));
        }

        // POST: Opportunity/Delete/5
        [HttpPost,ActionName("Delete")]
        public ActionResult Delete(int id, opportunity opportunity)
        {
            if (ModelState.IsValid)
            { 
            opportunity = op.GetById(id);
            op.Delete(opportunity);
            op.Commit();
        }
                return RedirectToAction("Index");
          
        }
    }
}
