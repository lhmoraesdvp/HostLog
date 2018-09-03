using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Ajax.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult st()
        {
            return PartialView("_part","okokok");
        }

        [HttpPost]
        public string SubmeterInscricao(string Nome, string Endereco)
        {
            if (!String.IsNullOrEmpty(Nome) && !String.IsNullOrEmpty(Endereco))
                //TODO: salvar dados no banco de dados
                return "Obrigado " + Nome + ". O dados foram Salvos.";
            else
                return "Complete a informação do formulário.";
        }
  



        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}