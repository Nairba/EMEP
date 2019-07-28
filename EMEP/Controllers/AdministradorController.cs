using EMEP.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace EMEP.Controllers
{
    public class AdministradorController : Controller
    {
        private EMEPEntities db = new EMEPEntities();
        // GET: Administrador
        public ActionResult Index()
        {
            var administrador = db.Administrador.Include(a => a.Tipo_Usuario);
            foreach (var item in administrador)
            {
                if (item.estado == 1)
                {

                    item.estado_String = "Activo";
                }
                if (item.estado == 2)
                {

                    item.estado_String = "Inactivo";
                }
            }
            return View(administrador.ToList());
        }

        // GET: Administrador/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Administrador administrador = db.Administrador.Find(id);
            if (administrador.estado == 1)
            {

                administrador.estado_String = "Activo";
            }
            if (administrador.estado == 2)
            {

                administrador.estado_String = "Inactivo";
            }
            if (administrador == null)
            {
                return HttpNotFound();
            }
            return View(administrador);
        }

        // GET: Administrador/Create
        public ActionResult Create()
        {
            ViewBag.ID_TIPO_USUARIO = new SelectList(db.Tipo_Usuario, "id", "descripcion");
            return View();
        }

        // POST: Administrador/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Administrador administrador)
        {
            if (administrador.estad)
            {

                administrador.estado = 1;
            }
            else
            {

                administrador.estado = 2;
            }
            if (ModelState.IsValid)
            {
                db.Administrador.Add(administrador);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ID_TIPO_USUARIO = new SelectList(db.Tipo_Usuario, "id", "descripcion", administrador.ID_TIPO_USUARIO);
            return View(administrador);
        }

        // GET: Administrador/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Administrador administrador = db.Administrador.Find(id);
            if (administrador == null)
            {
                return HttpNotFound();
            }
            ViewBag.ID_TIPO_USUARIO = new SelectList(db.Tipo_Usuario, "id", "descripcion", administrador.ID_TIPO_USUARIO);
            return View(administrador);
        }

        // POST: Administrador/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Administrador administrador)
        {
            if (administrador.estad)
            {
                administrador.estado = 1;
            }
            else
            {
                administrador.estado = 2;
            }
            if (ModelState.IsValid)
            {
                db.Entry(administrador).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ID_TIPO_USUARIO = new SelectList(db.Tipo_Usuario, "id", "descripcion", administrador.ID_TIPO_USUARIO);
            return View(administrador);
        }

        // GET: Administrador/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Administrador administrador = db.Administrador.Find(id);
            if (administrador == null)
            {
                return HttpNotFound();
            }
            return View(administrador);
        }

        // POST: Administrador/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Administrador administrador = db.Administrador.Find(id);
            db.Administrador.Remove(administrador);
            db.SaveChanges();
            return RedirectToAction("Index");
        }


        public ActionResult InicioSesion()
        {
            if (TempData.ContainsKey("mensaje"))
            {
                ViewBag.Mensaje = TempData["mensaje"].ToString();
            }
            return View();
        }
        [HttpPost]
        public ActionResult InicioSesion(Administrador ad)
        {
            string correo = ad.correo;
            string contrasenna = ad.contraseña;
            if (TempData.ContainsKey("mensaje"))
            {
                ViewBag.Mensaje = TempData["mensaje"].ToString();
            }
            try
            {
                using (EMEPEntities db = new EMEPEntities())
                {
                    var administradorDB = db.Administrador.Where(a => a.correo.Equals(correo) && a.contraseña.Equals(contrasenna)).FirstOrDefault();
                    var medicoDB = db.Medico.Where(a => a.correo.Equals(correo) && a.contrasenna.Equals(contrasenna)).FirstOrDefault();
                    var pacienteDB = db.Paciente.Where(a => a.correo.Equals(correo) && a.contrasenna.Equals(contrasenna) && a.estado == 1).FirstOrDefault();


                    if (administradorDB != null && administradorDB.estado == 1)
                    {
                        Session["CorreoId"] = administradorDB.correo.ToString();
                        Session["Nombre"] = administradorDB.correo.ToString();
                        TempData["mensaje"] = "Bienvenid@";
                        return RedirectToAction("IndexAd", "Home");
                    }
                    if (medicoDB != null && medicoDB.estado == 1)
                    {
                        Session["CorreoId"] = medicoDB.correo.ToString();
                        Session["Nombre"] = medicoDB.nombre.ToString();
                        TempData["mensaje"] = "Bienvenid@";
                        return RedirectToAction("IndexMed", "Home");
                    }
                    if (pacienteDB != null && pacienteDB.estado == 1)
                    {
                        Session["CorreoId"] = pacienteDB.correo.ToString();
                        Session["Nombre"] = pacienteDB.nombre.ToString();
                        TempData["mensaje"] = "Bienvenid@";
                        return RedirectToAction("IndexAC", "Home");
                    }
                }
                TempData["mensaje"] = "Datos invalidos, verifique";
                return View();
            }
            catch
            {
                TempData["mensaje"] = "Datos invalidos, verifique";
                return View(ad);
            }
        }
        
        public ActionResult LogOff()
        {
            Session.Clear();
            return RedirectToAction("Index", "Home");
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
