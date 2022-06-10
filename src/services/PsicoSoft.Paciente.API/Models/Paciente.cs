using PsicoSoft.Core.DomainObjects;
using System;

namespace PsicoSoft.Pacientes.API.Models
{
    public class Paciente : Entity, IAggregateRoot
    {
        public string Nome { get; set; }
        public Email Email { get; private set; }
        public string RG { get; set; }        
        public Cpf CPF { get; private set; }
        public DateTime DataNascimento { get; set; }
        public bool Ativo { get; set; }
        public Endereco Endereco { get; private set; }
        // EF Relation
        protected Paciente() { }

        public Paciente(Guid id, string nome, string email, string rg, string cpf, DateTime dataNascimento)
        {
            Id = id;
            Nome = nome;
            RG = rg;
            CPF = new Cpf(cpf);
            Email = new Email(email);
            DataNascimento = dataNascimento;
        }
        public void TrocarEmail(string email)
        {
            Email = new Email(email);
        }
        public void AtribuirEndereco(Endereco endereco)
        {
            Endereco = endereco;
        }
    }
}
