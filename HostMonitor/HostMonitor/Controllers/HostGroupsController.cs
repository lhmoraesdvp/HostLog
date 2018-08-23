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
        private Db db = new Db();

        // GET: HostGroups
        [Authorize(Roles = "administrador")]
        public ActionResult Index()
        {
            return View(db.HostGroup.ToList());
        }

        // GET: HostGroups/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            HostGroup hostGroup = db.HostGroup.Find(id);
            if (hostGroup == null)
            {
                return HttpNotFound();
            }
            return View(hostGroup);
        }

        // GET: HostGroups/Create
        [Authorize(Roles = "administrador")]
        public ActionResult Create()
        {
            return View();
        }

        // POST: HostGroups/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "groupId,groupName,groupDescription,groupIdentity")] HostGroup hostGroup)
        {
            if (ModelState.IsValid)
            {
                db.HostGroup.Add(hostGroup);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(hostGroup);
        }

        // GET: HostGroups/Edit/5
        [Authorize(Roles = "administrador")]
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            HostGroup hostGroup = db.HostGroup.Find(id);
            if (hostGroup == null)
            {
                return HttpNotFound();
            }
            return View(hostGroup);
        }

        // POST: HostGroups/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
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
        [Authorize(Roles = "administrador")]
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            HostGroup hostGroup = db.HostGroup.Find(id);
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
            HostGroup hostGroup = db.HostGroup.Find(id);
            db.HostGroup.Remove(hostGroup);
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
