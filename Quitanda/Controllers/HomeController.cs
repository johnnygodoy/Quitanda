using Quitanda.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.ModelBinding;
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
            var fruta1 = frutas.GetFruta(1);        

            frutas.FrutaID = fruta1.FrutaID;
            frutas.NomeFruta = fruta1.NomeFruta;
        
            return View(frutas);
        }
        [HttpPost]
        public ActionResult EnviarFruta(Fruta fruta)
        {
            ViewData["FrutaID"] = fruta.FrutaID;
            ViewData["NomeFruta"] = fruta.NomeFruta;

            return View(fruta);
        }
      
        public ActionResult Usuario()
        {
            Usuario usuario = new Usuario();
            return View(usuario);
        }

        [HttpPost]
        public ActionResult Usuario(Usuario usuario)
        {
            if (ModelState.IsValid)
            {
                return View("Usuario", usuario);
            }
            return View(usuario);
        }
    }
}