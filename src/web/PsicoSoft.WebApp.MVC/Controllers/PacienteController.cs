using Microsoft.AspNetCore.Mvc;
using PsicoSoft.WebApi.Core.Identidade;
using PsicoSoft.WebApp.MVC.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PsicoSoft.WebApp.MVC.Controllers
{
    public class PacienteController : Controller
    {
        private readonly IPacienteService _pacienteService;

        public PacienteController(IPacienteService pacienteService)
        {
            _pacienteService = pacienteService;
        }

        [HttpGet]
        [Route("pacientes")]
        public async Task<IActionResult> Index()
        {
            var pacientes = await _pacienteService.ObterTodos();

            return View(pacientes);
        }

        [HttpGet]
        [Route("paciente/{id}")]
        public async Task<IActionResult> PacienteDetalhe(Guid id)
        {
            var paciente = await _pacienteService.ObterPorId(id);

            return View(paciente);
        }
    }
}
