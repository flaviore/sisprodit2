using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SisprodIT2.Models;
using SisprodIT2.Areas.Chamado.Models;
using SisprodIT2.Areas.Funcionario.Models;

namespace SisprodIT2.Areas.Comentario.Models
{
    public class ComentarioModel : BaseCadastro
    {
        public int ComentarioModelId { get; set; }
        public string Comentario { get; set; }
        public int Ordem { get; set; }
        public int ChamadoModelId { get; set; }
        public virtual ChamadoModel Chamado { get; set; }
        public virtual FuncionarioModel FuncionarioAtualizador { get; set; }
    }
}