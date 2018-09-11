using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using HostMonitor.Models;

namespace HostMonitor.Controllers
{
    public class MenssagemsController : Controller
    {
        private Db db = new Db();
        Menssagem m = new Menssagem();
        // GET: Menssagems
        public ActionResult Index()
        {
            return View(db.Menssagem.ToList());
        }


        [HttpPost]
        public ActionResult Altergp([Bind(Include = "idGrupo,idSubgrupo,idCentro,usuario,dataHora,menssagem1,status,c0,c01,c02,i0,i01,i02")] Menssagem menssagem)
        {


            if (Request.IsAjaxRequest())
            {
                m.subgrupos = db.SubGroup.Where(c => c.sGroup == menssagem.idGrupo).ToList();
                m.groups = db.HostGroup.ToList();

               return PartialView("_gruposPartial", m);

            }
            else
            {
                return RedirectToAction("Create", "Menssagems", new { idGrupo = menssagem.idGrupo });
            }

           
   
   
        }

        // GET: Menssagems/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Menssagem menssagem = db.Menssagem.Find(id);
            if (menssagem == null)
            {
                return HttpNotFound();
            }
            return View(menssagem);
        }

        // GET: Menssagems/Create

        public ActionResult Create(int? idGrupo)
        {
            if(idGrupo!=null)
            {
                
                m.groups = db.HostGroup.ToList();
                m.subgrupos = db.SubGroup.Where(c => c.sGroup == idGrupo).ToList();
                return View (m);


            }

            m.centros = db.centroDeCusto.ToList();
            m.groups = db.HostGroup.ToList();
                SubGroup s = new SubGroup();
                s.sGroup = 0;
                s.subgId = 0;
                s.subgroupName = "Todos";
                m.subgrupos.Add(s);
                return View(m);
            

        }

        // POST: Menssagems/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]

        public ActionResult Create([Bind(Include = "idGrupo,idSubgrupo,idCentro,usuario,dataHora,menssagem1,status,c0,c01,c02,i0,i01,i02")] Menssagem menssagem)
        {

          
            




            if (ModelState.IsValid)
            {
                db.Menssagem.Add(menssagem);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(menssagem);
        }

        // GET: Menssagems/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Menssagem menssagem = db.Menssagem.Find(id);
            if (menssagem == null)
            {
                return HttpNotFound();
            }
            return View(menssagem);
        }

        // POST: Menssagems/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "idMenssagem,idGrupo,idSubgrupo,idCentro,usuario,dataHora,menssagem1,status,c0,c01,c02,i0,i01,i02")] Menssagem menssagem)
        {
            if (ModelState.IsValid)
            {
                db.Entry(menssagem).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(menssagem);
        }

        // GET: Menssagems/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Menssagem menssagem = db.Menssagem.Find(id);
            if (menssagem == null)
            {
                return HttpNotFound();
            }
            return View(menssagem);
        }

        // POST: Menssagems/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Menssagem menssagem = db.Menssagem.Find(id);
            db.Menssagem.Remove(menssagem);
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
