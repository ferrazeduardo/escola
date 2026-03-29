using System;
using System.Net.Http.Json;
using Microsoft.Extensions.Configuration;
using Usuario.Domain.DataTransferObject;
using Usuario.Domain.Entity;
using Usuario.Domain.Interface.HttpClients;

namespace Usuario.Infra.Http.HttpClients;

public class RedeClient : IRedeClient
{
    private string? _dominio;
    private HttpClient _httpClient;

    public RedeClient(IConfiguration configuration, HttpClient httpClient)
    {
        _dominio = configuration["Api:Dominio:Rede"];
        _httpClient = httpClient;
    }

    public async Task<Rede> ObterRede(int id)
    {
        var url = _dominio + "Rede/Obter";
        var response = await _httpClient.PostAsJsonAsync(url, new { id = id });

        var result = await response.Content.ReadFromJsonAsync<RedeDto>();
        return response.IsSuccessStatusCode ? new Rede().FromRedeDto(result) : new Rede();
    }
}
