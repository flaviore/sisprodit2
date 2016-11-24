using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SisprodIT2.Areas.Funcionario.Models;
using SisprodIT2.Models;

namespace SisprodIT2.Areas.Perfil.Models
{
    public class PerfilModel : BaseCadastro
    {
        public int PerfilModelId { get; set; }
        public string Descricao { get; set; }
        public ICollection<FuncionarioModel> FuncionarioLista { get; set; }

        public PerfilModel()
        {
            FuncionarioLista = new List<FuncionarioModel>();
        }
    }
}