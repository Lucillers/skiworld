using SkiWorld.MVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Net.Mail;
using System.IO;
using System.Net;

namespace SkiWorld.MVC.Controllers
{
    public class SendMailerController : Controller
    {


        // GET: /SendMail/  
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public ViewResult Index(mail objModelMail, HttpPostedFileBase fileUploader)
        {
            if (ModelState.IsValid)

            {


                MailMessage mail = new MailMessage();
                mail.To.Add(objModelMail.To);
                mail.From = new MailAddress(objModelMail.From);
                mail.Subject = objModelMail.Subject;
                string Body = objModelMail.Body;
                String password = objModelMail.Password;
                mail.Body = Body;
                

                if (fileUploader != null)

                {

                    string fileName = Path.GetFileName(fileUploader.FileName);

                    mail.Attachments.Add(new Attachment(fileUploader.InputStream, fileName));

                }

                mail.IsBodyHtml = false;

                SmtpClient smtp = new SmtpClient();

                smtp.Host = "smtp.gmail.com";

                smtp.EnableSsl = true;

                NetworkCredential networkCredential = new NetworkCredential(mail.From.ToString(), password);

                smtp.UseDefaultCredentials = true;

                smtp.Credentials = networkCredential;

                smtp.Port = 587;

                smtp.Send(mail);

                ViewBag.Message = "Sent";

                return View("Index", objModelMail);



            }

            else
            {
                return View();
            }
        }


    }
}
