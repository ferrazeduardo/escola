using System.Diagnostics.CodeAnalysis;
using Microsoft.AspNetCore.TestHost;
using Microsoft.Extensions.Http;

namespace Rede.E2ETest.Base;

public class TestServerHttpMessageHandlerBuilder : HttpMessageHandlerBuilder
{
    public TestServerHttpMessageHandlerBuilder(TestServer testServer)
    {
        PrimaryHandler = testServer.CreateHandler();
    }
    
    public override HttpMessageHandler Build()
    {
        if (PrimaryHandler == null)
        {
            throw new InvalidOperationException("PrimaryHandler is null");
        }
        
        return CreateHandlerPipeline(PrimaryHandler, AdditionalHandlers);
        ;
    }

    public override IList<DelegatingHandler> AdditionalHandlers { get; }
    [DisallowNull] public override string? Name { get; set; }
    public override HttpMessageHandler PrimaryHandler { get; set; }
}