using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.IO;
using SkiWorld.MVC.Models;

namespace SkiWorld.MVC.Controllers
{
    public class TestController : Controller
    {
        public ActionResult Index()
        {

            return View();
        }


        public JsonResult ImageUpload(ProductViewModel model)
        {

            var file = model.ImageFile;

            if (file != null)
            {

                var fileName = Path.GetFileName(file.FileName);
                var extention = Path.GetExtension(file.FileName);
                var filenamewithoutextension = Path.GetFileNameWithoutExtension(file.FileName);

                file.SaveAs(Server.MapPath("/UploadedImage/" + file.FileName));


            }

            return Json(file.FileName, JsonRequestBehavior.AllowGet);

        }
    }
}