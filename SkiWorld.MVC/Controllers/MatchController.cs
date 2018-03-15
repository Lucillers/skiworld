using SkiWorld.Data.Models;
using SkiWorld.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SkiWorld.MVC.Controllers
{
    public class MatchController : Controller
    {

        IMatchServices service = null;
        CompetitionServices serviceComp = null;
        public MatchController()
        {
            service = new MatchServices();
            serviceComp = new CompetitionServices();
        }

        // GET: Match
        public ActionResult Index(string searchString)
        {
            IEnumerable<competition> liste = serviceComp.getAll();
            SelectList selectlist = new SelectList(liste, "idComp", "name");
            ViewBag.Categ = selectlist;


            IEnumerable<match> movies = service.GetAll();

            if (!String.IsNullOrEmpty(searchString))
            {
                movies = movies.Where(s => s.competition.name.Contains(searchString));
                
            }
            

            return View(movies);
        }

        // GET: Match/Details/5
        public ActionResult Details(int id)
        {
            return View(service.GetById(id));
        }

        // GET: Match/Create
        public ActionResult Create()
        {
            IEnumerable<competition> liste = serviceComp.getAll();
            SelectList selectlist = new SelectList(liste, "idComp", "name");
            ViewBag.Categ = selectlist;


            return View();
        }

        // POST: Match/Create
        [HttpPost]
        public ActionResult Create(match match)
        {
            
            match c = new match
            {
                player1 = match.player1,
                player2 = match.player2,
                dateMatch = match.dateMatch,
                idComp=match.idComp,


            };

            if (ModelState.IsValid)
            {
                service.create(c);
                service.Commit();

            }

            return RedirectToAction("Index");
        }

        // GET: Match/Edit/5
        public ActionResult Edit(int id)
        {

            IEnumerable<competition> liste = serviceComp.getAll();
            SelectList selectlist = new SelectList(liste, "idComp", "name");
            ViewBag.Categ = selectlist;

            match sc = service.GetById(id);
            match cvm = new match
            {
                
                player1 = sc.player1,
                player2 = sc.player2,
                dateMatch = sc.dateMatch,
                idComp=sc.idComp


            };

            return View(cvm);
        }

        // POST: Match/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, match matchmodel)
        {
            match c = service.GetById(id);
            // c.SubCategoryId
            c.player1 = matchmodel.player1;
            c.player2 = matchmodel.player2;
            c.dateMatch = matchmodel.dateMatch;
            c.idComp = matchmodel.idComp;


            service.update(c);
            service.Commit();
            return RedirectToAction("Index");
        }

        // GET: Match/Delete/5
        public ActionResult Delete(int id)
        {
            return View(service.GetById(id));
        }

        // POST: Match/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, match match)
        {
            if (ModelState.IsValid)

            {

                match = service.GetById(id);
                service.delete(match);
                service.Commit();
            }
            return RedirectToAction("Index");
        }


        //***********************search subCateg BY Category******************************//

        //public ActionResult Index2(string movieGenre, string searchString)
        //{
        //    int idComp;
        //    int idMatch;
        //    int idSend;

        //    List<competition> x = new List<competition>();
        //    IEnumerable<competition> liste = serviceComp.getAll();
        //    SelectList selectlist = new SelectList(liste, "idComp", "name");
        //    ViewBag.movieGenre = selectlist;



        //    IEnumerable<match> listeSubCate = service.GetAll();

        //    if (!String.IsNullOrEmpty(searchString))
        //    {


        //        idMatch = service.GetAll().Where(c => c.player1 == searchString).First().idMatch;
        //        idSend = idMatch;

        //        return View(listeSubCate.Where(c => c.idMatch == idSend));
        //    }

        //    //if (!string.IsNullOrEmpty(movieGenre))
        //    //{

        //    //    //moviegenre c'est un index
        //    //    //il faut recuprer la valeur de cette index

        //    //    //idCateg = serviceCategory.GetAllCategories().Where(c => c.Name == movieGenre).First().CategoryId;
        //    //    //idCateg = serviceCategory.GetAllCategories().Where(c => c.Name == selectlist.SelectedValue.ToString()).First().CategoryId;


        //    //    idComp = serviceComp.getAll().Where(c => c.name == "location").First().idComp;

        //    //    // idCateg = serviceCategory.GetAllCategories().Where(c => c.Name == selectlist.SelectedValue.ToString()).First().CategoryId;
        //    //    idMatch = service.GetAll().Where(c => c.idComp == idComp).First().idMatch;
        //    //    idSend = idMatch;
        //    //    return View(listeSubCate.Where(c => c.idMatch == idSend));
        //    //}


        //    return View(listeSubCate);

        //}
    }
}
