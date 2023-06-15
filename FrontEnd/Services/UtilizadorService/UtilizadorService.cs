using System.Net.Http.Headers;
using BusinessLogic.Entities;
using Microsoft.AspNetCore.Components;
using System.Net.Http.Json;
using System.Net.Http;
using System;
using System.Threading.Tasks;

namespace FrontEnd.Services.UtilizadorService;

public class UtilizadorService : IUtilizadorService
{
    private readonly HttpClient _http;
    private readonly NavigationManager _navigationManager;

    public UtilizadorService(HttpClient http, NavigationManager navigationManger)
    {
        _http = http;
        _navigationManager = navigationManger;
    }

    public List<Utilizador> Utilizadores { get; set; } = new List<Utilizador>();
    //public Utilizador[]? Utilizadors;
    
    public async Task GetUtilizadores()
    {
        var result = await _http.GetFromJsonAsync<List<Utilizador>>("api/Utilizador");
        if (result is not null)
        {
            Utilizadores = result;
        }
        //return result;

        //Utilizadores = await _http.GetFromJsonAsync<List<Utilizador>>("api/Utilizador/GetAllUtilizadores");

        /*var response = await _http.GetAsync("api/Utilizador/GetAllUtilizadores");
        if (response.IsSuccessStatusCode)
        {
            var json = await response.Content.ReadAsStringAsync();
            Utilizadores = JsonSerializer.Deserialize<List<Utilizador>>(json);
        }*/

        /*try
        {
            var response = await _http.GetAsync("api/Utilizador/GetAllUtilizadores");
            response.EnsureSuccessStatusCode();

            var result = await response.Content.ReadFromJsonAsync<List<Utilizador>>();
            if (result is not null)
            {
                Utilizadores = result;
            }
        }
        catch (Exception ex)
        {
            // Handle or log the exception
            Console.WriteLine($"Error getting utilizadores: {ex.Message}");
        }*/

        /*try
        {
            var response = await _http.GetAsync("api/Utilizador/GetAllUtilizadores");
            response.EnsureSuccessStatusCode();

            var responseContent = await response.Content.ReadFromJsonAsync();

            // Check if the response content starts with '<', indicating non-JSON data
            if (responseContent.StartsWith("<"))
            {
                // Handle the error appropriately (e.g., display an error message)
                Console.WriteLine("Invalid response format: HTML or XML detected.");
                return;
            }

            var result = JsonSerializer.Deserialize<List<Utilizador>>(responseContent);
            if (result is not null)
            {
                Utilizadores = result;
            }
        }
        catch (Exception ex)
        {
            // Handle or log the exception
            Console.WriteLine($"Error getting utilizadores: {ex.Message}");
        }*/

        /*try
        {
            var response = await _http.GetAsync("api/Utilizador/GetAllUtilizadores");
            response.EnsureSuccessStatusCode();

            /*var responseContent = await response.Content.ReadAsStringAsync();

            // Check if the response content starts with '<', indicating non-JSON data
            if (responseContent.StartsWith("<"))
            {
                // Handle the error appropriately (e.g., display an error message)
                Console.WriteLine("Invalid response format: HTML or XML detected.");
                Utilizadores = new List<Utilizador>(); // Set an empty list
                return;
            }#1#

            var result = await response.Content.ReadFromJsonAsync<List<Utilizador>>();
            if (result is not null)
            {
                Utilizadores = result;
            }
            else
            {
                Utilizadores = new List<Utilizador>(); // Set an empty list
            }
        }
        catch (Exception ex)
        {
            // Handle or log the exception
            Console.WriteLine($"Error getting utilizadores: {ex.Message}");
            Utilizadores = new List<Utilizador>(); // Set an empty list
        }*/
        /*var response = await _http.GetJsonAsync<string>();
        return JsonConvert.DeserializeObject<List<Utilizador>>(response);*/
        
        /*try
        {
            // Set the expected response content type to JSON
            _http.DefaultRequestHeaders.Accept.Clear();
            _http.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            // Make the GET request
            HttpResponseMessage response = await _http.GetAsync("api/Utilizador");

            // Check if the response is successful
            response.EnsureSuccessStatusCode();

            // Read the response content as JSON
            BusinessLogic.Entities.Utilizador jsonData = await response.Content.ReadAsAsync<BusinessLogic.Entities.Utilizador>();

            return jsonData;
        }
        catch (Exception ex)
        {
            // Handle any exceptions or errors
            Console.WriteLine("An error occurred while retrieving JSON data: " + ex.Message);
            throw;
        }*/
    }

    public Task<Utilizador?> GetUtilizadorById(Guid id)
    {
        throw new NotImplementedException();
    }

    public Task CreateUtilizador(Utilizador utilizador)
    {
        throw new NotImplementedException();
    }

    public Task UpdateUtilizador(Guid id, Utilizador utilizador)
    {
        throw new NotImplementedException();
    }

    public Task DeleteUtilizador(Guid id)
    {
        throw new NotImplementedException();
    }
}