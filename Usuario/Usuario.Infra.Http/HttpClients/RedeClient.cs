using System;
using System.Net.Http.Json;
using Microsoft.Extensions.Configuration;
using Usuario.Domain.Entity;
using Usuario.Domain.Interface.HttpClients;

namespace Usuario.Infra.Http.HttpClients;

public class RedeClient : IRedeClient
{
    private string? _dominio;
    private HttpClient _httpClient;

    public RedeClient(IConfiguration configuration, HttpClient httpClient)
    {
        _dominio = configuration["Api:Dominio"];
        _httpClient = httpClient;
    }

    public async Task<Rede> ObterRede(int id)
    {
        var url = _dominio + "";
        var response = await _httpClient.PostAsJsonAsync(url, new { id = id });

        var result = await response.Content.ReadFromJsonAsync<Rede>();
        return response.IsSuccessStatusCode ? result : new Rede();
    }
}
