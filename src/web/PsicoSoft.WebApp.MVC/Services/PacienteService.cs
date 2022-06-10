using PsicoSoft.WebApp.MVC.Models;
using System;
using System.Collections.Generic;
using Microsoft.Extensions.Options;
using System.Net.Http;
using System.Threading.Tasks;
using PsicoSoft.WebApp.MVC.Extensions;

namespace PsicoSoft.WebApp.MVC.Services
{
    public class PacienteService : Service, IPacienteService
    {
        private readonly HttpClient _httpClient;

        public PacienteService(HttpClient httpClient,
                               IOptions<AppSettings> settings)
        {
            httpClient.BaseAddress = new Uri(settings.Value.PacienteUrl);
            _httpClient = httpClient;
        }
        public async Task<PacienteViewModel> ObterPorId(Guid id)
        {
            var response = await _httpClient.GetAsync($"pacientes/{id}");
            TratarErrosResponse(response);
            return await DeserializarObjetoResponse<PacienteViewModel>(response);

        }

        public async Task<IEnumerable<PacienteViewModel>> ObterTodos()
        {
            var response = await _httpClient.GetAsync("pacientes/");
            TratarErrosResponse(response);
            return await DeserializarObjetoResponse<IEnumerable<PacienteViewModel>>(response);
        }
    }
}
