using System;
using CVControl.Model;
using System.Collections.Generic;
using System.Linq;
using CVControl.Application.Logs;

namespace CVControl.Application
{
    public class IntervaloIdadesApp : App
    {
        public List<IntervaloIdadeDTO> ListarIntervalos()
        {
            var res = new List<IntervaloIdadeDTO>();

            try
            {
                var intervalos = db.IntervaloIdades.ToList();

                res = mapper.Map<List<IntervaloIdadeDTO>>(intervalos);

                return res;
            }
            catch (Exception e)
            {
                SystemLog.Erro(e);
                return res;
            }
        }
    }
}