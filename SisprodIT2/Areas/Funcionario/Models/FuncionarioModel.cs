using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SisprodIT2.Areas.Setor.Models;
using SisprodIT2.Areas.Email.Models;
using SisprodIT2.Areas.Perfil.Models;
using SisprodIT2.Areas.Endereco.Models;
using SisprodIT2.Areas.Telefone.Models;
using SisprodIT2.Models;
using System.ComponentModel.DataAnnotations;
using SisprodIT2.Areas.Chamado.Models;

namespace SisprodIT2.Areas.Funcionario.Models
{
    public class FuncionarioModel : BaseCadastro
    {
        public int FuncionarioModelId { get; set; }

        [Display(Name="Nome")]
        public string Nome { get; set; }

        [Display(Name="CPF")]
        public string CPF { get; set; }

        [Display(Name = "RG")]
        public string RG { get; set; }

        [Display(Name = "Data de Nascimento")]
        public DateTime Nascimento { get; set; }

        [Display(Name = "Altura")]
        public float Altura { get; set; }

        [Display(Name = "Usuário")]
        public string Usuario { get; set; }

        [Display(Name = "Senha")]
        public string Senha { get; set; }

        [Display(Name = "Perfil")]
        public int PerfilModelId { get; set; }

        [Display(Name = "Setor")]
        public int SetorModelId { get; set; }
        
        public virtual SetorModel Setor { get; set; }
        public virtual PerfilModel Perfil { get; set; }
        public ICollection<EmailModel> EmailLista { get; set; }
        public ICollection<EnderecoModel> EnderecoLista { get; set; }
        public ICollection<TelefoneModel> TelefoneLista { get; set; }
        public ICollection<ChamadoModel> ChamadoLista { get; set; }

        public FuncionarioModel()
        {
            TelefoneLista = new List<TelefoneModel>();
            EnderecoLista = new List<EnderecoModel>();
            EmailLista = new List<EmailModel>();
            ChamadoLista = new List<ChamadoModel>();
        }
    }
}