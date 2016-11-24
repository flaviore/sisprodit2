using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using SisprodIT2.Areas.Setor.Models;
using SisprodIT2.Areas.Perfil.Models;
using SisprodIT2.Areas.Telefone.Models;
using SisprodIT2.Areas.Endereco.Models;
using SisprodIT2.Areas.Email.Models;
using SisprodIT2.Areas.Funcionario.Models;

namespace SisprodIT2.Map
{
    public class DataContext : DbContext
    {
        public DataContext()
            : base("DefaultConnection")
        {
            Configuration.LazyLoadingEnabled = false;
            Configuration.ProxyCreationEnabled = false;
        }

        public DbSet<SetorModel> Setores { get; set; }
        public DbSet<PerfilModel> Perfis { get; set; }
        public DbSet<TelefoneModel> Telefones { get; set; }
        public DbSet<EnderecoModel> Enderecos { get; set; }
        public DbSet<EmailModel> Emails { get; set; }
        public DbSet<FuncionarioModel> Funcionarios { get; set; }

        protected override void  OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();
            modelBuilder.Conventions.Remove<ManyToManyCascadeDeleteConvention>();

            modelBuilder.Configurations.Add(new SetorMap());
            modelBuilder.Configurations.Add(new PerfilMap());
            modelBuilder.Configurations.Add(new TelefoneMap());
            modelBuilder.Configurations.Add(new EnderecoMap());
            modelBuilder.Configurations.Add(new EmailMap());
            modelBuilder.Configurations.Add(new FuncionarioMap());

 	        base.OnModelCreating(modelBuilder);
        }
    }
}