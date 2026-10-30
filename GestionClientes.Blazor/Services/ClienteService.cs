using GestionClientes.Blazor.Models;
using System.Net.Http.Json;

namespace GestionClientes.Blazor.Services;

public class ClienteService
{
    private readonly HttpClient _http;

    public ClienteService(HttpClient http)
    {
        _http = http;
    }

    public async Task<List<Cliente>> GetClientesAsync()
    {
        return await _http.GetFromJsonAsync<List<Cliente>>("api/clientes")
               ?? new List<Cliente>();
    }

    public async Task<Cliente?> GetClienteAsync(int id)
    {
        return await _http.GetFromJsonAsync<Cliente>($"api/clientes/{id}");
    }

    public async Task<bool> CrearClienteAsync(Cliente cliente)
    {
        var response = await _http.PostAsJsonAsync("api/clientes", cliente);
        return response.IsSuccessStatusCode;
    }

    public async Task<bool> ActualizarClienteAsync(Cliente cliente)
    {
        var response = await _http.PutAsJsonAsync(
            $"api/clientes/{cliente.Id_cliente}", cliente);
        return response.IsSuccessStatusCode;
    }

    public async Task<bool> EliminarClienteAsync(int id)
    {
        var response = await _http.DeleteAsync($"api/clientes/{id}");
        return response.IsSuccessStatusCode;
    }
}
