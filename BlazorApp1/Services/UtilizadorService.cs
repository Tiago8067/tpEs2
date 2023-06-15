using BusinessLogic.Entities;

namespace BlazorApp1.Services;

public class UtilizadorService : IUtilizador
{
    private readonly HttpClient _http;

    public UtilizadorService(HttpClient http)
    {
        _http = http;
    }

    public List<Utilizador> Utilizadores { get; set; } = new List<Utilizador>();

    public async Task GetUtilizadores()
    {
        var result = await _http.GetFromJsonAsync<List<Utilizador>>("api/Utilizadores");
        if (result is not null)
        {
            Utilizadores = result;
        }
    }
}