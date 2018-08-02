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
    public class HostGroupsController : Controller
    {
        private HostMonitorContext db = new HostMonitorContext();

        // GET: HostGroups
        public ActionResult Index()
        {
            return View(db.HostGroups.ToList());
        }

        // GET: HostGroups/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            HostGroup hostGroup = db.HostGroups.Find(id);
            if (hostGroup == null)
            {
                return HttpNotFound();
            }
            return View(hostGroup);
        }

        // GET: HostGroups/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: HostGroups/Create
        // Para se proteger de mais ataques, ative as propriedades específicas a que você quer se conectar. Para 
        // obter mais detalhes, consulte https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "groupId,groupName,groupDescription,groupIdentity")] HostGroup hostGroup)
        {
            if (ModelState.IsValid)
            {
                db.HostGroups.Add(hostGroup);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(hostGroup);
        }

        // GET: HostGroups/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            HostGroup hostGroup = db.HostGroups.Find(id);
            if (hostGroup == null)
            {
                return HttpNotFound();
            }
            return View(hostGroup);
        }

        // POST: HostGroups/Edit/5
        // Para se proteger de mais ataques, ative as propriedades específicas a que você quer se conectar. Para 
        // obter mais detalhes, consulte https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "groupId,groupName,groupDescription,groupIdentity")] HostGroup hostGroup)
        {
            if (ModelState.IsValid)
            {
                db.Entry(hostGroup).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(hostGroup);
        }

        // GET: HostGroups/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            HostGroup hostGroup = db.HostGroups.Find(id);
            if (hostGroup == null)
            {
                return HttpNotFound();
            }
            return View(hostGroup);
        }

        // POST: HostGroups/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            HostGroup hostGroup = db.HostGroups.Find(id);
            db.HostGroups.Remove(hostGroup);
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
