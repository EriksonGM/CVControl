﻿using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CVControl.Data.Entidades;

namespace CVControl.Data
{
    public class DataContext : DbContext
    {
        public DataContext() : base("name=Conn")
        {
            Configuration.LazyLoadingEnabled = false;
            Configuration.ProxyCreationEnabled = false;
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();
            modelBuilder.Conventions.Add(new StringConvention());

            modelBuilder.Entity<Resultado>()
                .HasMany(e => e.Sintomas)
                .WithMany(e => e.Resultados)
                .Map(m => m.ToTable("SintomasResultados").MapLeftKey("IdResultado").MapRightKey("IdSintoma"));

            base.OnModelCreating(modelBuilder);
        }

        private class StringConvention : Convention
        {
            public StringConvention()
            {
                this.Properties<string>()
                    .Configure(c => c.HasColumnType("varchar")
                            .HasMaxLength(100)//.IsRequired()
                    );
            }
        }

        public DbSet<EstadoCivil> EstadosCivis { get; set; }
        public DbSet<Resultado> Resultados { get; set; }
        public DbSet<Provincia> Provincias { get; set; }
        public DbSet<Municipio> Municipios { get; set; }
        public DbSet<Genero> Generos { get; set; }
        public DbSet<IntervaloIdade> IntervaloIdades { get; set; }
        public DbSet<Sintoma> Sintomas { get; set; }

        public DbSet<IntervaloFilhos> IntervalosFilhos { get; set; }
    }
}
