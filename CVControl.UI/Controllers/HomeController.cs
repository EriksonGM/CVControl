using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CVControl.Application;
using CVControl.Model;

namespace CVControl.UI.Controllers
{
    public class HomeController : Controller
    {
        private readonly ProvinciaApp _provinciaApp;
        private readonly IntervaloIdadesApp _intervaloIdadesApp;
        private readonly GeneroApp _generoApp;
        private readonly EstadoCivilApp _estadoCivilApp;
        private readonly SintomaApp _sintomaApp;
        private readonly ResultadoApp _resultadoApp;
        private readonly IntervaloFilhosApp _intervaloFilhosApp;
        public HomeController()
        {
            _intervaloFilhosApp = new IntervaloFilhosApp();
            _provinciaApp = new ProvinciaApp();
            _intervaloIdadesApp = new IntervaloIdadesApp();
            _generoApp = new GeneroApp();
            _estadoCivilApp = new EstadoCivilApp();
            _sintomaApp = new SintomaApp();
            _resultadoApp = new ResultadoApp();
        }

        public ActionResult Index()
        {
            ViewBag.Provincias = _provinciaApp.ListarProvinciasComMunicipios();

            ViewBag.Idades = _intervaloIdadesApp.ListarIntervalos();

            ViewBag.EstadosCivis = _estadoCivilApp.ListarEstadosCivis();

            ViewBag.Sintomas = _sintomaApp.ListarSintomas();

            ViewBag.Filhos = _intervaloFilhosApp.ListarIntervalos();

            return View();
        }

        [HttpPost]
        public ActionResult Index(ResultadoDTO model)
        {
            if (ModelState.IsValid)
            {
                return Json(_resultadoApp.SalvarResultado(model));
            }

            return Json(new
            {
                Exito = false,
                Mensagem = ModelState.Values.SelectMany(v => v.Errors).FirstOrDefault().ErrorMessage
            });
        }

    }
}