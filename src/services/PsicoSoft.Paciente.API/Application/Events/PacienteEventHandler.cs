using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace PsicoSoft.Pacientes.API.Application.Events
{
    public class PacienteEventHandler : INotificationHandler<PacienteRegistradoEvent>
    {
        public Task Handle(PacienteRegistradoEvent notification, CancellationToken cancellationToken)
        {
            return Task.CompletedTask;
        }
    }
}
