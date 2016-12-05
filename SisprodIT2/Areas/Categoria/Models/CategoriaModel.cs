using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SisprodIT2.Models;
using SisprodIT2.Areas.Chamado.Models;

namespace SisprodIT2.Areas.Categoria.Models
{
    public class CategoriaModel : BaseCadastro
    {
        public int CategoriaModelId { get; set; }
        public string Descricao { get; set; }
        public ICollection<ChamadoModel> ChamadoLista { get; set; }

        public CategoriaModel()
        {
            ChamadoLista = new List<ChamadoModel>();
        }
    }
}