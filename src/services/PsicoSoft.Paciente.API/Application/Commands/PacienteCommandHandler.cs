using FluentValidation.Results;
using MediatR;
using PsicoSoft.Core.Messages;
using PsicoSoft.Pacientes.API.Application.Events;
using PsicoSoft.Pacientes.API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace PsicoSoft.Pacientes.API.Application.Commands
{
    public class PacienteCommandHandler : CommandHandler, 
                                          IRequestHandler<RegistrarPacienteCommand, ValidationResult>
    {
        private readonly IPacienteRepository _pacienteRepository;
        public PacienteCommandHandler(IPacienteRepository pacienteRepository)
        {
            _pacienteRepository = pacienteRepository;
        }

        public async Task<ValidationResult> Handle(RegistrarPacienteCommand command, CancellationToken cancellationToken)
        {
            //validar comando
            if (command.EhValido()) return command.ValidationResult;

            var paciente = new PsicoSoft.Pacientes.API.Models.Paciente(command.Id, command.Nome, command.Email, command.RG, command.CPF, command.DataNascimento);

            var pacienteExistente = await _pacienteRepository.ObterTodos();

            if(pacienteExistente != null)
            {
                AdicionarErro("Este CPF já está em uso");
                return ValidationResult;
            }

            _pacienteRepository.Adicionar(paciente);

            paciente.AdicionarEvento(new PacienteRegistradoEvent(command.Id, command.Nome, command.Email, command.CPF, command.DataNascimento));

            return await PersistirDados(_pacienteRepository.UnitOfWork);

        }
    }
}
