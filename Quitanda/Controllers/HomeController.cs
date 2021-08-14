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

        public ActionResult Fruta()
        {            
             ViewData["nome"] = "Banana";

            return View();
        }
    }
}