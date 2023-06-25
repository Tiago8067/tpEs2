using Microsoft.AspNetCore.Components;

namespace FrontEnd.Pages.PagesUserManager;

public partial class UtilUm
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