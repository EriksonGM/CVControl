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
        public AppResultado ListarProvinciasComMunicipios()
        {
            var res = new AppResultado();

            try
            {
                var provincias = db.Provincias.Include(x => x.Municipios).ToList();

                var provinciasDTO = mapper.Map<List<ProvinciaDTO>>(provincias);

                return res.Good(provinciasDTO);

            }
            catch (Exception e)
            {
                SystemLog.Erro(e);
                return res.Bad("Erro ao listar provincias");
            }
        }
    }
}