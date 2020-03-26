using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using CVControl.Application.Logs;
using CVControl.Model;

namespace CVControl.Application
{
    public class ProvinciaApp : App
    {
        public List<ProvinciaDTO> ListarProvinciasComMunicipios()
        {
            var res = new List<ProvinciaDTO>();

            try
            {
                var provincias = db.Provincias.Include(x => x.Municipios).ToList();

                res = mapper.Map<List<ProvinciaDTO>>(provincias);

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