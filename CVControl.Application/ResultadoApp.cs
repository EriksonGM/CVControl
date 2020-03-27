using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CVControl.Application.Logs;
using CVControl.Data.Entidades;
using CVControl.Model;
using CVControl.Model.Charts;
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
                    Febre = dto.Febre,
                    Gravida = dto.Gravida
                };

                if (dto.IdSintomas.Any())
                    resultado.Sintomas = db.Sintomas.Where(x => dto.IdSintomas.Contains(x.IdSintomas)).ToList();

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
                ResultadoBaixoRisco = 0,
                ResultadosHoje = 0,
                ResultadosAltoRisco = 0
            };

            try
            {
                var qry = db.Resultados
                    .AsNoTracking()
                    .AsQueryable();

                //var today = 

                res.ResultadosHoje = qry.Count(x => x.DataCriacao > DateTime.Today);

                res.TotalResultados = qry.Count();

                res.ResultadosAltoRisco = qry.Count(x => x.Contacto & x.Febre & x.Viagem);

                res.ResultadoBaixoRisco = res.TotalResultados - res.ResultadosAltoRisco;

                //res.ResultadoBaixoRisco = qry.Count(x => x.DataCriacao.Date == DateTime.Now.Date);

                //res.ResultadosHoje = qry.Count(x => x.DataCriacao.Date == DateTime.Now.Date);

                return res;
            }
            catch (Exception e)
            {
                SystemLog.Erro(e);

                return res;
            }
        }

        public object GerarData()
        {
            try
            {
                var data = new Model.Charts.Data();

                var connString = ConfigurationManager.ConnectionStrings["Conn"].ConnectionString;

                var qry = @"Select Format(DataCriacao, 'dd/MM/yyyy') as DataCriacao, COUNT(*) as Resultados, SUM(Case When (Febre = 1 and Viagem = 1 and Contacto = 1) then 1 else 0 End) as AltoRisco from Resultado Where DataCriacao > (GETDATE() - 30) Group by Format(DataCriacao, 'dd/MM/yyyy') Order by Format(DataCriacao, 'dd/MM/yyyy')";

                using (SqlConnection conn = new SqlConnection(connString))
                {
                    var cmd = new SqlCommand(qry, conn);

                    conn.Open();

                    var reader = cmd.ExecuteReader();

                    

                    var dsTotal = new DataSet
                    {
                        label = "Resultados diarios",
                        
                    };

                    var dsAltoRisco = new DataSet
                    {
                        label = "Alto risco",
                        borderColor = "red"
                    };

                    if (reader.HasRows)
                        while (reader.Read())
                        {
                            data.labels.Add(reader["DataCriacao"].ToString());
                            dsTotal.data.Add(Convert.ToInt32(reader["Resultados"]));
                            dsAltoRisco.data.Add(Convert.ToInt32(reader["AltoRisco"]));
                        }

                    conn.Close();

                    data.datasets.Add(dsTotal);
                    data.datasets.Add(dsAltoRisco);

                }

                return data;
            }
            catch (Exception e)
            {
                SystemLog.Erro(e);
                return null;
            }
        }
    }
}
