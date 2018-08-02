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
        private HostMonitorContext db = new HostMonitorContext();
       
        // GET: SubGroups
        public ActionResult Index()
        {
            
            return View(db.SubGroups.ToList());
        }

        // GET: SubGroups/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SubGroup subGroup = db.SubGroups.Find(id);
            if (subGroup == null)
            {
                return HttpNotFound();
            }
            return View(subGroup);
        }

        // GET: SubGroups/Create
        public ActionResult Create()
        {
       
            return View();
        }

        // POST: SubGroups/Create
        // Para se proteger de mais ataques, ative as propriedades específicas a que você quer se conectar. Para 
        // obter mais detalhes, consulte https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "subgId,subgroupName,subgroupDescription,subgroupIdentity,sGroup")] SubGroup subGroup)
        {

            if (ModelState.IsValid)
            {
                db.SubGroups.Add(subGroup);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
           

            return View(subGroup);
        }

        // GET: SubGroups/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SubGroup subGroup = db.SubGroups.Find(id);
            if (subGroup == null)
            {
                return HttpNotFound();
            }
            return View(subGroup);
        }

        // POST: SubGroups/Edit/5
        // Para se proteger de mais ataques, ative as propriedades específicas a que você quer se conectar. Para 
        // obter mais detalhes, consulte https://go.microsoft.com/fwlink/?LinkId=317598.
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
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SubGroup subGroup = db.SubGroups.Find(id);
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
            SubGroup subGroup = db.SubGroups.Find(id);
            db.SubGroups.Remove(subGroup);
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
