using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Twilio;

namespace TextThePeople.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            ViewBag.Message = "Modify this template to jump-start your ASP.NET MVC application.";

            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your app description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public ActionResult SendTwilioMessage(string messageBody) 
        {
            string from = "+13059096944"; // Twilio phone number

            var phones = new Dictionary<string, string>() 
            {
                {"Laura", "+19545017907"},
                {"Adrian", "+13052153501"},
                {"Jon", "+19545592101"},
                {"Rene", "+13059722588"},
            };

            var accountSid = "AC3c18b86d6c4941dc9ea2c15f090f6d03";
            var authToken = "3a401907393636c13902e6ef930a0e76";
            var twilioClient = new TwilioRestClient(accountSid, authToken);

            foreach (var p in phones)
            {
                var name = p.Key;
                var to = phones[name];
                twilioClient.SendMessage(from, to, messageBody, new string[0]);
            }

            return RedirectToAction("Index");
        }
    }
}
