using CVControl.Data.Entidades;

namespace CVControl.Data.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<DataContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
        }

        protected override void Seed(DataContext ctx)
        {
            ctx.IntervaloIdades.AddOrUpdate(x=>x.IdIntervaloIdade, 
                new IntervaloIdade{IdIntervaloIdade = 1,Intervalo = "Menor de 10 anos"},
                new IntervaloIdade{IdIntervaloIdade = 2,Intervalo = "Entre 10 e 25 anos"},
                new IntervaloIdade{IdIntervaloIdade = 3,Intervalo = "Entre 25 e 35 anos"},
                new IntervaloIdade{IdIntervaloIdade = 4,Intervalo = "Entre 35 e 50 anos"},
                new IntervaloIdade{IdIntervaloIdade = 5,Intervalo = "Mais de 50"}
                );

            ctx.Generos.AddOrUpdate( X=>X.IdGenero,
                new Genero {IdGenero = 1,Nome = "Feminino"},
                new Genero {IdGenero = 2,Nome = "Masculino"}
                );

            ctx.EstadosCivis.AddOrUpdate(x=>x.IdEstadoCivil,
                new EstadoCivil { IdEstadoCivil = 1,Estado = "Solteiro(a)"},
                new EstadoCivil { IdEstadoCivil = 2,Estado = "Casado(a)" },
                new EstadoCivil { IdEstadoCivil = 3,Estado = "Divorciado(a)" },
                new EstadoCivil { IdEstadoCivil = 4,Estado = "Viuvo(a)" }
                );

            ctx.Sintomas.AddOrUpdate(x=>x.IdSintomas,
                new Sintoma { IdSintomas = 1,Nome = "Coriza" },
                new Sintoma { IdSintomas = 2,Nome = "Nariz entupido" },
                new Sintoma { IdSintomas = 3,Nome = "Cansaço" },
                new Sintoma { IdSintomas = 4,Nome = "Tosse" },
                new Sintoma { IdSintomas = 5,Nome = "Dor de cabeça" },
                new Sintoma { IdSintomas = 6,Nome = "Dores no corpo" },
                new Sintoma { IdSintomas = 7,Nome = "Mal estar geral" },
                new Sintoma { IdSintomas = 8,Nome = "Dor de garganta" }
                );

            ctx.SaveChanges();
        }
    }
}
