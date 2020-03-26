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
        private readonly IntervaloIdadesApp _intervaloIdadesApp;
        private readonly GeneroApp _generoApp;
        private readonly EstadoCivilApp _estadoCivilApp;
        private readonly SintomaApp _sintomaApp;

        public HomeController()
        {
            _provinciaApp = new ProvinciaApp();
            _intervaloIdadesApp = new IntervaloIdadesApp();
            _generoApp= new GeneroApp();
            _estadoCivilApp= new EstadoCivilApp();
            _sintomaApp = new SintomaApp();
        }

        public ActionResult Index()
        {
            ViewBag.Provincias = _provinciaApp.ListarProvinciasComMunicipios();

            ViewBag.Idades = _intervaloIdadesApp.ListarIntervalos();

            ViewBag.EstadosCivis = _estadoCivilApp.ListarEstadosCivis();

            ViewBag.Sintomas = _sintomaApp.ListarSintomas();

            return View();
        }

    }
}