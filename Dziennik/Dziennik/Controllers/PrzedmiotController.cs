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
    public class PrzedmiotController : Controller
    {
        private DziennikContext db = new DziennikContext();

        // GET: /Przedmiot/
        public ActionResult Index()
        {
            var przedmioty = db.Przedmioty.Include(p => p.Wykładowca);
            return View(przedmioty.ToList());
        }

        // GET: /Przedmiot/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Przedmiot przedmiot = db.Przedmioty.Find(id);
            if (przedmiot == null)
            {
                return HttpNotFound();
            }
            return View(przedmiot);
        }

        // GET: /Przedmiot/Create
        [Authorize(Roles = "Admin")]
        public ActionResult Create()
        {
            ViewBag.WykładowcaID = new SelectList(db.Wykładowcy, "ID", "Nazwisko");
            return View();
        }

        // POST: /Przedmiot/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include="ID,WykładowcaID,Nazwa,Skrót,PunktyECTS")] Przedmiot przedmiot)
        {
            if (ModelState.IsValid)
            {
                db.Przedmioty.Add(przedmiot);
                db.SaveChanges();
                return RedirectToAction("Index");
            }


            ViewBag.WykładowcaID = new SelectList(db.Wykładowcy, "ID", "Nazwisko", przedmiot.WykładowcaID);
            return View(przedmiot);
        }

        // GET: /Przedmiot/Edit/5
        [Authorize(Roles = "Admin")]
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Przedmiot przedmiot = db.Przedmioty.Find(id);
            if (przedmiot == null)
            {
                return HttpNotFound();
            }
            ViewBag.WykładowcaID = new SelectList(db.Wykładowcy, "ID", "Nazwisko", przedmiot.WykładowcaID);
            return View(przedmiot);
        }

        // POST: /Przedmiot/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include="ID,WykładowcaID,Nazwa,Skrót,PunktyECTS")] Przedmiot przedmiot)
        {
            if (ModelState.IsValid)
            {
                db.Entry(przedmiot).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.WykładowcaID = new SelectList(db.Wykładowcy, "ID", "Nazwisko", przedmiot.WykładowcaID);
            return View(przedmiot);
        }

        // GET: /Przedmiot/Delete/5
        [Authorize(Roles = "Admin")]
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Przedmiot przedmiot = db.Przedmioty.Find(id);
            if (przedmiot == null)
            {
                return HttpNotFound();
            }
            return View(przedmiot);
        }

        // POST: /Przedmiot/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Przedmiot przedmiot = db.Przedmioty.Find(id);
            db.Przedmioty.Remove(przedmiot);
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
