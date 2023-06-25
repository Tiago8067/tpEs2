using System.Text;
using System.Text.Json;

namespace FrontEnd.Services.UtilizadorService;

public class UtilizadorService : IUtilizadorService
{
    private readonly HttpClient _httpClient;

    public UtilizadorService(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public async Task<IEnumerable<Usermodel>?> All()
    {
        try
        {
            var apiResponse = await _httpClient.GetStreamAsync("api/Utilizador");

            var utilizadors = await JsonSerializer.DeserializeAsync<IEnumerable<Usermodel>>(apiResponse, new JsonSerializerOptions()
            {
                PropertyNameCaseInsensitive = true
            });

            return utilizadors;
        }
        catch (Exception e)
        {
            Console.WriteLine($"Erro: {e.Message}");
            throw;
        }
    }

    public async Task<Usermodel?> GetUtilizador(Guid id)
    {
        try
        {
            var response = await _httpClient.GetStreamAsync($"api/Utilizador/{id}");

            var utilizador = await JsonSerializer.DeserializeAsync<Usermodel>(response, new JsonSerializerOptions()
            {
                PropertyNameCaseInsensitive = true
            });

            return utilizador;
        }
        catch (Exception e)
        {
            Console.WriteLine($"Erro: {e.Message}");
            throw;
        }
    }

    /*public async Task<bool> AddUtilizador(Usermodel utilizador)
    {
        try
        {
            var itemJson = new StringContent(JsonSerializer.Serialize(utilizador), Encoding.UTF8, "application/json");

            var response = await _httpClient.PostAsync("api/Utilizador/AddUtilizador", itemJson);

            return response.IsSuccessStatusCode;
        }
        catch (Exception e)
        {
            Console.WriteLine($"Erro: {e.Message}");
            throw;
        }
    }*/
    
    public async Task<ServiceResponse<Guid>> AddUtilizador(Userregisto request)
    {
        var result = await _httpClient.PostAsJsonAsync("api/Utilizador/AddUtilizador", request);
        return await result.Content.ReadFromJsonAsync<ServiceResponse<Guid>>();
    }

    public async Task<bool> UpdateUtilizador(Guid id, Usermodel utilizador)
    {
        try
        {
            var itemJson = new StringContent(JsonSerializer.Serialize(utilizador), Encoding.UTF8, "application/json");

            var response = await _httpClient.PutAsync($"api/Utilizador/{id}", itemJson);

            return response.IsSuccessStatusCode;
        }
        catch (Exception e)
        {
            Console.WriteLine($"Erro: {e.Message}");
            throw;
        }
    }

    public async Task<bool> DeleteUtilizador(Guid id)
    {
        try
        {
            var response = await _httpClient.DeleteAsync($"api/Utilizador/{id}");

            return response.IsSuccessStatusCode;
        }
        catch (Exception e)
        {
            Console.WriteLine($"Erro: {e.Message}");
            throw;
        }
    }
}