using BlazorCrud.Client;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;

using BlazorCrud.Client.Services;
using CurrieTechnologies.Razor.SweetAlert2;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");
//  AQUI SE CAMBIO LA URI PARA DIRECCIONAR LA UBICACION DEL API SERVER
builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri("http://localhost:5104") });

// inyeccion de dependencia de los servicios

builder.Services.AddScoped<IDepartamentoService, DepartamentoService>();
builder.Services.AddScoped<IEmpleadoService, EmpleadoService>();

builder.Services.AddSweetAlert2();

await builder.Build().RunAsync();
