using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SisprodIT2.Areas.Comentario.Models;
using System.Data.Entity.ModelConfiguration;
using System.ComponentModel.DataAnnotations.Schema;

namespace SisprodIT2.Map
{
    public class ComentarioMap : EntityTypeConfiguration<ComentarioModel>
    {
        public ComentarioMap()
        {
            HasKey(x => x.ComentarioModelId);

            Property(x => x.ComentarioModelId).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity).IsRequired();
            Property(x => x.Comentario).IsRequired();
            Property(x => x.Ordem).IsRequired();
            Property(x => x.ChamadoModelId).IsRequired();

            Property(x => x.DataCadastro).IsRequired();
            Property(x => x.DataAtualizacao).IsOptional();
            Property(x => x.FuncionarioAtualizadorId).IsRequired();
            Property(x => x.Ativo).IsRequired();

            HasRequired(x => x.Chamado)
                .WithMany(y => y.ComentarioLista)
                .HasForeignKey(x => x.ChamadoModelId)
                .WillCascadeOnDelete(false);

            HasRequired(x => x.FuncionarioAtualizador)
                .WithMany(x => x.ComentarioLista)
                .HasForeignKey(x => x.FuncionarioAtualizadorId)
                .WillCascadeOnDelete(false);

            
            ToTable("Comentario");

        }
    }
}
