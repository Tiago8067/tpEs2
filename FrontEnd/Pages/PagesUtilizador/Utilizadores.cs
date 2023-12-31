using FrontEnd.Services.UtilizadorService;
using Microsoft.AspNetCore.Components;

namespace FrontEnd.Pages.PagesUtilizador;

public partial class Utilizadores
{
   [Inject]
   private IUtilizadorService UtilizadorService { get; set; }

   public IEnumerable<Usermodel> Utilizadors { get; set; } = new List<Usermodel>();

   protected async override Task OnInitializedAsync()
   {
      var apiUtilizadors = await UtilizadorService.All();

      if (apiUtilizadors != null && apiUtilizadors.Any())
      {
         Utilizadors = apiUtilizadors;
      }
   }
}