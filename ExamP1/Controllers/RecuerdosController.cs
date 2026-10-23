using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using ExamP1.Models;

namespace ExamP1.Controllers
{
    public class RecuerdosController : Controller
    {
        private VisionQuestContext db = new VisionQuestContext();

        // GET: Recuerdoes
        public ActionResult Index()
        {
            var recuerdos = db.recuerdos.Include(r => r.sintezoide);
            return View(recuerdos.ToList());
        }

        // GET: Recuerdoes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Recuerdo recuerdo = db.recuerdos.Find(id);
            if (recuerdo == null)
            {
                return HttpNotFound();
            }
            return View(recuerdo);
        }

        // GET: Recuerdoes/Create
        public ActionResult Create()
        {
            ViewBag.SintezoideId = new SelectList(db.sintezoides, "Id", "Nombre");
            return View();
        }

        // POST: Recuerdoes/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,TituloRecuerdo,TipoRecuerdo,Claridad,SintezoideId")] Recuerdo recuerdo)
        {
            if (ModelState.IsValid)
            {
                db.recuerdos.Add(recuerdo);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.SintezoideId = new SelectList(db.sintezoides, "Id", "Nombre", recuerdo.SintezoideId);
            return View(recuerdo);
        }

        // GET: Recuerdoes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Recuerdo recuerdo = db.recuerdos.Find(id);
            if (recuerdo == null)
            {
                return HttpNotFound();
            }
            ViewBag.SintezoideId = new SelectList(db.sintezoides, "Id", "Nombre", recuerdo.SintezoideId);
            return View(recuerdo);
        }

        // POST: Recuerdoes/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,TituloRecuerdo,TipoRecuerdo,Claridad,SintezoideId")] Recuerdo recuerdo)
        {
            if (ModelState.IsValid)
            {
                db.Entry(recuerdo).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.SintezoideId = new SelectList(db.sintezoides, "Id", "Nombre", recuerdo.SintezoideId);
            return View(recuerdo);
        }

        // GET: Recuerdoes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Recuerdo recuerdo = db.recuerdos.Find(id);
            if (recuerdo == null)
            {
                return HttpNotFound();
            }
            return View(recuerdo);
        }

        // POST: Recuerdoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Recuerdo recuerdo = db.recuerdos.Find(id);
            db.recuerdos.Remove(recuerdo);
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
