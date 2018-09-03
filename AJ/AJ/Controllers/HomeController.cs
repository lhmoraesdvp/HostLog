using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace AJ.Controllers
{
    public class HomeController : Controller
    {
        AJ.Models.db d = new Models.db();
        public ActionResult Index()
        {


            return View();
        }

        public async Task<JsonResult> SelecionarPorProjeto(int id)
        {

            preenchegrupo();
            preenchesub();
            // Tomei uma liberdade poética aqui. Não sei se Get aceita
            // parâmetros, mas a título de exemplo, vamos supor que sim.
            var subprojetos = d.subgrupos.Where(c => c.groupid == id).ToList();
            return Json(subprojetos.Where(c=>c.groupid==id).ToList(), JsonRequestBehavior.AllowGet);
        }

        public void preenchegrupo()
        {
            AJ.Models.Grupo g1 = new Models.Grupo();
            g1.id = 2;
            g1.nome = "Grupo 2";

            AJ.Models.Grupo g2 = new Models.Grupo();
            g2.id = 3;
            g2.nome = "Grupo 3";

            d.grupos.Add(g1);
            d.grupos.Add(g2);





        }
        public void preenchesub()
        {
            AJ.Models.Subgrupo s1 = new Models.Subgrupo();
            AJ.Models.Subgrupo s2 = new Models.Subgrupo();
            AJ.Models.Subgrupo s3 = new Models.Subgrupo();
            s1.id = 2;
            s1.groupid = 3;
            s1.name = "subgrupo 2";

            s2.id = 3;
            s2.groupid = 3;
            s2.name = "subgrupo 3";

            s2.id = 5;
            s2.groupid = 3;
            s2.name = "subgrupo 4";

            s3.id = 4;
            s3.groupid = 2;
            s3.name = "subgrupo 4";

            d.subgrupos.Add(s1);
            d.subgrupos.Add(s2);
            d.subgrupos.Add(s3);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Categorias()
        {
            ViewBag.Message = "Your application description page.";

            preenchegrupo();
            preenchesub();
          
            return View(d);
        }


      



        [HttpPost]
        public ActionResult Categorias(int i)
        {

            preenchegrupo();
            preenchesub();

            var l = d.subgrupos.Where(c => c.groupid == i).ToList();
            d.subgrupos = l;
        
            return View(d);
        }




        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}