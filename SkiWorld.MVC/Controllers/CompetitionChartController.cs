using SkiWorld.Data.Models;
using SkiWorld.Service;
using SkiWorld.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Helpers;
using System.Web.Mvc;

namespace SkiWorld.MVC.Controllers
{
    public class CompetitionChartController : Controller
    {

        CompetitionServices service = null;
        MatchServices matchservice = null;
        public CompetitionChartController()
        {
            service = new CompetitionServices();
            matchservice = new MatchServices();
        }



        // GET: Chart
        public ActionResult Index()
        {
            //on peut pas utiliser groupBy
            List<competition> ff = new List<competition>();

            // List<SubCategory> disponibilite = (List<SubCategory>)serviceSubCateg.GetAllSubCategories().GroupBy(x=>x.CategoryId).Select(g => new { Name = g.Key, Count = g.Count() });
            var disponibilite = matchservice.GetAll().GroupBy(x => x.idComp).ToList();

            //je vais faire le stat des valeur qui existe dans fvm
            List<match> fVM = new List<match>();


            int[] CounSubCateg = new int[disponibilite.Count()];
            string[] nameCat = new string[disponibilite.Count()];
            int i = 0;
            foreach (var group in disponibilite) //parcourir liste des subCateg et compter
            {

                int compteur = 0;
                foreach (var item in group)
                {
                    compteur++;
                }
                CounSubCateg[i] = compteur;

                var cat = service.GetById(group.Key.Value);
                nameCat[i] = cat.name;
                i++;
            }

            string myTheme =
               @"<Chart BackColor=""Transparent"">
            <ChartAreas> 
                    <ChartArea Name=""Default"" BackColor=""Transparent""></ChartArea>

            </ChartAreas>
            </Chart>";
            new Chart(width: 600, height: 600, theme: myTheme).AddTitle("Statistic of matchs  By competition")
                    .AddSeries(
                  //Transparent
                  chartType: "pie",
                  //chartType: "StackedColumn ",
                 // chartType: "StackedArea ",

                 xValue: nameCat,

                  yValues: CounSubCateg)


                  .Write("png");
            return null;
        }

        // GET: Chart/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Chart/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Chart/Create
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

        // GET: Chart/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Chart/Edit/5
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

        // GET: Chart/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Chart/Delete/5
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
        //********stat***********//
        public ActionResult MyChart()
        {
            decimal Jan = 0;
            decimal Feb = 4;
            new Chart(width: 800, height: 200)
                .AddSeries(

              chartType: "Column",
              xValue: new[] { "Jan", "Feb" },
              yValues: new[] { Jan, Feb })
              .Write("png");
            return null;
        }


        public ActionResult BillChart()
        {
            //on peut pas utiliser groupBy
            List<competition> ff = new List<competition>();

            // List<SubCategory> disponibilite = (List<SubCategory>)serviceSubCateg.GetAllSubCategories().GroupBy(x=>x.CategoryId).Select(g => new { Name = g.Key, Count = g.Count() });
            var disponibilite = matchservice.GetAll().GroupBy(x => x.idComp).ToList();

            //je vais faire le stat des valeur qui existe dans fvm
            List<competition> fVM = new List<competition>();


            int[] CounSubCateg = new int[disponibilite.Count()];
            string[] nameCat = new string[disponibilite.Count()];
            int i = 0;
            foreach (var group in disponibilite) //parcourir liste des subCateg et compter
            {

                int compteur = 0;
                foreach (var item in group)
                {
                    compteur++;
                }
                CounSubCateg[i] = compteur;

                var cat = service.GetById(group.Key.Value);
                nameCat[i] = cat.name;
                i++;
            }

            string myTheme =
               @"<Chart BackColor=""Transparent"">
            <ChartAreas> 
                    <ChartArea Name=""Default"" BackColor=""Transparent""></ChartArea>

            </ChartAreas>
            </Chart>";
            new Chart(width: 600, height: 600, theme: myTheme).AddTitle("Statistic of matchs  By competition")
                    .AddSeries(
                  //Transparent
                  //chartType: "pie",
                  chartType: "StackedColumn ",
                 // chartType: "StackedArea ",

                 xValue: nameCat,

                  yValues: CounSubCateg)


                  .Write("png");
            return null;
        }
    }

}
