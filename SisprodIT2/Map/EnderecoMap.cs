using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SisprodIT2.Areas.Endereco.Models;
using System.Data.Entity.ModelConfiguration;
using System.ComponentModel.DataAnnotations.Schema;

namespace SisprodIT2.Map
{
    public class EnderecoMap : EntityTypeConfiguration<EnderecoModel>
    {
        public EnderecoMap()
        {
            HasKey(x => x.EnderecoModelId);

            Property(x => x.EnderecoModelId).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            Property(x => x.Pais).IsOptional();
            Property(x => x.UF).IsOptional();
            Property(x => x.Municipio).IsOptional();
            Property(x => x.Bairro).IsOptional();
            Property(x => x.Rua).IsOptional();
            Property(x => x.Complemento).IsOptional();
            Property(x => x.Numero).IsOptional();
            Property(x => x.Referencia).IsOptional();
            Property(x => x.CEP).IsOptional();
            Property(x => x.DataCadastro).IsRequired();
            Property(x => x.Ativo).IsRequired();

            HasRequired(x => x.Funcionario)
                .WithMany(y => y.EnderecoLista)
                .HasForeignKey(x => x.FuncionarioModelId)
                .WillCascadeOnDelete(false);

            ToTable("Endereco");

        }
    }
}