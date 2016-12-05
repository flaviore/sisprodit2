using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SisprodIT2.Areas.Funcionario.Models;
using SisprodIT2.Areas.Chamado.Models;
using SisprodIT2.Models;
using System.Data.Entity.ModelConfiguration;
using System.ComponentModel.DataAnnotations.Schema;

namespace SisprodIT2.Map
{
    public class FuncionarioMap : EntityTypeConfiguration<FuncionarioModel>
    {
        public FuncionarioMap()
        {
            HasKey(x => x.FuncionarioModelId);

            Property(x => x.FuncionarioModelId).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            Property(x => x.Nome).IsRequired();
            Property(x => x.CPF).IsOptional();
            Property(x => x.RG).IsOptional();
            Property(x => x.Nascimento).IsOptional();
            Property(x => x.Altura).IsOptional();
            Property(x => x.Usuario).IsRequired();
            Property(x => x.Senha).IsRequired();
            Property(x => x.PerfilModelId).IsRequired();
            Property(x => x.SetorModelId).IsRequired();

            Property(x => x.DataCadastro).IsRequired();
            Property(x => x.DataAtualizacao).IsOptional();
            Property(x => x.FuncionarioAtualizadorId).IsRequired();
            Property(x => x.Ativo).IsRequired();


            HasRequired(x => x.Setor)
                .WithMany(y => y.FuncionarioLista)
                .HasForeignKey(x => x.SetorModelId)
                .WillCascadeOnDelete(false);

            HasRequired(x => x.Perfil)
                .WithMany(y => y.FuncionarioLista)
                .HasForeignKey(x => x.PerfilModelId)
                .WillCascadeOnDelete(false);

            ToTable("Funcionario");
        }
    }
}