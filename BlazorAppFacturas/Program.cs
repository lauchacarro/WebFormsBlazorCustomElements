using BlazorAppFacturas.Components.Forms;
using BlazorAppFacturas.Data;
using BlazorAppFacturas.Pages;
using BlazorAppFacturas.Pages.Facturas;
using BlazorAppFacturas.Shared;

using Microsoft.AspNetCore.Components.Web;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();

builder.Services.AddServerSideBlazor(o =>
{
    o.RootComponents.RegisterCustomElement<SurveyPrompt>("survey-prompt");
    o.RootComponents.RegisterCustomElement<FacturaEditForm>("editar-factura-form");
    o.RootComponents.RegisterCustomElement<Counter>("my-counter");
});

builder.Services.AddDbContext<FacturasDbContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("Default")));

builder.Services.AddSingleton<WeatherForecastService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseStaticFiles();

app.UseRouting();

app.MapBlazorHub();
app.MapFallbackToPage("/_Host");

app.Run();
