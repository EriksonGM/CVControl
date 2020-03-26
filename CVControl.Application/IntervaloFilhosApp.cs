using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using CVControl.Application.Logs;
using CVControl.Model;

namespace CVControl.Application
{
    public class IntervaloFilhosApp : App
    {
        public List<IntervaloFilhosDTO> ListarIntervalos()
        {
            var res = new List<IntervaloFilhosDTO>();

            try
            {
                var intervalos = db.IntervalosFilhos.ToList();

                res = mapper.Map<List<IntervaloFilhosDTO>>(intervalos);

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