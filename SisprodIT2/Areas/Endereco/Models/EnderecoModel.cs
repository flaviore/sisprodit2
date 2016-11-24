using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SisprodIT2.Models;
using SisprodIT2.Areas.Funcionario.Models;

namespace SisprodIT2.Areas.Endereco.Models
{
    public class EnderecoModel : BaseCadastro
    {
        public int EnderecoModelId { get; set; }
        public string Pais { get; set; }
        public string UF { get; set; }
        public string Municipio { get; set; }
        public string Bairro { get; set; }
        public string Rua { get; set; }
        public string Complemento { get; set; }
        public int Numero { get; set; }
        public string Referencia { get; set; }
        public string CEP { get; set; }
        public int FuncionarioModelId { get; set; }
        public virtual FuncionarioModel Funcionario { get; set; }

    }
}