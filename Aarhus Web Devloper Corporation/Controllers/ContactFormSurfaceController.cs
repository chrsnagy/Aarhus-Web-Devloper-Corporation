using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Umbraco.Web.Mvc;
using Umbraco.Core.Models;
using Aarhus_Web_Devloper_Corporation.ViewModels;
using System.Net.Mail;

namespace Aarhus_Web_Devloper_Corporation.Controllers
{
    public class ContactFormSurfaceController : SurfaceController
    {
        // GET: ContactFormSurface
        public ActionResult Index()
        {
            return PartialView("ContactForm", new ContactForm());
        }

        [HttpPost]
        public ActionResult HandleFormSubmit(ContactForm model)
        {
            if (ModelState.IsValid)
            {
                IContent comment = Services.ContentService.CreateContent(model.Subject, CurrentPage.Id, "Message");
                comment.SetValue("messagename", model.Name);
                comment.SetValue("email", model.Email);
                comment.SetValue("subject", model.Subject);
                comment.SetValue("messageContent", model.Message);
                Services.ContentService.Save(comment);
                MailMessage message = new MailMessage();
                message.To.Add("stanislavangelov1995@gmail.com");
                message.Subject = model.Subject;
                message.From = new MailAddress(model.Email, model.Name);
                message.Body = model.Message;
                // <--- no need to send email since already saves as document
                //using (SmtpClient smtp = new SmtpClient())
                //{
                //    smtp.DeliveryMethod = SmtpDeliveryMethod.Network;
                //    smtp.UseDefaultCredentials = false;
                //    smtp.EnableSsl = true;
                //    smtp.Host = "smtp.gmail.com";
                //    smtp.Port = 587;
                //    smtp.Credentials = new System.Net.NetworkCredential("stanislavangelov1995@@gmail.com", "");
                //    // send mail
                //    smtp.Send(message);
                //}
                TempData["success"] = true;
                return RedirectToCurrentUmbracoPage();
            }

            else
            {

                return CurrentUmbracoPage();
            }
        }
    }
}