using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CVControl.Application;
using Newtonsoft.Json;

namespace CVControl.UI.Areas.Admin.Controllers
{
    public class EstatisticasController : Controller
    {
        private readonly ResultadoApp _resultadoApp;

        public EstatisticasController()
        {
            _resultadoApp = new ResultadoApp();
        }
        // GET: Admin/Estatisticas
        public ActionResult Index()
        {
            ViewBag.Genero = JsonConvert.SerializeObject(_resultadoApp.GerarDataGenero());
            ViewBag.EstadoCivil = JsonConvert.SerializeObject(_resultadoApp.GerarDataEstadoCivil());
            ViewBag.Idade = JsonConvert.SerializeObject(_resultadoApp.GerarDataIdade());
            ViewBag.Filhos = JsonConvert.SerializeObject(_resultadoApp.GerarDataFilhos());
            ViewBag.Provincia = JsonConvert.SerializeObject(_resultadoApp.GerarDataProvincias());

            return View();
        }
    }
}