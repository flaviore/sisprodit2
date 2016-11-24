using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SisprodIT2.Areas.Funcionario.Models;
using SisprodIT2.Models;

namespace SisprodIT2.Areas.Email.Models
{
    public class EmailModel : BaseCadastro
    {
        public int EmailModelId { get; set; }
        public string Email { get; set; }
        public int FuncionarioModelId { get; set; }
        public virtual FuncionarioModel Funcionario { get; set; }
    }
}