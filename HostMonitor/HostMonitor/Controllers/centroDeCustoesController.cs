using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using HostMonitor.Models;

namespace HostMonitor.Controllers
{
    public class centroDeCustoesController : Controller
    {
        private HostMonitorContext db = new HostMonitorContext();

        // GET: centroDeCustoes
        public ActionResult Index()
        {
            return View(db.centroDeCustoes.ToList());
        }

        // GET: centroDeCustoes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            centroDeCusto centroDeCusto = db.centroDeCustoes.Find(id);
            if (centroDeCusto == null)
            {
                return HttpNotFound();
            }
            return View(centroDeCusto);
        }

        // GET: centroDeCustoes/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: centroDeCustoes/Create
        // Para se proteger de mais ataques, ative as propriedades específicas a que você quer se conectar. Para 
        // obter mais detalhes, consulte https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ccId,ccName,ccIdentity,ccDescription,ccState,ccCity,ccPostalCode,ccRegion,ccNumber,ccSubGroup")] centroDeCusto centroDeCusto)
        {
            if (ModelState.IsValid)
            {
                db.centroDeCustoes.Add(centroDeCusto);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(centroDeCusto);
        }

        // GET: centroDeCustoes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            centroDeCusto centroDeCusto = db.centroDeCustoes.Find(id);
            if (centroDeCusto == null)
            {
                return HttpNotFound();
            }
            return View(centroDeCusto);
        }

        // POST: centroDeCustoes/Edit/5
        // Para se proteger de mais ataques, ative as propriedades específicas a que você quer se conectar. Para 
        // obter mais detalhes, consulte https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ccId,ccName,ccIdentity,ccDescription,ccState,ccCity,ccPostalCode,ccRegion,ccNumber,ccSubGroup")] centroDeCusto centroDeCusto)
        {
            if (ModelState.IsValid)
            {
                db.Entry(centroDeCusto).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(centroDeCusto);
        }

        // GET: centroDeCustoes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            centroDeCusto centroDeCusto = db.centroDeCustoes.Find(id);
            if (centroDeCusto == null)
            {
                return HttpNotFound();
            }
            return View(centroDeCusto);
        }

        // POST: centroDeCustoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            centroDeCusto centroDeCusto = db.centroDeCustoes.Find(id);
            db.centroDeCustoes.Remove(centroDeCusto);
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
