using SkiWorld.Data.Models;
using SkiWorld.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SkiWorld.MVC.Controllers
{
    public class WorkerController : Controller
    {
        WorkerService ws = null;
        WorkerService wss = new WorkerService();


        public WorkerController()
        {
            ws = new WorkerService();
        }



        // GET: Worker
        public ActionResult Index()
        {
            var x = ws.GetAll();
            return View(x);
        }

        // GET: Worker/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Worker/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Worker/Create
        [HttpPost]
        public ActionResult Create(Worker work)
        {

            ws.Add(work);
            ws.Commit();

            return RedirectToAction("../Worker/create");

        }

        // GET: Worker/Edit/5
        public ActionResult Edit(int id)
        {
            Worker work = ws.GetById(id);
            Worker wk = new Worker
            {
                adress = work.adress,
                cin = work.cin,
                firstName = work.firstName,
                lastName = work.lastName,
                login = work.login,
                Email = work.Email,
                phone = work.phone,
                age = work.age,
                ExperienceWorker = work.ExperienceWorker,
                Speciality = work.Speciality,
                RegistrationNumber = work.RegistrationNumber

            };
            return View(work);
        }

        // POST: Worker/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, Worker worker)
        {
            Worker w = ws.GetById(id);
            w.adress = worker.adress;
            w.cin = worker.cin;
            w.Email = worker.Email;
            w.firstName = worker.firstName;
            w.lastName = worker.lastName;
            w.login = worker.login;
            w.phone = worker.phone;
            w.age = worker.age;
            w.ExperienceWorker = worker.ExperienceWorker;
            w.Speciality = worker.Speciality;
            w.RegistrationNumber = worker.RegistrationNumber;

            ws.Update(w);
            ws.Commit();
            return RedirectToAction("Index");

        }

        // GET: Worker/Delete/5
        public ActionResult Delete(int id)
        {

            return View(ws.GetById(id));
        }

        // POST: Worker/Delete/5
        [HttpPost, ActionName("Delete")]
        public ActionResult Delete(int id, Worker worker)
        {

            worker = ws.GetById(id);
            ws.Delete(worker);
            ws.Commit();

            return RedirectToAction("Index");
        }
    }
}
