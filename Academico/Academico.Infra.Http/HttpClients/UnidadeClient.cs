using System;
using System.Net.Http.Json;
using Academico.Domain.DataTransferObject;
using Academico.Domain.Entity;
using Academico.Domain.Interface.HttpClients;
using Microsoft.Extensions.Configuration;

namespace Academico.Infra.Http.HttpClients;

public class UnidadeClient : IUnidadeClient
{
    private string? _dominio;
    private HttpClient _httpClient;

    public UnidadeClient(IConfiguration configuration, HttpClient httpClient)
    {
        _dominio = configuration["Api:Dominio:Rede"];
        _httpClient = httpClient;
    }


    public async Task<Unidade> Obter(int unidadeId)
    {
        var url = _dominio + "Unidade/Obter";
        var response = await _httpClient.PostAsJsonAsync(url, new { id = unidadeId });

        var result = await response.Content.ReadFromJsonAsync<UnidadeDto>();
        return response.IsSuccessStatusCode ? new Unidade().FromRedeDto(result) : new Unidade();
    }
}
