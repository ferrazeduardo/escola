using Usuario.Api.Middlewares;
using Usuario.Application.DependencyInjection;
using Usuario.Data.EF.DependencyInjection;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddControllers();
builder.Services
        .AddApplication()
        .AddDataEf(builder.Configuration);

builder.Services.AddCors(options =>
 {
     options.AddDefaultPolicy(
         policy =>
         {
             policy.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod();

         });
 });


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseMiddleware(typeof(GlobalErrorHandlingMiddleware));
app.UseCors(options =>
      options.AllowAnyOrigin()
             .AllowAnyHeader()
             .AllowAnyMethod()
  );


app.UseHttpsRedirection();
app.MapControllers();
app.Run();
