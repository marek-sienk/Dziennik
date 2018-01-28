using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Dziennik.Models;
using Dziennik.DAL;

namespace Dziennik.Controllers
{
    public class WynikController : Controller
    {
        private DziennikContext db = new DziennikContext();

        // GET: /Wynik/
        public ActionResult Index()
        {
            var wyniki = db.Wyniki.Include(w => w.Przedmiot).Include(w => w.Student);
            return View(wyniki.ToList());
        }

        // GET: /Wynik/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Wynik wynik = db.Wyniki.Find(id);
            if (wynik == null)
            {
                return HttpNotFound();
            }
            return View(wynik);
        }

        // GET: /Wynik/Create
        [Authorize(Roles = "Admin, Wykładowca")]
        public ActionResult Create()
        {
            ViewBag.PrzedmiotID = new SelectList(db.Przedmioty, "ID", "Nazwa");
            ViewBag.StudentID = new SelectList(db.Studenci, "ID", "NrAlbumu");
            return View();
        }

        // POST: /Wynik/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include="ID,StudentID,PrzedmiotID,Ocena")] Wynik wynik)
        {
            //try
            //{
                if (ModelState.IsValid)
                {
                    db.Wyniki.Add(wynik);
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
                //}
                //catch (DataException /* dex */)
                //{
                //    //Log the error (uncomment dex variable name and add a line here to write a log.
                //    ModelState.AddModelError("", "Nie można zapisać danych. Spróbuj ponownie, jeżeli problem wystąpi ponownie skontaktuj się z administratorem.");
                //}

            ViewBag.PrzedmiotID = new SelectList(db.Przedmioty, "ID", "Nazwa", wynik.PrzedmiotID);
            ViewBag.StudentID = new SelectList(db.Studenci, "ID", "NrAlbumu", wynik.StudentID);
            return View(wynik);
        }

        // GET: /Wynik/Edit/5
        [Authorize(Roles = "Admin, Wykładowca")]
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Wynik wynik = db.Wyniki.Find(id);
            if (wynik == null)
            {
                return HttpNotFound();
            }
            ViewBag.PrzedmiotID = new SelectList(db.Przedmioty, "ID", "Nazwa", wynik.PrzedmiotID);
            ViewBag.StudentID = new SelectList(db.Studenci, "ID", "NrAlbumu", wynik.StudentID);
            return View(wynik);
        }

        // POST: /Wynik/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include="ID,StudentID,PrzedmiotID,Ocena")] Wynik wynik)
        {
            if (ModelState.IsValid)
            {
                db.Entry(wynik).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.PrzedmiotID = new SelectList(db.Przedmioty, "ID", "Nazwa", wynik.PrzedmiotID);
            ViewBag.StudentID = new SelectList(db.Studenci, "ID", "NrAlbumu", wynik.StudentID);
            return View(wynik);
        }

        // GET: /Wynik/Delete/5
        [Authorize(Roles = "Admin, Wykładowca")]
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Wynik wynik = db.Wyniki.Find(id);
            if (wynik == null)
            {
                return HttpNotFound();
            }
            return View(wynik);
        }

        // POST: /Wynik/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Wynik wynik = db.Wyniki.Find(id);
            db.Wyniki.Remove(wynik);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
