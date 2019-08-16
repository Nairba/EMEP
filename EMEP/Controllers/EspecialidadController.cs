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
    public class EspecialidadController : Controller
    {
        private EMEPEntities db = new EMEPEntities();

        public ActionResult Index(string dato, string buscar, string filtro, int? page)
        {
            if (TempData.ContainsKey("mensaje"))
            {
                ViewBag.Mensaje = TempData["mensaje"].ToString();
            }

            ViewBag.actual = dato;

            ViewBag.Descripcion1 = dato == "Descripcion" ? "des" : "Descripcion";

            if (buscar != null)
            {
                page = 1;
            }
            else
            {
                buscar = filtro;
            }

            ViewBag.filtroActual = buscar;

            var especialidad = from es in db.Especialidad
                               select es;

            if (!string.IsNullOrEmpty(buscar))
            {
                especialidad = especialidad.Where(es => es.descripcion.Contains(buscar));
            }


            switch (dato)
            {

                case "des":
                    especialidad = especialidad.OrderByDescending(es => es.descripcion);
                    break;
                default:
                    especialidad = especialidad.OrderBy(es => es.descripcion);
                    break;
            }

            int pageSize = 3;
            int pageNumber = (page ?? 1);

            return View(especialidad.ToPagedList(pageNumber, pageSize));
        }

        // GET: Especialidad/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                TempData["mensaje"] = "Especifique la Especialidad";
                return RedirectToAction("Index");
            }
            Especialidad especialidad = db.Especialidad.Find(id);
            if (especialidad == null)
            {
                TempData["mensaje"] = "No existe la Especialidad";
                return RedirectToAction("Index");
            }
            return View("Details", especialidad);
        }

        // GET: Especialidad/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Especialidad/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Models.Especialidad objEspe)
        {
            if (TempData.ContainsKey("mensaje"))
            {
                ViewBag.Mensaje = TempData["mensaje"].ToString();
            }

            try
            {
                db.Especialidad.Add(objEspe);
                db.SaveChanges();
                TempData["mensaje"] = "Especialidad guardado satisfactoriamente!";
                return RedirectToAction("Index");
            }
            catch
            {
                TempData["mensaje"] = "Especilaidad NO registrado";
                return View();
            }

            if (ModelState.IsValid)
            {
                db.Especialidad.Add(objEspe);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(objEspe);
        }

        // GET: Especialidad/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                TempData["mensaje"] = "Especifique una Especialidad";
                return RedirectToAction("Index");
            }
            Especialidad especialidad = db.Especialidad.Find(id);
            if (especialidad == null)
            {
                TempData["mensaje"] = "No existe la Especialidad";
                return RedirectToAction("Index");
            }
            return View(especialidad);
        }

        // POST: Especialidad/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Models.Especialidad objEsp)
        {
            if (TempData.ContainsKey("mensaje"))
            {
                ViewBag.Mensaje = TempData["mensaje"].ToString();
            }

            try
            {
                db.Entry(objEsp).State = EntityState.Modified;
                db.SaveChanges();

                TempData["mensaje"] = "Especialidad actualizado satisfactoriamente!";
                return RedirectToAction("Index");
            }
            catch
            {

                TempData["mensaje"] = "La Especilaidad no se logro actualizar";
                return View();
            }


        }

        // GET: Especialidad/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Especialidad especialidad = db.Especialidad.Find(id);
            if (especialidad == null)
            {
                return HttpNotFound();
            }
            return View(especialidad);
        }

        // POST: Especialidad/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Especialidad especialidad = db.Especialidad.Find(id);
            db.Especialidad.Remove(especialidad);
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
