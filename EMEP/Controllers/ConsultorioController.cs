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
    public class ConsultorioController : Controller
    {
        private EMEPEntities db = new EMEPEntities();

        // GET: Consultorio
        public ActionResult Index(string dato, string buscar, string filtro, int? page)
        {
            ViewBag.actual = dato;
            ViewBag.Descripcion1 = string.IsNullOrEmpty(dato) ? "des" : "";
            ViewBag.Numero1 = dato == "Numero" ? "num" : "Numero";

            if (buscar!= null)
            {
                page = 1;
            }
            else
            {
                buscar = filtro;
            }

            ViewBag.filtroActual = buscar;

            var consultorio = from co in db.Consultorio
                              select co;

            if (!string.IsNullOrEmpty(buscar))
            {
                consultorio = consultorio.Where(co => co.descripcion.Contains(buscar)
                  || co.numero.Contains(buscar));
            }

            switch (dato)
            {
                case "des":
                    consultorio = consultorio.OrderByDescending(co => co.descripcion);
                    break;
                case "Numero":
                    consultorio = consultorio.OrderBy(co => co.numero);
                    break;
                case "num":
                    consultorio = consultorio.OrderByDescending(co => co.numero);
                    break;
                default:
                    consultorio = consultorio.OrderBy(co => co.descripcion);
                    break;
            }

            int pageSize = 3;
            int pageNumber = (page ?? 1);
            return View(consultorio.ToPagedList(pageNumber,pageSize));
        }

        // GET: Consultorio/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Consultorio consultorio = db.Consultorio.Find(id);
            if (consultorio == null)
            {
                return HttpNotFound();
            }
            return View(consultorio);
        }

        // GET: Consultorio/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Consultorio/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,descripcion,numero")] Consultorio consultorio)
        {
            if (ModelState.IsValid)
            {
                db.Consultorio.Add(consultorio);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(consultorio);
        }

        // GET: Consultorio/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Consultorio consultorio = db.Consultorio.Find(id);
            if (consultorio == null)
            {
                return HttpNotFound();
            }
            return View(consultorio);
        }

        // POST: Consultorio/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,descripcion,numero")] Consultorio consultorio)
        {
            if (ModelState.IsValid)
            {
                db.Entry(consultorio).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(consultorio);
        }

        // GET: Consultorio/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Consultorio consultorio = db.Consultorio.Find(id);
            if (consultorio == null)
            {
                return HttpNotFound();
            }
            return View(consultorio);
        }

        // POST: Consultorio/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Consultorio consultorio = db.Consultorio.Find(id);
            db.Consultorio.Remove(consultorio);
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
