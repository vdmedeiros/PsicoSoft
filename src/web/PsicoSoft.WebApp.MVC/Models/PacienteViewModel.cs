using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PsicoSoft.WebApp.MVC.Models
{
    public class PacienteViewModel
    {
        public Guid Id { get; set; }
        public string Nome { get; set; }
        public string RG { get; set; }
        public CPFViewModel CPF { get; set; }
        public string Email { get; set; }
        public DateTime DataNascimento { get; set; }
        public bool Ativo { get; set; }
        public EnderecoViewModel Endereco { get; private set; }
    }
}
