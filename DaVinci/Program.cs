using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using DaVinci.Database;
using DaVinci.Repository.Interfaces;
using DaVinci.Repository;
using DaVinci.Service;
using DaVinci.Service.InterfacesService;

var builder = WebApplication.CreateBuilder(args);

var connectionString = builder.Configuration.GetConnectionString("AzureDbContext");
if (string.IsNullOrWhiteSpace(connectionString))
{
    throw new InvalidOperationException("A string de conexão 'AzureDbContext' não foi configurada corretamente.");
}

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(x => x.SwaggerDoc("v1", new OpenApiInfo
{
    Title = "DaVinci Insights API",
    Version = "v1",
    Description = "API para o projeto DaVinci Insights",
    Contact = new OpenApiContact() { Email = "davinci.insights.2024@gmail.com", Name = "DaVinci Insights" }
}));

builder.Services.AddDbContext<AzureDbContext>(options =>
{
    options.UseSqlServer(connectionString);
});

// Registro dos repositórios e serviços
builder.Services.AddScoped<IClientesRepository, ClientesRepository>();
builder.Services.AddScoped<IClientesService, ClientesService>();
builder.Services.AddScoped<IProdutosRepository, ProdutosRepository>();
builder.Services.AddScoped<IProdutosService, ProdutosService>();
builder.Services.AddScoped<IFeedbacksRepository, FeedbacksRepository>();
builder.Services.AddScoped<IFeedbacksService, FeedbacksService>();

// Registro do MLService
builder.Services.AddSingleton<MLService>();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "DaVinci Insights API v1");
    });
}

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();
app.Run();

