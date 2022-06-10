using FluentValidation.Results;
using PsicoSoft.Core.Messages;
using System.Threading.Tasks;

namespace PsicoSoft.Core.Mediator
{
    public interface IMediatorHandler
    {
        Task PublicarEvento<T>(T evento) where T : Event;

        Task<ValidationResult> EnviarComando<T>(T comando) where T : Command;
    }
}
