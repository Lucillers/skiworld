using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SkiWorld.MVC.Controllers
{
    public class UploadFileController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        private bool isValidContentType(string contentType)
        {
            return contentType.Equals("image/png") || contentType.Equals("image/gif") ||
                contentType.Equals("image/jpg") || contentType.Equals("image/jpeg");
        }


        [HttpPost]
        public ActionResult Process(HttpPostedFileBase photo)
        {
            if (!isValidContentType(photo.ContentType))
            {
                ViewBag.Error = "Only JPG, PNG, GIF, JPEG files are allowed";
                return View("Index");
            }
            else
            {
                if (photo.ContentLength > 0)
                {
                    var fileName = Path.GetFileName(photo.FileName);
                    var path = Path.Combine(Server.MapPath("~/Content/Images"), fileName);
                    photo.SaveAs(path);
                    ViewBag.fileName = photo.FileName;
                }
            
            return View("Success");
            }
        }
    }
}