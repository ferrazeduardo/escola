using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.Extensions.DependencyInjection;
using Rede.E2ETest.Base;
using Xunit;

namespace Rede.E2ETest.Graphql.Rede.Common;

public class RedeTestFixture
{
    public CustomWebApplicationFactory<Program> WebAppFacotory { get; private set; } = null!;
    
    public RedeClient GraphqlClient { get; private set; } = null!;

    //classe criada para subir a aplicação utilizando o web application factory
    public RedeTestFixture()
    {
        WebAppFacotory = new CustomWebApplicationFactory<Program>();
        //com o httpclient ja conseguimos fazer chamadas para a nossa api
        var httpClient = WebAppFacotory.CreateClient(new WebApplicationFactoryClientOptions
        {
            BaseAddress = new Uri(WebAppFacotory.baseUrl)
        });
        //httpclient do strawberrychake tem que usar o httpclient do webapplication server
        GraphqlClient = WebAppFacotory.Services.GetRequiredService<RedeClient>();

    }


}

[CollectionDefinition(nameof(RedeTestFixture))]
public class RedeTestFixtureCollection : ICollectionFixture<RedeTestFixture>{}