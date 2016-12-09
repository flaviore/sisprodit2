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
using SisprodIT2.Models;
using SisprodIT2.Areas.Funcionario.Models;
using SisprodIT2.Areas.Categoria.Models;
using SisprodIT2.Areas.Finalizacao.Models;
using SisprodIT2.Areas.Comentario.Models;
using SisprodIT2.Areas.Chamado.Models;

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
        public DbSet<CategoriaModel> Categorias { get; set; }
        public DbSet<FinalizacaoModel> Finalizacoes { get; set; }
        public DbSet<ComentarioModel> Comentarios { get; set; }
        public DbSet<ChamadoModel> Chamados { get; set; }

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
            modelBuilder.Configurations.Add(new CategoriaMap());
            modelBuilder.Configurations.Add(new FinalizacaoMap());
            modelBuilder.Configurations.Add(new ComentarioMap());
            modelBuilder.Configurations.Add(new ChamadoMap());

 	        base.OnModelCreating(modelBuilder);
        }
    }
}