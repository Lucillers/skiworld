using SkiWorld.Data.Models;
using SkiWorld.Service;
using SkiWorld.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SkiWorld.MVC.Controllers
{
    public class ProductController : Controller
    {

        ProductService ps = null;

        CategoryService serviceCategory = null;

        //  ProductService pss = new ProductService();


        public ProductController()
        {
            ps = new ProductService();
            serviceCategory = new CategoryService();

        }

        // GET: Product
        public ActionResult Index()
        {
            var x = ps.GetAll();
            return View(x);
        }

        //POST : Product
        [HttpPost]
        public ActionResult Index(String research)
        {
            if (!String.IsNullOrEmpty(research))
            {
                var input = ps.GetAll().Where(x => x.category.name.Contains(research) || x.name.Contains(research));
                return View(input);
            }
            return View();
        }

        // GET: Product/Details/5
        public ActionResult Details(int id)
        {
            return View(ps.GetById(id));
        }

        // GET: Product/Create
        public ActionResult Create()
        {
            IEnumerable<category> liste = serviceCategory.GetAll();
            SelectList selectlist = new SelectList(liste, "idCategory", "name");
            ViewBag.Categ = selectlist;
            //return RedirectToAction("Index");
            return View();

        }

        // POST: Product/Create
        [HttpPost]
        public ActionResult Create(product product)
        {
            //ProductService ps = new ProductService();
            //ps.Add(product);
            //ps.Commit();
            //return RedirectToAction("Index");





            product p = new product
            {
                name = product.name,
                idProduct = product.idProduct,
                isAvailable = product.isAvailable,
                price = product.price,
                quantity = product.quantity,
                idCategory= product.idCategory,
              //  category  = product.c,
                //  product.category.idCategory. = category.idCategory,



            };

            if (ModelState.IsValid)
            {
                ps.Add(p);
                ps.Commit();

            }

            return RedirectToAction("Index");



        }

        // GET: Product/Edit/5
        public ActionResult Edit(int id)
        {
            IEnumerable<category> liste1 = serviceCategory.GetAll();
            SelectList selectlist = new SelectList(liste1, "idCategory", "name");
            ViewBag.Categ = selectlist;
            product p = ps.GetById(id);
            product pp= new product
            {
               
            name = p.name,
                price = p.price,
                isAvailable = p.isAvailable,
                quantity =p.quantity,
             //   category = p.category,
                idCategory = p.idCategory,
                


            };

            return View(pp);

            
           
       


        }

        // POST: Product/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, product product)
        {
            product p = ps.GetById(id);
            p.name = product.name;
           p.price = product.price;
            p.isAvailable = product.isAvailable;
            p.quantity = product.quantity;
              p.idCategory = product.idCategory;

            ps.Update(p);
            ps.Commit();
            return RedirectToAction("Index");

        }

        // GET: Product/Delete/5
        public ActionResult Delete(int id)
        {
            return View(ps.GetById(id));
        }

        // POST: Product/Delete/5
       
        [HttpPost, ActionName("Delete")]

        public ActionResult Delete(int id, product product)
       
        {

            if (ModelState.IsValid)

            {

                product = ps.GetById(id);
                ps.Delete(product);
                ps.Commit();
            }
            return RedirectToAction("Index");
        }


        public ActionResult Chart()
        {
            IEnumerable<product> products = ps.GetAll();
           // List<category> categories = serviceCategory.getCategories();
            IEnumerable<category> categories = serviceCategory.GetAll();
            List<String> noms = new List<String>();
            List<int> nb = new List<int>();
            foreach (category u in categories)
            {
                noms.Add(u.name);
                nb.Add(serviceCategory.countByCategory(u.idCategory));
            }

            // int[] products
            new System.Web.Helpers.Chart(width: 800, height: 400)
            .AddTitle("Product Per Category")
            .AddSeries("Default", chartType: "column",
             xValue: noms, xField: "Category Name",
             yValues: nb, yFields: "products").Write("png");
            return null;

        }


        public ActionResult PieChart()
        {
            IEnumerable<product> products = ps.GetAll();
            // List<category> categories = serviceCategory.getCategories();
            IEnumerable<category> categories = serviceCategory.GetAll();
            List<String> noms = new List<String>();
            List<int> nb = new List<int>();
            foreach (category u in categories)
            {
                noms.Add(u.name);
                nb.Add(serviceCategory.countByCategory(u.idCategory));
            }

            // int[] products
            new System.Web.Helpers.Chart(width: 600, height: 600 )
            .AddTitle("Product Per Category")
            .AddSeries("Default", chartType: "pie",
           
             xValue: noms, xField: "Category Name",
             yValues: nb, yFields: "products").Write("png");
            return null;

        }
    }
}
