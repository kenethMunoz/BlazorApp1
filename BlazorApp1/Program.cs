using BlazorApp1.Components;
using BlazorApp1.Data;
using BlazorApp1.Interfaces;
using BlazorApp1.Servicios;
using Microsoft.Extensions;
using System.Configuration;
using System.Data.Common;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();
builder.Services.AddScoped<IClienteServices, ServicioClientes>();
var app = builder.Build();


builder.Services.AddSingleton(new SqlConfiguration(DbConnectionStringBuilder));


// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseStaticFiles();
app.UseAntiforgery();

app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();

app.Run();
