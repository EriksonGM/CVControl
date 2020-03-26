using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CVControl.Application;

namespace CVControl.UI.Controllers
{
    public class HomeController : Controller
    {
        private readonly ProvinciaApp _provinciaApp;

        public HomeController()
        {
            _provinciaApp = new ProvinciaApp();
        }

        public ActionResult Index()
        {
            ViewBag.Provincias = _provinciaApp.ListarProvinciasComMunicipios();

            return View();
        }

    }
}