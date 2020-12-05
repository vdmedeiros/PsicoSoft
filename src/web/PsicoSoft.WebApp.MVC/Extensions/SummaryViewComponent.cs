using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace PsicoSoft.WebApp.MVC.Extensions
{
    public class SummaryViewComponent : ViewComponent
    {
        public async Task<IViewComponentResult> InvokeAsync()
        {
            return View();
        }
    }
}