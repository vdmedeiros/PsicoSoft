using FluentValidation;
using PsicoSoft.Core.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PsicoSoft.Pacientes.API.Application.Commands
{
    public class RegistrarPacienteCommand : Command
    {
        public Guid Id { get; private set; }
        public string Nome { get; private set; }
        public string Email { get; private set; }
        public string RG { get; private set; }
        public string CPF { get; private set; }
        public DateTime DataNascimento { get; private set; }

        public RegistrarPacienteCommand(Guid id, string nome, string email, string rg, string cpf, DateTime dataNascimento)
        {
            AggregateId = id;
            Id = id;
            Nome = nome;
            Email = email;
            RG = rg;
            CPF = cpf;
            DataNascimento = dataNascimento;
        }

        public override bool EhValido()
        {
            ValidationResult = new RegistrarPacienteValidation().Validate(this);
            return ValidationResult.IsValid;
        }

        public class RegistrarPacienteValidation : AbstractValidator<RegistrarPacienteCommand>
        {
            public RegistrarPacienteValidation()
            {
                RuleFor(c => c.Id)
                        .NotEqual(Guid.Empty)
                        .WithMessage("Id do paciente inválido");

                RuleFor(c => c.Nome)
                            .NotEmpty()
                            .WithMessage("O nome do cliente não foi informado");

                RuleFor(c => c.CPF)
                            .Must(TerCpfValido)
                            .WithMessage("O CPF informado não é válido.");

                RuleFor(c => c.Email)
                            .Must(TerEmailValido)
                            .WithMessage("O e-mail informado não é válido.");
            }

            protected static bool TerCpfValido(string cpf)
            {
                return Core.DomainObjects.Cpf.Validar(cpf);
            }

            protected static bool TerEmailValido(string email)
            {
                return Core.DomainObjects.Email.Validar(email);
            }
        }
    }    
}
