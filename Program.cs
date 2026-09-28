using Microsoft.EntityFrameworkCore;
using Projeto.Properties;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddOpenApi();

string connection = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<AppDbContext>(options => options.UseSqlServer(connection));
var app = builder.Build();

app.MapOpenApi();
app.UseSwaggerUI(c => {c.SwaggerEndpoint("/swagger/v1/swagger.json","My API V1");});
app.UseHttpsRedirection();
app.Run();