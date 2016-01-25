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
    public class UsuarioController : Controller
    {
        private Contexto db = new Contexto();


        public JsonResult AjaxIndex(String strBuscado)
        {
            //var alumnos = db.alumnos.ToList();

            var Usuarios = from usuario in db.usuarios
                         where usuario.nombre.Contains(strBuscado)
                         select new
                         {
                             usuarioId = usuario.usuarioID,
                             nombre = usuario.nombre,
                             apellido = usuario.apellido,
                             telefono = usuario.Telefono,
                             correo = usuario.correo,
                             direccion = usuario.direccion,
                             curp= usuario.curp
                            
                         };

            return Json(Usuarios, JsonRequestBehavior.AllowGet);
        }

        // GET: Usuario
        public ActionResult Index()
        {
            return View(db.usuarios.ToList());
        }

        // GET: Usuario/Details/5
       
        public JsonResult Details(int? id)
        {
            /*Un objeto instanciado del modelo de datos*/
            Usuario USUARIO = db.usuarios.Find(id);

           

            //return Json(vmAlumno, JsonRequestBehavior.AllowGet);
            return Json(USUARIO, JsonRequestBehavior.AllowGet);
        }

        // GET: Usuario/Create
        public JsonResult Create(Usuario usuario)
        {
           
            String mensaje = String.Empty;

            try
            {
                if (ModelState.IsValid)
                {
                    db.usuarios.Add(usuario);
                    db.SaveChanges();
                   


                    mensaje = "Se ha registrado el usuario exitosamente woeee no mames";
                }
            }
            catch (Exception exc)
            {
                mensaje = "Hubo un error en el servidor: " + exc.Message;
            }
            return Json(new { mensaje = mensaje }, JsonRequestBehavior.AllowGet);
        }

        

        // GET: Usuario/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Usuario usuario = db.usuarios.Find(id);
            if (usuario == null)
            {
                return HttpNotFound();
            }
            return View(usuario);
        }

        // POST: Usuario/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "usuarioID,nombre,apellido,Telefono,correo,direccion,curp")] Usuario usuario)
        {
            if (ModelState.IsValid)
            {
                db.Entry(usuario).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(usuario);
        }

        [HttpGet]
        public JsonResult AjaxEdit(int Usuarioid = 0)
        {
            /*Un objeto instanciado del modelo de datos*/
            Usuario usuario = db.usuarios.Find(Usuarioid);

            /*Necesito una instancia del modelo de vista*/
            //VMAlumno vmAlumno = new VMAlumno(alumno);

            //return Json(vmAlumno, JsonRequestBehavior.AllowGet);
            return Json(Usuarioid, JsonRequestBehavior.AllowGet);
        }

        
       


        [HttpPost]
        public JsonResult AjaxEdit(Usuario usuario)
        {
            String mensaje = String.Empty;

            try
            {
                db.Entry(usuario).State = EntityState.Modified;
                int c = db.SaveChanges();
                mensaje = "Se ha editado los datos del libro satisfactoriamente";
            }
            catch (Exception exc)
            {
                mensaje = "Hubo un error en el servidor: " + exc.Message;
            }


            return Json(new { mensaje = mensaje }, JsonRequestBehavior.AllowGet);
        }
        [HttpGet]
        public JsonResult DeleteConfirmed(int? usuarioID = 0)
        {
            String mensaje = String.Empty;
            try
            {
                Usuario usuario = db.usuarios.Find(usuarioID);
                db.usuarios.Remove(usuario);
                db.SaveChanges();
                mensaje = "Se ha eliminado el libro satisfactoriamente";
            }
            catch (Exception exc)
            {
                mensaje = "Hubo un error en el servidor: " + exc.Message;
            }
            return Json(new { mensaje = mensaje }, JsonRequestBehavior.AllowGet);
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
