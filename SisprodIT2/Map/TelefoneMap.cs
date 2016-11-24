using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity.ModelConfiguration;
using SisprodIT2.Areas.Funcionario.Models;
using SisprodIT2.Areas.Telefone.Models;
using System.ComponentModel.DataAnnotations.Schema;

namespace SisprodIT2.Map
{
    public class TelefoneMap : EntityTypeConfiguration<TelefoneModel>
    {
        public TelefoneMap()
        {
            HasKey(x => x.TelefoneModelId);

            Property(x => x.TelefoneModelId).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity).IsRequired();
            Property(x => x.DDD).IsRequired();
            Property(x => x.Telefone).IsRequired();

            Property(x => x.DataCadastro).IsRequired();
            Property(x => x.DataAtualizacao).IsOptional();
            Property(x => x.FuncionarioAtualizadorId).IsRequired();
            Property(x => x.Ativo).IsRequired();

            HasRequired(x => x.Funionario)
                .WithMany(y => y.TelefoneLista)
                .HasForeignKey(x => x.FuncionarioModelId)
                .WillCascadeOnDelete(false);

            ToTable("Telefone");
        }
    }
}