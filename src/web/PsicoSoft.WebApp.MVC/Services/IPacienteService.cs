using PsicoSoft.WebApp.MVC.Models;
using Refit;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PsicoSoft.WebApp.MVC.Services
{
    public interface IPacienteService
    {
        Task<IEnumerable<PacienteViewModel>> ObterTodos();
        Task<PacienteViewModel> ObterPorId(Guid id);

    }

    public interface IPacienteServiceRefit
    {
        [Get("/pacientes/")]
        Task<IEnumerable<PacienteViewModel>> ObterTodos();
        [Get("/paciente/{id}")]
        Task<PacienteViewModel> ObterPorId(Guid id);

    }
}
