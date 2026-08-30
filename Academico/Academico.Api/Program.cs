using Academico.Api.Middleware;
using Academico.Application.DependencyInjection;
using Academico.Data.EF.DependencyInjection;
using Academico.Infra.Http.DependencyInjection;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();
builder.Services.AddControllers(options => options.Filters.Add(typeof(GlobalErrorHandlingMiddleware)));
builder.Services.AddApplication().AddApplication().AddDataEf(builder.Configuration).AddInfraHttp();
var app = builder.Build();

// Configure the HTTP request pipeline.
// if (app.Environment.IsDevelopment())
// {
app.MapOpenApi();
// }

app.UseHttpsRedirection();
app.MapControllers();



app.Run();


