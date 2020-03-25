﻿using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

            //modelBuilder.Entity<Rol>()
            //    .HasMany(e => e.Utilizadores)
            //    .WithMany(e => e.Roles)
            //    .Map(m => m.ToTable("AspNetUserRoles").MapLeftKey("RoleId").MapRightKey("UserId"));

            //modelBuilder.Entity<Utilizador>()
            //    .HasMany(e => e.AspNetUserClaims)
            //    .WithRequired(e => e.Utilizador)
            //    .HasForeignKey(e => e.UserId);

            //modelBuilder.Entity<Utilizador>()
            //    .HasMany(e => e.AspNetUserLogins)
            //    .WithRequired(e => e.Utilizador)
            //    .HasForeignKey(e => e.UserId);

            //modelBuilder.Entity<Utilizador>()
            //    .HasMany(e => e.Permissoes)
            //    .WithMany(e => e.Utilizadores)
            //    .Map(m => m.ToTable("PermissoesUtilizador").MapLeftKey("IdUtilizador").MapRightKey("IdPermissao"));

            //modelBuilder.Entity<Servico>()
            //    .HasMany(e => e.SubCategorias)
            //    .WithMany(e => e.Servicos)
            //    .Map(m => m.ToTable("SubCategoriasServico").MapLeftKey("IdServico").MapRightKey("IdSubCategoria"));

            //modelBuilder.Entity<Cliente>()
            //    .HasMany(e => e.Favoritos)
            //    .WithMany(e => e.Clientes)
            //    .Map(m => m.ToTable("Favoritos").MapLeftKey("IdCliente").MapRightKey("IdServico"));

            //modelBuilder.Entity<Cliente>()
            //    .HasMany(e => e.Empresas)
            //    .WithMany(e => e.Clientes)
            //    .Map(m => m.ToTable("ClienteEmpresa").MapLeftKey("IdCliente").MapRightKey("IdEmpresa"));

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
    }
}