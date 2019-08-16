using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using EMEP.Models;
using PagedList;


namespace EMEP.Controllers
{
    public class ConsultaController : Controller
    {
        private EMEPEntities db = new EMEPEntities();

        // GET: Consulta
        public ActionResult Index(string dato, string buscar, string filtro, int? page)
        {
            ViewBag.actual = dato;
            ViewBag.Medico1 = string.IsNullOrEmpty(dato) ? "medico" : "";
            ViewBag.Espe1 = dato == "Especialidad" ? "esp" : "Especialidad";

            if (buscar != null)
            {
                page = 1;
            }
            else
            {
                buscar = filtro;
            }

            ViewBag.filtroActual = buscar;

            var consulta = from co in db.Consulta
                           select co;
            if (!string.IsNullOrEmpty(buscar))
            {
                consulta = consulta.Where(co => co.Medico.nombre.Contains(buscar)
               || co.Medico.nombre.Contains(buscar)
               || co.Medico.p_Apellido.Contains(buscar)
               || co.Medico.s_Apellido.Contains(buscar)
               || co.Especialidad.descripcion.Contains(buscar)
               || co.Consultorio.numero.Contains(buscar)
               || co.precio.ToString().Contains(buscar));
            }

            switch (dato)
            {
                case "medico":
                    consulta = consulta.OrderByDescending(co => co.Medico.nombre);
                    break;
                case "Especialidad":
                    consulta = consulta.OrderBy(co => co.Especialidad.descripcion);
                    break;
                case "esp":
                    consulta = consulta.OrderByDescending(co => co.Especialidad.descripcion);
                    break;
                default:
                    consulta = consulta.OrderBy(co => co.Medico.nombre);
                    break;
            }

            int pageSize = 3;
            int pageNumber = (page ?? 1);
            return View(consulta.ToPagedList(pageNumber, pageSize));
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

            ViewBag.listaConsultorio = new SelectList(db.Consultorio, "id", "descripcion");
            ViewBag.listaEspecialidad = new SelectList(db.Especialidad, "id", "descripcion");
            ViewBag.listaMedicos = new SelectList(db.Medico, "id", "NombreCompletoM");
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
            ViewBag.listaConsultorio = new SelectList(db.Consultorio, "id", "descripcion");
            ViewBag.listaEspecialidad = new SelectList(db.Especialidad, "id", "descripcion");
            ViewBag.listaMedicos = new SelectList(db.Medico, "id", "NombreCompletoM");
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
            ViewBag.listaConsultorio = new SelectList(db.Consultorio, "id", "descripcion");
            ViewBag.listaEspecialidad = new SelectList(db.Especialidad, "id", "descripcion");
            ViewBag.listaMedicos = new SelectList(db.Medico, "id", "NombreCompletoM");
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