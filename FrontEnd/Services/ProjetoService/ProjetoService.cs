using System.Text;
using System.Text.Json;
using BusinessLogic.Entities;

namespace FrontEnd.Services.ProjetoService;

public class ProjetoService : IProjetoService
{
    private readonly HttpClient _httpClient;

    public ProjetoService(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public async Task<IEnumerable<Projeto>?> AllProjetos()
    {
        try
        {
            var apiResponse = await _httpClient.GetStreamAsync("api/Projeto");

            var projetos = await JsonSerializer.DeserializeAsync<IEnumerable<Projeto>>(apiResponse, new JsonSerializerOptions()
            {
                PropertyNameCaseInsensitive = true
            });

            return projetos;
        }
        catch (Exception e)
        {
            Console.WriteLine($"Erro: {e.Message}");
            throw;
        }
    }

    public async Task<Projeto?> GetProjeto(Guid id)
    {
        try
        {
            var response = await _httpClient.GetStreamAsync($"api/Projeto/{id}");

            var projeto = await JsonSerializer.DeserializeAsync<Projeto>(response, new JsonSerializerOptions()
            {
                PropertyNameCaseInsensitive = true
            });

            return projeto;
        }
        catch (Exception e)
        {
            Console.WriteLine($"Erro: {e.Message}");
            throw;
        }
    }

    public async Task<bool> AddProjeto(Projeto projeto)
    {
        try
        {
            var itemJson = new StringContent(JsonSerializer.Serialize(projeto), Encoding.UTF8, "application/json");

            var response = await _httpClient.PostAsync("api/Projeto", itemJson);

            return response.IsSuccessStatusCode;
        }
        catch (Exception e)
        {
            Console.WriteLine($"Erro: {e.Message}");
            throw;
        }
    }

    public async Task<bool> UpdateProjeto(Guid id, Projeto projeto)
    {
        try
        {
            var itemJson = new StringContent(JsonSerializer.Serialize(projeto), Encoding.UTF8, "application/json");

            var response = await _httpClient.PutAsync($"api/Projeto/{id}", itemJson);
            
            return response.IsSuccessStatusCode;
        }
        catch (Exception e)
        {
            Console.WriteLine($"Erro: {e.Message}");
            throw;
        }
    }

    public async Task<bool> DeleteProjeto(Guid id)
    {
        try
        {
            var response = await _httpClient.DeleteAsync($"api/Projeto/{id}");

            return response.IsSuccessStatusCode;
        }
        catch (Exception e)
        {
            Console.WriteLine($"Erro: {e.Message}");
            throw;
        }
    }
}