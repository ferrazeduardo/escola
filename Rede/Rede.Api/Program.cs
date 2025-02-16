using Rede.Api;
using  Rede.Application.DependencyInjection;
using  Rede.MongoDb.DependencyInjection;
using Rede.Api.DependencyInjection;
using Rede.Api.Redes;
using Query = Rede.Api.Redes.Query;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services
    .AddApi(builder.Configuration)
    .ResolverDependencyInjectionCors()
    .AddApplication()
    .AddMongo()    
    .AddGraphQLServer()
    .AddQueryType<Query>()
    .AddMutationType<Mutation>();


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
app.MapGraphQL();
app.Run();

