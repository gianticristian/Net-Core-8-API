using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using Net_Core_8_API.Context;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Variable para la conexion
var connectionString = builder.Configuration.GetConnectionString("Connection");

// Registrar servicio para la conexion
builder.Services.AddDbContext<AppDbContext>(options => options.UseSqlServer(connectionString));

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "Nombre de tu API", Version = "v1" });

    // Configurar la inclusión de comentarios XML en Swagger
    var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
    var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
    c.IncludeXmlComments(xmlPath);
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();

app.MapControllers();

app.Run();
