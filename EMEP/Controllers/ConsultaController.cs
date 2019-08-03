using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using EMEP.Models;

namespace EMEP.Controllers
{
    public class ConsultaController : Controller
    {
        private EMEPEntities db = new EMEPEntities();

        // GET: Consulta
        public ActionResult Index()
        {
            var consulta = db.Consulta.Include(c => c.Consultorio).Include(c => c.Especialidad).Include(c => c.Medico);
            return View(consulta.ToList());
        }

        // GET: Consulta/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Consulta consulta = db.Consulta.Find(id);
            if (consulta == null)
            {
                return HttpNotFound();
            }
            return View(consulta);
        }

        // GET: Consulta/Create
        public ActionResult Create()
        {
            ViewBag.listaConsultorio = new SelectList(db.Consultorio, "id", "descripcion");
            ViewBag.listaEspecialidad = new SelectList(db.Especialidad, "id", "descripcion");
            ViewBag.listaMedicos = new SelectList(db.Medico, "id", "NombreCompletoM");
            return View();
        }

        // POST: Consulta/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,ID_MEDICO,ID_CONSULTORIO,precio,ID_ESPECIALIDAD")] Consulta consulta)
        {
            if (ModelState.IsValid)
            {
                db.Consulta.Add(consulta);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ID_CONSULTORIO = new SelectList(db.Consultorio, "id", "descripcion", consulta.ID_CONSULTORIO);
            ViewBag.ID_ESPECIALIDAD = new SelectList(db.Especialidad, "id", "descripcion", consulta.ID_ESPECIALIDAD);
            ViewBag.ID_MEDICO = new SelectList(db.Medico, "id", "correo", consulta.ID_MEDICO);
            return View(consulta);
        }

        // GET: Consulta/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Consulta consulta = db.Consulta.Find(id);
            if (consulta == null)
            {
                return HttpNotFound();
            }
            ViewBag.ID_CONSULTORIO = new SelectList(db.Consultorio, "id", "descripcion", consulta.ID_CONSULTORIO);
            ViewBag.ID_ESPECIALIDAD = new SelectList(db.Especialidad, "id", "descripcion", consulta.ID_ESPECIALIDAD);
            ViewBag.ID_MEDICO = new SelectList(db.Medico, "id", "correo", consulta.ID_MEDICO);
            return View(consulta);
        }

        // POST: Consulta/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,ID_MEDICO,ID_CONSULTORIO,precio,ID_ESPECIALIDAD")] Consulta consulta)
        {
            if (ModelState.IsValid)
            {
                db.Entry(consulta).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ID_CONSULTORIO = new SelectList(db.Consultorio, "id", "descripcion", consulta.ID_CONSULTORIO);
            ViewBag.ID_ESPECIALIDAD = new SelectList(db.Especialidad, "id", "descripcion", consulta.ID_ESPECIALIDAD);
            ViewBag.ID_MEDICO = new SelectList(db.Medico, "id", "correo", consulta.ID_MEDICO);
            return View(consulta);
        }

        // GET: Consulta/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Consulta consulta = db.Consulta.Find(id);
            if (consulta == null)
            {
                return HttpNotFound();
            }
            return View(consulta);
        }

        // POST: Consulta/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Consulta consulta = db.Consulta.Find(id);
            db.Consulta.Remove(consulta);
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
