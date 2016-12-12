using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SisprodIT2.Areas.Funcionario.Models;
using SisprodIT2.Areas.Chamado.Models;

namespace SisprodIT2.Areas.Relatorio.Models
{
    public class QtdChamadosViewModel
    {
        public string Name { get; set; }
        public double Y { get; set; }
    }

    public class QtdAtendimentoUsuarioViewModel
    {
        public string usuario { get; set; }
        public int total { get; set; }
    }
}
