using SkiWorld.Data.Models;
using SkiWorld.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SkiWorld.MVC.Controllers
{
    public class HotelController : Controller
    {
        HotelService hs = null;
        // HotelService hs = new HotelService();
        // GET: Hotel
        public HotelController()
        {
            hs = new HotelService();
        }
        public ActionResult Index(string searchString, string sortOrder)
        {
            ViewData["CurrentFilter"] = searchString;
            ViewData["NameSortParm"] = String.IsNullOrEmpty(sortOrder) ? "name_desc" : "";
            ViewData["StarsSortParm"] = sortOrder == "Stars" ? "stars_asc" : "Stars";
            var h = hs.GetAll();
            if (!String.IsNullOrEmpty(searchString))
            {
                h = h.Where(c => c.name.StartsWith(searchString));

            }
            
            return View(h);
        }

        // GET: Hotel/Details/5
        public ActionResult Details(int id)
        {
            return View(hs.GetById(id));
        }

        // GET: Hotel/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Hotel/Create
        [HttpPost]
        public ActionResult Create(hotel hotel)
        {
            hs.Add(hotel);
            hs.Commit();
            

                return RedirectToAction("Index");
            
        }

        // GET: Hotel/Edit/5
        public ActionResult Edit(int id)
        {
            var h = hs.GetById(id);
            hotel hh = new hotel
            {

                address = h.address,
                email = h.email,
                name = h.name,
                phone = h.phone,
                rating = h.rating,
                stars = h.stars,
            };

            return View(h);
        }

        // POST: Hotel/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, hotel hotel)
        {
            hotel h = hs.GetById(id);
            h.address = hotel.address;
            h.email = hotel.email;
            h.name = hotel.name;
            h.phone = hotel.phone;
            h.rating = hotel.rating;
            h.stars = hotel.stars;
            hs.Update(h);
            hs.Commit();
                return RedirectToAction("Index");
           
        }

        // GET: Hotel/Delete/5
        public ActionResult Delete(int id)
        {
            return View(hs.GetById(id));
        }

        // POST: Hotel/Delete/5
        [HttpPost]
        public ActionResult Delete(int id,hotel hotel )
        {
            // hs.Delete(hotel);
            if (ModelState.IsValid)

            {

                hotel = hs.GetById(id);
                hs.Delete(hotel);
                hs.Commit();
            }
            return RedirectToAction("Index");
          
        }
        public ActionResult recherche()
        {
            var x = hs.GetAll();
            return View(x);
        }
        public ActionResult resultatrecherche( int id)
        {
            var x = hs.getUsers(id);
            return View(x);
        }
    }
}
