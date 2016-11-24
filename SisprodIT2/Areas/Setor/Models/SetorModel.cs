using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SisprodIT2.Models;
using SisprodIT2.Areas.Funcionario.Models;

namespace SisprodIT2.Areas.Setor.Models
{
    public class SetorModel : BaseCadastro
    {
        public int SetorModelId { get; set; }
        public string Nome { get; set; }
        public string Sigla { get; set; }
        public string Descricao { get; set; }
        public string Telefone { get; set; }
        public ICollection<FuncionarioModel> FuncionarioLista { get; set; }

        public SetorModel()
        {
            FuncionarioLista = new List<FuncionarioModel>();
        }
    }
}