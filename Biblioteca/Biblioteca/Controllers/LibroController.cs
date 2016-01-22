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
    public class LibroController : Controller
    {
        private Contexto db = new Contexto();


        public JsonResult AjaxIndex(String strBuscado)
        {
            //var alumnos = db.alumnos.ToList();

            var libros = from Libro in db.Libros
                          where Libro.nombre.Contains(strBuscado)
                          select new
                          {
                              libroId = Libro.libroId,
                              nombre = Libro.nombre,
                              isbn = Libro.isbn,
                              autor = Libro.autor,
                              editorial = Libro.editorial,
                              año = Libro.año,
                              noEjemplares = Libro.noEjemplares
                          };

            return Json(libros, JsonRequestBehavior.AllowGet);
        }
        // GET: Libro
        public ActionResult Index()
        {
            return View(db.Libros.ToList());
        }

        // GET: Libro/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Libro libro = db.Libros.Find(id);
            if (libro == null)
            {
                return HttpNotFound();
            }
            return View(libro);
        }

        // GET: Libro/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Libro/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "libroId,nombre,isbn,autor,editorial,descripcion,año,noEjemplares")] Libro libro)
        {
            if (ModelState.IsValid)
            {
                db.Libros.Add(libro);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(libro);
        }

        // GET: Libro/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Libro libro = db.Libros.Find(id);
            if (libro == null)
            {
                return HttpNotFound();
            }
            return View(libro);
        }

        // POST: Libro/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "libroId,nombre,isbn,autor,editorial,descripcion,año,noEjemplares")] Libro libro)
        {
            if (ModelState.IsValid)
            {
                db.Entry(libro).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(libro);
        }
        [HttpGet]
        public JsonResult AjaxEdit(int libroId = 0)
        {
            /*Un objeto instanciado del modelo de datos*/
            Libro libro = db.Libros.Find(libroId);

            /*Necesito una instancia del modelo de vista*/
            //VMAlumno vmAlumno = new VMAlumno(alumno);

            //return Json(vmAlumno, JsonRequestBehavior.AllowGet);
            return Json(libro, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult AjaxEdit(Libro libro)
        {
            String mensaje = String.Empty;

            try
            {
                db.Entry(libro).State = EntityState.Modified;
                int c = db.SaveChanges();
                mensaje = "Se ha editado los datos del libro satisfactoriamente";
            }
            catch (Exception exc)
            {
                mensaje = "Hubo un error en el servidor: " + exc.Message;
            }


            return Json(new { mensaje = mensaje }, JsonRequestBehavior.AllowGet);
        }

        // GET: Libro/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Libro libro = db.Libros.Find(id);
            if (libro == null)
            {
                return HttpNotFound();
            }
            return View(libro);
        }

        // POST: Libro/Delete/5
        [HttpGet]
        public JsonResult DeleteConfirmed(int libroId=0)
        {
            String mensaje = String.Empty;
            try {
                Libro libro = db.Libros.Find(libroId);
                db.Libros.Remove(libro);
                db.SaveChanges();
                mensaje = "Se ha eliminado el libro satisfactoriamente";
            }
            catch (Exception exc)
            {
                mensaje = "Hubo un error en el servidor: " + exc.Message;
            }
            return Json(new { mensaje = mensaje }, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public JsonResult AjaxDelete(int libroId = 0)
        {
            /*Un objeto instanciado del modelo de datos*/
            Libro libro = db.Libros.Find(libroId);

            /*Necesito una instancia del modelo de vista*/
            //VMAlumno vmAlumno = new VMAlumno(alumno);

            //return Json(vmAlumno, JsonRequestBehavior.AllowGet);
            return Json(libro, JsonRequestBehavior.AllowGet);
        }



        [HttpPost]
        public JsonResult AjaxDelete(Libro libro)
        {
            String mensaje = String.Empty;


            try
            {
                db.Entry(libro).State = EntityState.Deleted;
                int c = db.SaveChanges();
                mensaje = "Se ha eliminado libro correctamente";
            }
            catch (Exception exc)
            {
                mensaje = "Hubo un error en el servidor: " + exc.Message;


            }


            //return Json(new { mensaje = mensaje }, JsonRequestBehavior.AllowGet);

            return Json("Response from Delete", JsonRequestBehavior.AllowGet);








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
