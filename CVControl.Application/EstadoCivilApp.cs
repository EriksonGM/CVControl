using System;
using System.Collections.Generic;
using System.Linq;
using CVControl.Application.Logs;
using CVControl.Data.Entidades;
using CVControl.Model;

namespace CVControl.Application
{
    public class EstadoCivilApp : App
    {
        public List<EstadoCivilDTO> ListarEstadosCivis()
        {
            var res = new List<EstadoCivilDTO>();

            try
            {
                var estados = db.EstadosCivis.ToList();

                res = mapper.Map<List<EstadoCivilDTO>>(estados);

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