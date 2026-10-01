using Microsoft.EntityFrameworkCore;
using Projeto.Properties;
using Projeto.Repositories;
using Projeto.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddOpenApi();

string connection = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<AppDbContext>(options => options.UseSqlServer(connection));
builder.Services.AddControllers();
builder.Services.AddScoped<CategoriaR>();
builder.Services.AddScoped<CategoriaS>();
builder.Services.AddScoped<ChamadoR>();
builder.Services.AddScoped<ChamadoS>();
var app = builder.Build();

app.MapOpenApi();
app.MapControllers();
app.UseSwaggerUI(c => {c.SwaggerEndpoint("/swagger/v1/swagger.json","My API V1");});
app.UseHttpsRedirection();

app.Run();