using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CVControl.Application.Logs;
using CVControl.Data.Entidades;
using CVControl.Model;

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
                return res;
            }
        }

        //public 
    }
}
