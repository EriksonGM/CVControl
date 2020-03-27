using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CVControl.Application.Charts;
using CVControl.Application.Logs;
using CVControl.Data.Entidades;
using CVControl.Model;
using CVControl.Model.Charts;
using CVControl.Model.Estatisticas;
using DonutDataSet = CVControl.Application.Charts.DonutDataSet;
using LineDataSet = CVControl.Application.Charts.LineDataSet;

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

        public object GerarDataHistorico()
        {
            try
            {
                var data = new Charts.Data();

                var connString = ConfigurationManager.ConnectionStrings["Conn"].ConnectionString;

                var qry = @"Select Format(DataCriacao, 'dd/MM/yyyy') as DataCriacao, COUNT(*) as Resultados, SUM(Case When (Febre = 1 and Viagem = 1 and Contacto = 1) then 1 else 0 End) as AltoRisco from Resultado Where DataCriacao > (GETDATE() - 30) Group by Format(DataCriacao, 'dd/MM/yyyy') Order by Format(DataCriacao, 'dd/MM/yyyy')";

                using (SqlConnection conn = new SqlConnection(connString))
                {
                    var cmd = new SqlCommand(qry, conn);

                    conn.Open();

                    var reader = cmd.ExecuteReader();

                    var dsTotal = new LineDataSet
                    {
                        label = "Resultados diarios",
                    };

                    var dsAltoRisco = new LineDataSet
                    {
                        label = "Alto risco",
                        borderColor = "red",
                        pointBorderColor = "red",
                        pointBackgroundColor = "red"
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

        public object GerarDataGenero()
        {
            try
            {
                var data = new Charts.Data();

                var connString = ConfigurationManager.ConnectionStrings["Conn"].ConnectionString;

                var qry = @"Select g.Nome as Genero, Count(*) as Total from Resultado r inner join Genero g on r.IdGenero = g.IdGenero Group By g.Nome Order By g.Nome";

                using (SqlConnection conn = new SqlConnection(connString))
                {
                    var cmd = new SqlCommand(qry, conn);

                    conn.Open();

                    var reader = cmd.ExecuteReader();
                    
                    var dsGenero = new DonutDataSet()
                    {
                        label = "Generos",
                        backgroundColor = new List<string>
                        {
                            Color.Pink.Name, Color.DodgerBlue.Name
                        },
                        hoverBackgroundColor = new List<string>
                        {
                            Color.Pink.Name, Color.DodgerBlue.Name
                        }
                    };

                    if (reader.HasRows)
                        while (reader.Read())
                        {
                            data.labels.Add(reader["Genero"].ToString());
                            dsGenero.data.Add(Convert.ToInt32(reader["Total"]));
                        }

                    conn.Close();

                    data.datasets.Add(dsGenero);
                }

                return data;
            }
            catch (Exception e)
            {
                SystemLog.Erro(e);
                return null;
            }
        }

        public object GerarDataEstadoCivil()
        {
            try
            {
                var data = new Charts.Data();

                var connString = ConfigurationManager.ConnectionStrings["Conn"].ConnectionString;

                var qry = @"Select ec.Estado as Estado, COUNT(*) as Total from Resultado r inner join EstadoCivil ec on r.IdEstadoCivil = ec.IdEstadoCivil Group by ec.Estado Order By ec.Estado ";

                using (SqlConnection conn = new SqlConnection(connString))
                {
                    var cmd = new SqlCommand(qry, conn);

                    conn.Open();

                    var reader = cmd.ExecuteReader();

                    var dsEstadoCivilo = new DonutDataSet()
                    {
                        label = "Estado Civil",
                        backgroundColor = new List<string>
                        {
                            Color.DodgerBlue.Name, Color.DarkGray.Name,Color.Moccasin.Name,Color.DarkSalmon.Name,Color.Wheat.Name
                        },
                        hoverBackgroundColor = new List<string>
                        {
                            Color.DodgerBlue.Name, Color.DarkGray.Name,Color.Moccasin.Name,Color.DarkSalmon.Name,Color.Wheat.Name
                        }
                    };

                    if (reader.HasRows)
                        while (reader.Read())
                        {
                            data.labels.Add(reader["Estado"].ToString());
                            dsEstadoCivilo.data.Add(Convert.ToInt32(reader["Total"]));
                        }

                    conn.Close();

                    data.datasets.Add(dsEstadoCivilo);
                }

                return data;
            }
            catch (Exception e)
            {
                SystemLog.Erro(e);
                return null;
            }
        }

        public object GerarDataIdade()
        {
            try
            {
                var data = new Charts.Data();

                var connString = ConfigurationManager.ConnectionStrings["Conn"].ConnectionString;

                var qry = @"Select ii.Intervalo as Intervalo, COUNT(*) as Total from Resultado r inner join IntervaloIdade ii on r.IdIntervaloIdade = ii.IdIntervaloIdade Group By ii.Intervalo, ii.IdIntervaloIdade Order By ii.IdIntervaloIdade";

                using (SqlConnection conn = new SqlConnection(connString))
                {
                    var cmd = new SqlCommand(qry, conn);

                    conn.Open();

                    var reader = cmd.ExecuteReader();

                    var ds = new DonutDataSet()
                    {
                        label = "Estado Civil",
                        backgroundColor = new List<string>
                        {
                           "#e1bcc3", "#a1cde8","#757da4","#b9e5e8","#c6b6d1"
                        },
                        hoverBackgroundColor = new List<string>
                        {
                            "#e1bcc3", "#a1cde8","#757da4","#b9e5e8","#c6b6d1"
                        }
                    };

                    if (reader.HasRows)
                        while (reader.Read())
                        {
                            data.labels.Add(reader["Intervalo"].ToString());
                            ds.data.Add(Convert.ToInt32(reader["Total"]));
                        }

                    conn.Close();

                    data.datasets.Add(ds);
                }

                return data;
            }
            catch (Exception e)
            {
                SystemLog.Erro(e);
                return null;
            }
        }

        public object GerarDataFilhos()
        {
            try
            {
                var data = new Charts.Data();

                var connString = ConfigurationManager.ConnectionStrings["Conn"].ConnectionString;

                var qry = @"Select ifi.Intervalo, COUNT(*) as Total from Resultado r inner join IntervaloFilhos ifi on r.IdIntervaloFilhos = ifi.IdIntervaloFilhos group by ifi.Intervalo, ifi.IdIntervaloFilhos Order By ifi.IdIntervaloFilhos";

                using (SqlConnection conn = new SqlConnection(connString))
                {
                    var cmd = new SqlCommand(qry, conn);

                    conn.Open();

                    var reader = cmd.ExecuteReader();

                    var ds = new DonutDataSet()
                    {
                        label = "Estado Civil",
                        backgroundColor = new List<string>
                        {
                            "#e1bcc3", "#a1cde8","#757da4","#b9e5e8","#c6b6d1"
                        },
                        hoverBackgroundColor = new List<string>
                        {
                            "#e1bcc3", "#a1cde8","#757da4","#b9e5e8","#c6b6d1"
                        }
                    };

                    if (reader.HasRows)
                        while (reader.Read())
                        {
                            data.labels.Add(reader["Intervalo"].ToString());
                            ds.data.Add(Convert.ToInt32(reader["Total"]));
                        }

                    conn.Close();

                    data.datasets.Add(ds);
                }

                return data;
            }
            catch (Exception e)
            {
                SystemLog.Erro(e);
                return null;
            }
        }

        public object GerarDataProvincias()
        {
            try
            {
                var data = new Charts.Data();

                var connString = ConfigurationManager.ConnectionStrings["Conn"].ConnectionString;

                var qry = @"Select p.Nome as Provincia, COUNT(*)  as Total, SUM(Case When (Febre = 1 and Viagem = 1 and Contacto = 1) then 1 else 0 End) as AltoRisco from Resultado r inner join Municipio m on r.IdMunicipio = m.IdMunicipio inner join Provincia p on m.IdProvincia = p.IdProvincia Group by p.Nome, p.IdProvincia Order By p.IdProvincia";

                using (SqlConnection conn = new SqlConnection(connString))
                {
                    var cmd = new SqlCommand(qry, conn);

                    conn.Open();

                    var reader = cmd.ExecuteReader();

                    var ds = new BarDataSet
                    {
                        label = "Reportes",
                        backgroundColor = "#e1bcc3",
                        hoverBackgroundColor = "#b9e5e8"
                    };

                    var dsRisco = new BarDataSet
                    {
                        label = "Reportes de Risco",
                        backgroundColor = Color.Brown.Name,
                        hoverBackgroundColor = Color.Red.Name
                    };

                    if (reader.HasRows)
                        while (reader.Read())
                        {
                            data.labels.Add(reader["Provincia"].ToString());


                            ds.data.Add(Convert.ToInt32(reader["Total"]));
                            dsRisco.data.Add(Convert.ToInt32(reader["AltoRisco"]));
                        }

                    conn.Close();

                    data.datasets.Add(ds);
                    data.datasets.Add(dsRisco);
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
