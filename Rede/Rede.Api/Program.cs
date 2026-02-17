using Rede.Api;
using  Rede.Application.DependencyInjection;
using Rede.Api.DependencyInjection;
using Rede.Api.Filters;
using Rede.Api.Redes;
using Rede.Data.EF;
using Rede.Messaging.DependencyInjection;
using Query = Rede.Api.Redes.Query;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddControllers();
builder.Services
    .AddApi(builder.Configuration)
    .ResolverDependencyInjectionCors()
    .AddApplication()
    .AddRabbitMQ(builder.Configuration)
    .AddDataEf(builder.Configuration)
    .AddGraphQLServer()
    .AddQueryType<Query>()
    .AddMutationType<Mutation>()
    .AddErrorFilter<GraphqlErrorFilter>();


var app = builder.Build();


// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseCors(options =>
    options.AllowAnyOrigin()
        .AllowAnyHeader()
        .AllowAnyMethod());
    
app.UseHttpsRedirection();
app.MapControllers();
// app.MapGraphQL();
app.Run();

public partial class Program { }