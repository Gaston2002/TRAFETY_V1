using CurrieTechnologies.Razor.SweetAlert2;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using TRAFETY.Client;
using TRAFETY.ClientService.Autorizacion;
using TRAFETY.ClientService.Repositorios;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

#region SERVICIOS
builder.Services.AddSingleton(sp => 
    new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });
builder.Services.AddSweetAlert2();

builder.Services.AddScoped<IRepositorio, Repositorio>();

builder.Services.AddAuthorizationCore();

builder.Services.AddScoped<ServicioAutenticacionJWT>();

builder.Services.AddScoped<AuthenticationStateProvider, ServicioAutenticacionJWT>(proveedor =>
    proveedor.GetRequiredService<ServicioAutenticacionJWT>());

builder.Services.AddScoped<ILoginService, ServicioAutenticacionJWT>(proveedor =>
    proveedor.GetRequiredService<ServicioAutenticacionJWT>());

builder.Services.AddScoped<NuevoToken>();
#endregion

await builder.Build().RunAsync();
