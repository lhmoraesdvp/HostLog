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
    public class SubGroupsController : Controller
    {
        private Db db = new Db();

        // GET: SubGroups
        [Authorize(Roles = "administrador")]
        public ActionResult Index()
        {
            return View(db.SubGroup.ToList());
        }

        // GET: SubGroups/Details/5
        [Authorize(Roles = "administrador")]
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SubGroup subGroup = db.SubGroup.Find(id);
            if (subGroup == null)
            {
                return HttpNotFound();
            }
            return View(subGroup);
        }

        // GET: SubGroups/Create
        [Authorize(Roles = "administrador")]
        public ActionResult Create()
        {
            return View();
        }

        // POST: SubGroups/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "subgId,subgroupName,subgroupDescription,subgroupIdentity,sGroup")] SubGroup subGroup)
        {
            if (ModelState.IsValid)
            {
                db.SubGroup.Add(subGroup);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(subGroup);
        }

        // GET: SubGroups/Edit/5
        [Authorize(Roles = "administrador")]
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SubGroup subGroup = db.SubGroup.Find(id);
            if (subGroup == null)
            {
                return HttpNotFound();
            }
            return View(subGroup);
        }

        // POST: SubGroups/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "subgId,subgroupName,subgroupDescription,subgroupIdentity,sGroup")] SubGroup subGroup)
        {
            if (ModelState.IsValid)
            {
                db.Entry(subGroup).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(subGroup);
        }

        // GET: SubGroups/Delete/5
        [Authorize(Roles = "administrador")]
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SubGroup subGroup = db.SubGroup.Find(id);
            if (subGroup == null)
            {
                return HttpNotFound();
            }
            return View(subGroup);
        }

        // POST: SubGroups/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            SubGroup subGroup = db.SubGroup.Find(id);
            db.SubGroup.Remove(subGroup);
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
