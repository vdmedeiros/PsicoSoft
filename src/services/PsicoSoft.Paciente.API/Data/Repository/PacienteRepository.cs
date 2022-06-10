using Microsoft.EntityFrameworkCore;
using PsicoSoft.Core.Data;
using PsicoSoft.Pacientes.API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PsicoSoft.Pacientes.API.Data.Repository
{
    public class PacienteRepository : IPacienteRepository
    {
        public readonly PacienteContext _context;
        public IUnitOfWork UnitOfWork => _context;

        public PacienteRepository(PacienteContext context)
        {
            _context = context;
        }
        public void Adicionar(Models.Paciente paciente)
        {
            _context.Pacientes.Add(paciente);
        }

        public void Atualizar(Models.Paciente paciente)
        {
            _context.Pacientes.Update(paciente);
        }       

        public async Task<Models.Paciente> ObterPorId(Guid id)
        {
            return await _context.Pacientes.Include(e => e.Endereco).Where(p => p.Id == id).FirstOrDefaultAsync();            
        }

        public async Task<IEnumerable<Models.Paciente>> ObterTodos()
        {
            return await _context.Pacientes.Include(e => e.Endereco).AsNoTracking().ToListAsync();
        }
        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
