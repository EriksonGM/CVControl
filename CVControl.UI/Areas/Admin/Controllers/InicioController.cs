using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CVControl.Application;

namespace CVControl.UI.Areas.Admin.Controllers
{
    public class InicioController : Controller
    {
        private readonly ResultadoApp _resultadoApp;

        public InicioController()
        {
            _resultadoApp = new ResultadoApp();
        }
        
        public ActionResult Index()
        {

            return View(_resultadoApp.CalcularEstatisticas());
        }
    }
}