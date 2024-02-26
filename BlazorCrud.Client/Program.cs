using BlazorCrud.Client;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;

using BlazorCrud.Client.Services;
using CurrieTechnologies.Razor.SweetAlert2;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");
//  AQUI SE CAMBIO LA URI PARA DIRECCIONAR LA UBICACION DEL API SERVER
builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri("rac506-001-site1.ltempurl.com") });

// inyeccion de dependencia de los servicios

builder.Services.AddScoped<IDepartamentoService, DepartamentoService>();
builder.Services.AddScoped<IEmpleadoService, EmpleadoService>();

builder.Services.AddSweetAlert2();

await builder.Build().RunAsync();
