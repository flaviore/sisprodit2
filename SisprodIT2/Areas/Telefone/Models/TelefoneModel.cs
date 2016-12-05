using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SisprodIT2.Models;
using SisprodIT2.Areas.Funcionario.Models;

namespace SisprodIT2.Areas.Telefone.Models
{
    public class TelefoneModel : BaseCadastro
    {
        public int TelefoneModelId { get; set; }
        public int DDD { get; set; }
        public int Telefone { get; set; }
        public int FuncionarioModelId { get; set; }
        public virtual FuncionarioModel Funcionario { get; set; }
    }
}