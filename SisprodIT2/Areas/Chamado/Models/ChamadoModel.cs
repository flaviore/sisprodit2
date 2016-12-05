using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SisprodIT2.Areas.Funcionario.Models;
using SisprodIT2.Areas.Categoria.Models;
using SisprodIT2.Models;
using SisprodIT2.Areas.Comentario.Models;
using SisprodIT2.Areas.Finalizacao.Models;
using System.ComponentModel.DataAnnotations;

namespace SisprodIT2.Areas.Chamado.Models
{
    public class ChamadoModel : BaseCadastro
    {
        [Display(Name="ID")]
        public int ChamadoModelId { get; set; }

        [Display(Name = "Título")]
        public string Titulo { get; set; }

        [Display(Name = "Revisão")]
        public int Revisao { get; set; }

        [Display(Name = "Status")]
        public string Status { get; set; }

        [Display(Name = "Descrição do Problema")]
        public string Descricao { get; set; }

        [Display(Name = "Categoria")]
        public int CategoriaModelId { get; set; }

        [Display(Name = "Criador do Chamado")]
        public int FuncionarioCriadorId { get; set; }

        [Display(Name = "Atribuido a")]
        public int FuncionarioResponsavelId { get; set; }

        [Display(Name = "Cod Finalização")]
        public int FinalizacaoModelId { get; set; }

        public virtual FuncionarioModel FuncionarioCriador { get; set; }
        public virtual FuncionarioModel FuncionarioResponsavel { get; set; }
        public virtual CategoriaModel Categoria { get; set; }
        public virtual FinalizacaoModel Finalizacao { get; set; }
        public virtual ICollection<ComentarioModel> ComentarioLista { get; set; }

        public ChamadoModel()
        {
            ComentarioLista = new List<ComentarioModel>();
            FuncionarioCriador = new FuncionarioModel();
            FuncionarioResponsavel = new FuncionarioModel();
            Finalizacao = new FinalizacaoModel();
            Categoria = new CategoriaModel();
        }
    }
}