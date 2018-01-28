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
    public class WykładowcaController : Controller
    {
        private DziennikContext db = new DziennikContext();

        // GET: /Wykładowca/
        public ActionResult Index()
        {
            return View(db.Wykładowcy.ToList());
        }

        // GET: /Wykładowca/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Wykładowca wykładowca = db.Wykładowcy.Find(id);
            if (wykładowca == null)
            {
                return HttpNotFound();
            }
            return View(wykładowca);
        }

        // GET: /Wykładowca/Create
        [Authorize(Roles="Admin")]
        public ActionResult Create()
        {
            return View();
        }

        // POST: /Wykładowca/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include="ID,Imię,Nazwisko")] Wykładowca wykładowca)
        {
            if (ModelState.IsValid)
            {
                db.Wykładowcy.Add(wykładowca);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(wykładowca);
        }

        // GET: /Wykładowca/Edit/5
        [Authorize(Roles = "Admin")]
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Wykładowca wykładowca = db.Wykładowcy.Find(id);
            if (wykładowca == null)
            {
                return HttpNotFound();
            }
            return View(wykładowca);
        }

        // POST: /Wykładowca/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include="ID,Imię,Nazwisko")] Wykładowca wykładowca)
        {
            if (ModelState.IsValid)
            {
                db.Entry(wykładowca).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(wykładowca);
        }

        // GET: /Wykładowca/Delete/5
        [Authorize(Roles = "Admin")]
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Wykładowca wykładowca = db.Wykładowcy.Find(id);
            if (wykładowca == null)
            {
                return HttpNotFound();
            }
            return View(wykładowca);
        }

        // POST: /Wykładowca/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Wykładowca wykładowca = db.Wykładowcy.Find(id);
            db.Wykładowcy.Remove(wykładowca);
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
