using PsicoSoft.Core.Data;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PsicoSoft.Pacientes.API.Models
{
    public interface IPacienteRepository : IRepository<Paciente>
    {
        Task<IEnumerable<Paciente>> ObterTodos();
        Task<Paciente> ObterPorId(Guid id);
        void Adicionar(Paciente paciente);
        void Atualizar(Paciente paciente);
    }
}
