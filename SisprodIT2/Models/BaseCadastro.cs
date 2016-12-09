using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using SisprodIT2.Areas.Funcionario.Models;

namespace SisprodIT2.Models
{
    public class BaseCadastro
    {
        [Display(Name="Data do Cadastro")]
        public DateTime DataCadastro { get; set; }

        [Display(Name = "Data da Atualização")]
        public DateTime DataAtualizacao { get; set; }

        [Display(Name = "Func Atualizador")]
        public int? FuncionarioAtualizadorId { get; set; }

        [Display(Name = "Ativo")]
        public bool Ativo { get; set; }

    }
}