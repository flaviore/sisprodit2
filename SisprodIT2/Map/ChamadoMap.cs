using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SisprodIT2.Areas.Chamado.Models;
using SisprodIT2.Areas.Funcionario.Models;
using SisprodIT2.Areas.Categoria.Models;
using SisprodIT2.Areas.Finalizacao.Models;
using SisprodIT2.Models;
using System.Data.Entity.ModelConfiguration;
using System.ComponentModel.DataAnnotations.Schema;

namespace SisprodIT2.Map
{
    public class ChamadoMap : EntityTypeConfiguration<ChamadoModel>
    {
        public ChamadoMap()
        {
            HasKey(x => x.ChamadoModelId);

            Property(x => x.ChamadoModelId).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity).IsRequired();
            Property(x => x.Titulo).IsRequired();
            Property(x => x.Revisao).IsRequired();
            Property(x => x.Status).IsRequired();
            Property(x => x.Descricao).IsOptional();
            Property(x => x.CategoriaModelId).IsRequired();
            Property(x => x.FuncionarioCriadorId).IsRequired();
            Property(x => x.FuncionarioResponsavelId).IsOptional();
            Property(x => x.FinalizacaoModelId).IsOptional();

            Property(x => x.DataCadastro).IsRequired();
            Property(x => x.DataAtualizacao).IsOptional();
            Property(x => x.FuncionarioAtualizadorId).IsRequired();
            Property(x => x.Ativo).IsRequired();

            HasRequired(x => x.FuncionarioCriador)
                .WithMany(x => x.ChamadoLista)
                .HasForeignKey(x => x.FuncionarioCriadorId)
                .WillCascadeOnDelete(false);

            HasOptional(x => x.FuncionarioResponsavel)
                .WithMany(x => x.ChamadoLista)
                .HasForeignKey(x => x.FuncionarioResponsavelId)
                .WillCascadeOnDelete(false);

            HasRequired(x => x.Categoria)
                .WithMany(y => y.ChamadoLista)
                .HasForeignKey(x => x.CategoriaModelId)
                .WillCascadeOnDelete(false);

            HasOptional(x => x.Finalizacao)
                .WithMany(y => y.ChamadoLista)
                .HasForeignKey(x => x.FinalizacaoModelId)
                .WillCascadeOnDelete(false);

            ToTable("Chamado");


        }
    }
}