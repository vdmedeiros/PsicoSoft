//using FluentValidation.Results;
//using MediatR;
//using Microsoft.Extensions.DependencyInjection;
//using NSE.Clientes.API.Application.Commands;
//using NSE.Clientes.API.Application.Events;
//using NSE.Clientes.API.Data;
//using NSE.Clientes.API.Data.Repository;
//using NSE.Clientes.API.Models;
//using NSE.Core.Mediator;

using FluentValidation.Results;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using PsicoSoft.Core.Mediator;
using PsicoSoft.Pacientes.API.Application.Commands;
using PsicoSoft.Pacientes.API.Application.Events;
using PsicoSoft.Pacientes.API.Data;
using PsicoSoft.Pacientes.API.Data.Repository;
using PsicoSoft.Pacientes.API.Models;

namespace PsicoSoft.Pacientes.API.Configuration
{
    public static class DependencyInjectionConfig
    {
        public static void RegisterServices(this IServiceCollection services)
        {
            services.AddScoped<IMediatorHandler, MediatorHandler>();
            services.AddScoped<IRequestHandler<RegistrarPacienteCommand, ValidationResult>, PacienteCommandHandler>();

            services.AddScoped<INotificationHandler<PacienteRegistradoEvent>, PacienteEventHandler>();

            services.AddScoped<IPacienteRepository, PacienteRepository>();
            services.AddScoped<PacienteContext>();
        }
    }
}