using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Biblioteca.DAL;
using Biblioteca.Models;

namespace Biblioteca.Controllers
{
    public class EjemplarController : Controller
    {
        private Contexto db = new Contexto();

        // GET: Ejemplar
        public ActionResult Index()
        {
            return View(db.Ejemplares.ToList());
        }

        // GET: Ejemplar/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Ejemplar ejemplar = db.Ejemplares.Find(id);
            if (ejemplar == null)
            {
                return HttpNotFound();
            }
            return View(ejemplar);
        }

        // GET: Ejemplar/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Ejemplar/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "idEjemplar,nombreLibro")] Ejemplar ejemplar)
        {
            if (ModelState.IsValid)
            {
                db.Ejemplares.Add(ejemplar);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(ejemplar);
        }

        // GET: Ejemplar/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Ejemplar ejemplar = db.Ejemplares.Find(id);
            if (ejemplar == null)
            {
                return HttpNotFound();
            }
            return View(ejemplar);
        }

        // POST: Ejemplar/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "idEjemplar,nombreLibro")] Ejemplar ejemplar)
        {
            if (ModelState.IsValid)
            {
                db.Entry(ejemplar).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(ejemplar);
        }

        // GET: Ejemplar/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Ejemplar ejemplar = db.Ejemplares.Find(id);
            if (ejemplar == null)
            {
                return HttpNotFound();
            }
            return View(ejemplar);
        }

        // POST: Ejemplar/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Ejemplar ejemplar = db.Ejemplares.Find(id);
            db.Ejemplares.Remove(ejemplar);
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
