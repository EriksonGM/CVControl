using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using CVControl.Application.Logs;
using CVControl.Model;

namespace CVControl.Application
{
    public class GeneroApp : App
    {
        public List<GeneroDTO> ListarGeneros()
        {
            var res = new List<GeneroDTO>();

            try
            {
                var generos = db.Generos.ToList();

                res = mapper.Map<List<GeneroDTO>>(generos);

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