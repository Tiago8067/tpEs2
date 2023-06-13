using System.Net.Http.Json;
using BusinessLogic.Entities;

namespace FrontEnd.Services.UtilizadorService;

public class UtilizadorService : IUtilizadorService
{
    private readonly HttpClient _http;
    
    public UtilizadorService(HttpClient httpClient)
    {
        _http = httpClient;
    }
    
    public List<Utilizador> Utilizadores { get; set; } = new List<Utilizador>();
    
    public Task GetUtilizadores()
    {
        var result = await _http.GetFromJsonAsync<List<Utilizador>>("api/Authors");
        return null;
    }

    public Task<Utilizador?> GetUtilizadorById(int id)
    {
        throw new NotImplementedException();
    }

    public Task CreateUtilizador(Utilizador utilizador)
    {
        throw new NotImplementedException();
    }

    public Task UpdateUtilizador(int id, Utilizador utilizador)
    {
        throw new NotImplementedException();
    }

    public Task DeleteUtilizador(int id)
    {
        throw new NotImplementedException();
    }
}