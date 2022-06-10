using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PsicoSoft.WebApp.MVC.Models
{
    public class EnderecoViewModel
    {
        public string Logradouro { get; private set; }
        public string Numero { get; private set; }
        public string Complemento { get; private set; }
        public string Bairro { get; private set; }
        public string Cep { get; private set; }
        public string Cidade { get; private set; }
        public string Estado { get; private set; }
        public Guid PacienteId { get; private set; }
    }
}
