using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SisprodIT2.Areas.Setor.Models;
using System.Data.Entity.ModelConfiguration;
using System.ComponentModel.DataAnnotations.Schema;

namespace SisprodIT2.Map
{
    public class SetorMap : EntityTypeConfiguration<SetorModel>
    {
        public SetorMap()
        {
            // Definindo a chave primária da tabela
            HasKey(x => x.SetorModelId);

            Property(x => x.SetorModelId).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            Property(x => x.Nome).IsRequired();
            Property(x => x.Sigla).IsRequired();
            Property(x => x.Telefone).IsRequired();

            // Propriedades da classe BaseCadastro herdada
            Property(x => x.DataCadastro).IsRequired();
            Property(x => x.DataAtualizacao).IsOptional();
            Property(x => x.FuncionarioAtualizadorId).IsRequired();
            Property(x => x.Ativo).IsRequired();

            // Definindo o nome da tabela
            ToTable("Setor");
        }
    }
}