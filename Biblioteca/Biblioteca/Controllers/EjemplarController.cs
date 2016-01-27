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
        [HttpGet]
        public JsonResult AjaxIndex(String strBuscado)
        {
            //var alumnos = db.alumnos.ToList();

            var Ejemplares = from Ejemplar in db.ejemplares
                         where Ejemplar.nombreLibro.Contains(strBuscado)
                         select new
                         {
                             libroId = Ejemplar.idEjemplar,
                             nombre = Ejemplar.nombreLibro,
                             isbn = Ejemplar.libroId,
                            
                         };

            return Json(Ejemplares, JsonRequestBehavior.AllowGet);
        }
        // GET: Ejemplar
        public ActionResult Index()
        {
            return View(db.ejemplares.ToList());
        }

        // GET: Ejemplar/Details/5
        [HttpGet]
        public JsonResult Details(int? id)
        {
         
            Ejemplar ejemplar = db.ejemplares.Find(id);
           
            return Json(ejemplar, JsonRequestBehavior.AllowGet);
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
       // [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "idEjemplar,nombreLibro")] Ejemplar ejemplar)
        {
            if (ModelState.IsValid)
            {
                db.ejemplares.Add(ejemplar);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(ejemplar);
        }

        // GET: Ejemplar/Edit/5
        [HttpGet]
        public JsonResult AjaxEdit(int? id)
        {
            
            Ejemplar ejemplar = db.ejemplares.Find(id);
      
            return Json(ejemplar, JsonRequestBehavior.AllowGet);
        }
      
        // POST: Ejemplar/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
       
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
            Ejemplar ejemplar = db.ejemplares.Find(id);
            if (ejemplar == null)
            {
                return HttpNotFound();
            }
            return View(ejemplar);
        }

        // POST: Ejemplar/Delete/5
        [HttpGet]
        public JsonResult DeleteConfirmed(int id = 0)
        {
            String mensaje = String.Empty;
            try
            {
                Ejemplar ejemplar = db.ejemplares.Find(id);
                db.ejemplares.Remove(ejemplar);
                db.SaveChanges();
                mensaje = "Registro exitoso";
            }catch(Exception ajax)
            {
                mensaje = "Hubo un problema al intentar acceder a la base de datos: "+ ajax.Message;
            }
            
            
            return Json(new { mensaje = mensaje  }, JsonRequestBehavior.AllowGet);
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
