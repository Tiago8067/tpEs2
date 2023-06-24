using System.Text;
using System.Text.Json;

namespace FrontEnd.Services.TarefaService;

public class TarefaService : ITarefaService
{
    private readonly HttpClient _httpClient;

    public TarefaService(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public async Task<IEnumerable<Tarefa>?> AllTarefas()
    {
        try
        {
            var apiResponse = await _httpClient.GetStreamAsync("api/Tarefa");

            var tasks = await JsonSerializer.DeserializeAsync<IEnumerable<Tarefa>>(apiResponse, new JsonSerializerOptions()
            {
                PropertyNameCaseInsensitive = true
            });

            return tasks;
        }
        catch (Exception e)
        {
            Console.WriteLine($"Erro: {e.Message}");
            throw;
        }
    }

    public async Task<Tarefa?> GetTarefa(Guid id)
    {
        try
        {
            var response = await _httpClient.GetStreamAsync($"api/Tarefa/{id}");

            var task = await JsonSerializer.DeserializeAsync<Tarefa>(response, new JsonSerializerOptions()
            {
                PropertyNameCaseInsensitive = true
            });

            return task;
        }
        catch (Exception e)
        {
            Console.WriteLine($"Erro: {e.Message}");
            throw;
        }
    }

    public async Task<bool> AddTarefa(Tarefa tarefa)
    {
        try
        {
            var itemJson = new StringContent(JsonSerializer.Serialize(tarefa), Encoding.UTF8, "application/json");

            var response = await _httpClient.PostAsync("api/Tarefa", itemJson);

            return response.IsSuccessStatusCode;
        }
        catch (Exception e)
        {
            Console.WriteLine($"Erro: {e.Message}");
            throw;
        }
    }

    public async Task<bool> UpdateTarefa(Guid id, Tarefa tarefa)
    {
        try
        {
            var itemJson = new StringContent(JsonSerializer.Serialize(tarefa), Encoding.UTF8, "application/json");

            var response = await _httpClient.PutAsync($"api/Tarefa/{id}", itemJson);

            return response.IsSuccessStatusCode;
        }
        catch (Exception e)
        {
            Console.WriteLine($"Erro: {e.Message}");
            throw;
        }
    }

    public async Task<bool> DeleteTarefa(Guid id)
    {
        try
        {
            var response = await _httpClient.DeleteAsync($"api/Tarefa/{id}");

            return response.IsSuccessStatusCode;
        }
        catch (Exception e)
        {
            Console.WriteLine($"Erro: {e.Message}");
            throw;
        }
    }
}