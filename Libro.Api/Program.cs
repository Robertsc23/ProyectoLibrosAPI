using Autofac.Core;
using Microsoft.EntityFrameworkCore;
using Proyecto.Application.Cores.Contexts;
using Proyecto.Application.Services.Implementations;
using Proyecto.Application.Services;
using Proyecto.Domain.Repositories;
using Proyecto.Infrastructure.Cores.Contexts;
using Proyecto.Infrastructure.Persistences;
using FluentValidation.AspNetCore;
using FluentValidation;
using Proyecto.Application.Validators;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


builder.Services.AddDbContext<InfrastructureDbContext>();
builder.Services.AddTransient<ILibroRepository, LibroRepository>();
builder.Services.AddTransient<IEditorialRepository, EditorialRepository>();
builder.Services.AddTransient<ISolicitanteRepository, SolicitanteRepository>();
builder.Services.AddTransient<IPrestamoRepository, PrestamoRepository>();

builder.Services.AddTransient<ILibroService, LibroService>();
builder.Services.AddTransient<IEditorialService, EditorialService>();
builder.Services.AddTransient<ISolicitanteService, SolicitanteService>();
builder.Services.AddTransient<IPrestamoService, PrestamoService>();


builder.Services.AddApplicationService();
builder.Services.AddFluentValidationAutoValidation()
    .AddFluentValidationClientsideAdapters();
builder.Services.AddValidatorsFromAssemblyContaining<SolicitanteBodyDTOValidator>();
builder.Services.AddValidatorsFromAssemblyContaining<LibroBodyDTOValidator>();
builder.Services.AddValidatorsFromAssemblyContaining<EditorialBodyDTOValidator>();
builder.Services.AddValidatorsFromAssemblyContaining<PrestamoBodyDTOValidator>();


var app = builder.Build();


app.Use(async (context, next) =>
{
    if (context.Request.Path == "/")
    {
        context.Response.Redirect("/swagger/index.html");
        return;
    }
    await next();
});


if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors("AllowAll");
app.UseMiddleware<Proyecto.Api.Middlewares.ExceptionMiddleware>();
app.UseAuthorization();
app.MapControllers();
app.Run();

