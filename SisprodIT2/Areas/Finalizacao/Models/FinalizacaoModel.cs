
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SisprodIT2.Models;
using SisprodIT2.Areas.Chamado.Models;

namespace SisprodIT2.Areas.Finalizacao.Models
{
    public class FinalizacaoModel : BaseCadastro
    {
        public int FinalizacaoModelId { get; set; }
        public string Descricao { get; set; }
        public ICollection<ChamadoModel> ChamadoLista { get; set; }

        public FinalizacaoModel()
        {
            ChamadoLista = new List<ChamadoModel>();
        }
    }
}