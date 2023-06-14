using System.Net.Http.Json;
using System.Text.Json;
using System.Text.Json.Serialization;
using BusinessLogic.Entities;
using Radzen;

namespace FrontEnd.Services.UtilizadorService;

public class UtilizadorService : IUtilizadorService
{
    private readonly HttpClient _http;
    
    public UtilizadorService(HttpClient httpClient)
    {
        _http = httpClient;
    }
    
    public List<Utilizador> Utilizadores { get; set; } = new List<Utilizador>();
    
    public async Task GetUtilizadores()
    {
        //var result = await _http.GetFromJsonAsync<List<Utilizador>>("api/Utilizador/GetAllUtilizadores");
        //var result = await _http.GetFromJsonAsync<List<Utilizador>>($"api/Utilizador/GetAllUtilizadores");
        var result = await _http.GetStringAsync("api/Utilizador/GetAllUtilizadores");
        Utilizadores = JsonSerializer.Deserialize<List<Utilizador>>(result);
        /*if (result is not null)
        {
            Utilizadores = result;
        }*/
        
        /*var options = new JsonSerializerOptions
        {
            PropertyNameCaseInsensitive = true, // Handle case-insensitive property matching
            Converters =
            {
                new JsonStringEnumConverter() // Handle enum serialization/deserialization
            }
        };

        var response = await _http.GetAsync("api/Utilizador/GetAllUtilizadores");
        if (response.IsSuccessStatusCode)
        {
            var jsonString = await response.Content.ReadAsStringAsync();
            Utilizadores = JsonSerializer.Deserialize<List<Utilizador>>(jsonString, options);
        }
        else
        {
            // Handle error case
        }*/
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