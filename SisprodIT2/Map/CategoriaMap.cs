﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity.ModelConfiguration;
using SisprodIT2.Areas.Categoria.Models;
using System.ComponentModel.DataAnnotations.Schema;

namespace SisprodIT2.Map
{
    public class CategoriaMap : EntityTypeConfiguration<CategoriaModel>
    {
        public CategoriaMap()
        {
            HasKey(x => x.CategoriaModelId);

            Property(x => x.CategoriaModelId).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity).IsRequired();
            Property(x => x.Descricao).IsRequired();

            Property(x => x.DataCadastro).IsRequired();
            Property(x => x.DataAtualizacao).IsOptional();
            Property(x => x.FuncionarioAtualizadorId).IsRequired();
            Property(x => x.Ativo).IsRequired();

            ToTable("Categoria");

        }
    }
}