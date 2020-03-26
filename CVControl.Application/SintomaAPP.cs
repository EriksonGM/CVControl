using System;
using System.Collections.Generic;
using System.Linq;
using CVControl.Application.Logs;
using CVControl.Data.Entidades;
using CVControl.Model;

namespace CVControl.Application
{
    public class SintomaApp : App
    {
        public List<SintomaDTO> ListarSintomas()
        {
            var res = new List<SintomaDTO>();

            try
            {
                var sintomas = db.Sintomas.ToList();

                res = mapper.Map<List<SintomaDTO>>(sintomas);

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