using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using FrontEnd;
using FrontEnd.Services.UtilizadorService;

var builder = WebAssemblyHostBuilder.CreateDefault(args);

/*builder.Services.AddHttpClient<IUtilizadorService, UtilizadorService>(client =>
{
    client.BaseAddress = new Uri("http://localhost:5052");
});*/

builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri("http://localhost:5052") });
builder.Services.AddScoped<IUtilizadorService, UtilizadorService>();


builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

//builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });
/*builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri("http://localhost:5052") });
builder.Services.AddScoped<IUtilizadorService, UtilizadorService>();*/


var host = builder.Build();

// Get the HttpClient instance from the service provider
var httpClient = host.Services.GetRequiredService<HttpClient>();

// Enable CORS by setting the 'mode' option to 'cors'
httpClient.DefaultRequestHeaders.Add("mode", "cors");

await host.RunAsync();

//await builder.Build().RunAsync();