using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SisprodIT2.Areas.Finalizacao.Models;
using System.Data.Entity.ModelConfiguration;
using System.ComponentModel.DataAnnotations.Schema;

namespace SisprodIT2.Map
{
    public class FinalizacaoMap : EntityTypeConfiguration<FinalizacaoModel>
    {
        public FinalizacaoMap()
        {
            HasKey(x => x.FinalizacaoModelId);

            Property(x => x.FinalizacaoModelId).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity).IsRequired();
            Property(x => x.Descricao);

            Property(x => x.DataCadastro).IsRequired();
            Property(x => x.DataAtualizacao).IsOptional();
            Property(x => x.FuncionarioAtualizadorId).IsRequired();
            Property(x => x.Ativo).IsRequired();

            ToTable("Finalizacao");
        }
    }
}