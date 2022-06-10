using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PsicoSoft.Core.Mediator;
using PsicoSoft.Pacientes.API.Application.Commands;
using PsicoSoft.Pacientes.API.Models;
using PsicoSoft.WebApi.Core;
using PsicoSoft.WebApi.Core.Identidade;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PsicoSoft.Pacientes.API.Controllers
{
    [Authorize]
    public class PacienteController : MainController
    {
        private readonly IPacienteRepository _pacienteRepository;
        private readonly IMediatorHandler _mediatorHandler;

        public PacienteController(IPacienteRepository pacienteRepository, IMediatorHandler mediatorHandler)
        {
            _mediatorHandler = mediatorHandler;
            _pacienteRepository = pacienteRepository;
        }

        [HttpGet("pacientes")]        
        public async Task<IEnumerable<Models.Paciente>> Index()
        {
            var retorno = await _pacienteRepository.ObterTodos();
            return retorno;
        }

        [HttpGet("paciente/{id}")]
        [ClaimsAuthorize("Pacientes", "Ler")]
        public async Task<Models.Paciente> Paciente(Guid id)
        {
            var retorno = await _pacienteRepository.ObterPorId(id);
            return retorno;
        }

        [HttpPut("adicionar")]
        public ActionResult Adicionar(Models.Paciente paciente)
        {
            var resultado = _mediatorHandler.EnviarComando(new RegistrarPacienteCommand(Guid.NewGuid(), 
                                                                        paciente.Nome, 
                                                                        paciente.Email.ToString(), 
                                                                        paciente.RG, 
                                                                        paciente.CPF.ToString(), 
                                                                        paciente.DataNascimento));
            return CustomResponse(resultado);
        }
    }
}
