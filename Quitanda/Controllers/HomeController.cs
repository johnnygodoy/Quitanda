using Quitanda.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Quitanda.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Quitanda sempre com você!";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Meus Contatos:";

            return View();
        }

        public ActionResult Fruta(Fruta frutas)
        {              
                      

            frutas.FrutaID = 1;
            frutas.NomeFruta = "maça";
            //ViewData["FrutaId"] = teste.FrutaID;
            //ViewData["NomeFruta"] = teste.NomeFruta;
            return View(frutas);
        }
        [HttpPost]
        public ActionResult EnviarLista(Fruta fruta)
        {
            ViewData["FrutaID"] = fruta.FrutaID;
            ViewData["NomeFruta"] = fruta.NomeFruta;

            return View();
        }

    }
}