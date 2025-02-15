using  Rede.Application.DependencyInjection;
using  Rede.MongoDb.DependencyInjection;
using Rede.Api.DependencyInjection;
using Rede.Api.Redes;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services
    .AddApi(builder.Configuration)
    .AddApplication()
    .AddMongo()    
    .AddGraphQLServer()
    .AddQueryType<RedesQuery>()
    .AddMutationType<RedesMutation>();


var app = builder.Build();


// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.Run();

