using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CVControl.Application.Logs;
using CVControl.Data.Entidades;
using CVControl.Model;
using CVControl.Model.Estatisticas;

namespace CVControl.Application
{
    public class ResultadoApp : App
    {
        public AppResultado SalvarResultado(ResultadoDTO dto)
        {
            var res = new AppResultado();

            try
            {
                var resultado = new Resultado
                {
                    IdResultado = Guid.NewGuid(),
                    DataCriacao = DateTime.Now,
                    Nome = dto.Nome,
                    IdMunicipio = dto.IdMunicipio,
                    IdEstadoCivil = dto.IdEstadoCivil,
                    IdGenero = dto.IdGenero,
                    IdIntervaloIdade = dto.IdIntervaloIdade,
                    Endereco = dto.Endereco,
                    Telefone = dto.Telefone,
                    IdIntervaloFilhos = dto.IdIntervaloFilhos,
                    Medicacao = dto.Medicacao,
                    Contacto = dto.Contacto,
                    Viagem = dto.Viagem,
                    Gravida = dto.Gravida
                };

                db.Resultados.Add(resultado);

                db.SaveChanges();

                return res.Good("Resultado guardado com sucesso");
            }
            catch (Exception e)
            {
                SystemLog.Erro(e);
                return res.Bad("Erro ao guardar resultado");
            }
        }

        public EstatisticasGerais CalcularEstatisticas()
        {
            var res = new EstatisticasGerais
            {
                TotalResultados = 0,
                ResultadoRiscoHoje = 0,
                ResultadosHoje = 0,
                ResultadosRisco = 0
            };

            try
            {
                var qry = db.Resultados
                    .AsNoTracking()
                    .AsQueryable();

               
                res.ResultadosHoje = qry.Count(x => x.DataCriacao > DateTime.Now.AddDays(-1));

                res.TotalResultados = qry.Count();

                res.ResultadoRiscoHoje = qry.Count(x => x.DataCriacao.Date == DateTime.Now.Date);

                res.ResultadosHoje = qry.Count(x => x.DataCriacao.Date == DateTime.Now.Date);

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
