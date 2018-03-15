using Microsoft.AspNet.Identity;
using SkiWorld.Data.Models;
using SkiWorld.MVC.Models;
using SkiWorld.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SkiWorld.MVC.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        // GET: Event/Edit/5
        public ActionResult Edit()
        {
            ProfilService c = new ProfilService();
            user u = c.GetById(User.Identity.GetUserId());
            profilModel pm = new profilModel
            {
                firstName = u.firstName,
                lastName = u.lastName,
                adress=u.adress,
                email = u.Email,
                age = u.age,
                file = u.file,




            };


            return View(pm);
        }

        // POST: Event/Edit/5
        [HttpPost]
        public ActionResult Edit(profilModel E)
        {
            ProfilService c = new ProfilService();
            if (!ModelState.IsValid)
            {
                RedirectToAction("Edit");
            }
            user user = c.GetById(User.Identity.GetUserId());
            user.firstName = E.firstName;
            user.lastName = E.lastName;
            user.adress = E.adress;
            user.Email = E.email;
            user.age = E.age;
            user.file = E.file;
            c.Update(user);
            c.Commit();


            return RedirectToAction("Index");
        }


        public ActionResult ProfilDetails()
        {
            
            ProfilService ps = new ProfilService();
            user u = ps.GetById(User.Identity.GetUserId());

            profilModel p = new profilModel
            {

                firstName = u.firstName,
                lastName = u.lastName,
                adress = u.adress,
                email = u.Email,
                age = u.age,
                file=u.file,



            };

            return View(p);
        }
    }
}