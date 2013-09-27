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
    public class PersonsController : Controller
    {
        private TextThePeopleContext db = new TextThePeopleContext();

        //
        // GET: /Persons/

        public ActionResult Index()
        {
            return View(db.Persons.ToList());
        }

        //
        // GET: /Persons/Details/5

        public ActionResult Details(int id = 0)
        {
            Persons persons = db.Persons.Find(id);
            if (persons == null)
            {
                return HttpNotFound();
            }
            return View(persons);
        }

        //
        // GET: /Persons/Create

        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /Persons/Create

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Persons persons)
        {
            if (ModelState.IsValid)
            {
                db.Persons.Add(persons);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(persons);
        }

        //
        // GET: /Persons/Edit/5

        public ActionResult Edit(int id = 0)
        {
            Persons persons = db.Persons.Find(id);
            if (persons == null)
            {
                return HttpNotFound();
            }
            return View(persons);
        }

        //
        // POST: /Persons/Edit/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit( Persons persons)
        {
            if (ModelState.IsValid)
            {
                db.Entry(persons).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(persons);
        }

        //
        // GET: /Persons/Delete/5

        public ActionResult Delete(int id = 0)
        {
            Persons persons = db.Persons.Find(id);
            if (persons == null)
            {
                return HttpNotFound();
            }
            return View(persons);
        }

        //
        // POST: /Persons/Delete/5

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Persons persons = db.Persons.Find(id);
            db.Persons.Remove(persons);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}