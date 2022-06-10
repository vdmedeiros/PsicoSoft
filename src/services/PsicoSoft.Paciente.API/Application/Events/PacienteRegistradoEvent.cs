using PsicoSoft.Core.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PsicoSoft.Pacientes.API.Application.Events
{
    public class PacienteRegistradoEvent : Event
    {
        public Guid Id { get; private set; }
        public string Nome { get; private set; }
        public string Email { get; private set; }
        public string RG { get; private set; }
        public string CPF { get; private set; }
        public DateTime DataNascimento { get; private set; }

        public PacienteRegistradoEvent(Guid id, string nome, string email, string cpf, DateTime dataNascimento)
        {
            AggregateId = id;
            Id = id;
            Nome = nome;
            Email = email;
            CPF = cpf;
            DataNascimento = dataNascimento;
        }
    }
}
