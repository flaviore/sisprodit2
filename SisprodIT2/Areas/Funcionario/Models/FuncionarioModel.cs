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

namespace SisprodIT2.Areas.Funcionario.Models
{
    public class FuncionarioModel : BaseCadastro
    {
        public int FuncionarioModelId { get; set; }
        public string Nome { get; set; }
        public string CPF { get; set; }
        public string RG { get; set; }
        public DateTime Nascimento { get; set; }
        public float Altura { get; set; }
        public string Usuario { get; set; }
        public string Senha { get; set; }
        public int PerfilModelId { get; set; }
        public int SetorModelId { get; set; }
        public virtual SetorModel Setor { get; set; }
        public virtual PerfilModel Perfil { get; set; }
        public ICollection<EmailModel> EmailLista { get; set; }
        public ICollection<EnderecoModel> EnderecoLista { get; set; }
        public ICollection<TelefoneModel> TelefoneLista { get; set; }

        public FuncionarioModel()
        {
            TelefoneLista = new List<TelefoneModel>();
            EnderecoLista = new List<EnderecoModel>();
            EmailLista = new List<EmailModel>();
        }
    }
}