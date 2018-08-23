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
        private Db db = new Db();

        // GET: centroDeCustoes
        [Authorize(Roles = "administrador")]
        public ActionResult Index()
        {
            return View(db.centroDeCusto.ToList());
        }

        // GET: centroDeCustoes/Details/5
        [Authorize(Roles = "administrador")]
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            centroDeCusto centroDeCusto = db.centroDeCusto.Find(id);
            if (centroDeCusto == null)
            {
                return HttpNotFound();
            }
            return View(centroDeCusto);
        }

        // GET: centroDeCustoes/Create
        [Authorize(Roles = "administrador")]
        public ActionResult Create()
        {
            return View();
        }

        // POST: centroDeCustoes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ccId,ccName,ccIdentity,ccDescription,ccState,ccCity,ccPostalCode,ccRegion,ccNumber,ccSubGroup")] centroDeCusto centroDeCusto)
        {
            if (ModelState.IsValid)
            {
                db.centroDeCusto.Add(centroDeCusto);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(centroDeCusto);
        }

        // GET: centroDeCustoes/Edit/5
        [Authorize(Roles = "administrador")]
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            centroDeCusto centroDeCusto = db.centroDeCusto.Find(id);
            if (centroDeCusto == null)
            {
                return HttpNotFound();
            }
            return View(centroDeCusto);
        }

        // POST: centroDeCustoes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
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
        [Authorize(Roles = "administrador")]
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            centroDeCusto centroDeCusto = db.centroDeCusto.Find(id);
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
            centroDeCusto centroDeCusto = db.centroDeCusto.Find(id);
            db.centroDeCusto.Remove(centroDeCusto);
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
