using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations.Schema;
using SisprodIT2.Areas.Email.Models;
using System.Data.Entity.ModelConfiguration;

namespace SisprodIT2.Map
{
    public class EmailMap : EntityTypeConfiguration<EmailModel>
    {
        public EmailMap()
        {
            HasKey(x => x.EmailModelId);

            Property(x => x.EmailModelId).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity).IsRequired();
            Property(x => x.Email).IsRequired();

            Property(x => x.DataCadastro).IsRequired();
            Property(x => x.DataAtualizacao).IsOptional();
            Property(x => x.FuncionarioAtualizadorId).IsRequired();
            Property(x => x.Ativo).IsRequired();

            HasRequired(x => x.Funcionario)
                .WithMany(y => y.EmailLista)
                .HasForeignKey(x => x.FuncionarioModelId)
                .WillCascadeOnDelete(false);

            ToTable("Email");

        }
    }
}