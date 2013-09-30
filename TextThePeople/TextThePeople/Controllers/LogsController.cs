using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TextThePeople.Models;
using TextThePeople.DAL;

namespace TextThePeople.Controllers
{
    public class LogsController : Controller
    {
        private TextThePeopleContext db = new TextThePeopleContext();

        //
        // GET: /Logs/

        public ActionResult Index()
        {
            return View(db.Logs.ToList());
        }

        //
        // GET: /Logs/Details/5

        public ActionResult Details(int id = 0)
        {
            Logs logs = db.Logs.Find(id);
            if (logs == null)
            {
                return HttpNotFound();
            }
            return View(logs);
        }

   

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}