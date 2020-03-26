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
        public List<ProvinciaDTO> ListarProvincias()
        {
            var res = new List<ProvinciaDTO>();

            try
            {
                var provincias = db.Provincias
                    //.Include(x => x.Municipios)
                    .ToList();

                res = mapper.Map<List<ProvinciaDTO>>(provincias);

                return res;

            }
            catch (Exception e)
            {
                SystemLog.Erro(e);
                return res;
            }
        }

        public List<MunicipioDTO> ListarMunicipiosByIdProvincia(int idProvincia)
        {
            var res = new List<MunicipioDTO>();

            try
            {
                var municipios = db.Municipios
                    .Where(x=>x.IdProvincia == idProvincia)
                    .ToList();

                res = mapper.Map<List<MunicipioDTO>>(municipios);

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