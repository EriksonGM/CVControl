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
                new Genero {IdGenero = 2,Nome = "Masculino"});

            ctx.SaveChanges();
        }
    }
}
