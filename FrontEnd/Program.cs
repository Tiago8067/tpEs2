global using BusinessLogic.Entities;
global using System.Net.Http.Json;
global using FrontEnd.Services.ProductService;
global using FrontEnd.Services.AuthService;
global using FrontEnd.Services.ProjetoService;
global using FrontEnd.Services.TarefaService;
global using FrontEnd.Services.UtilizadorService;
global using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using FrontEnd;
using Syncfusion.Blazor;
using Blazored.LocalStorage;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddBlazoredLocalStorage();

builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });
builder.Services.AddScoped<IUtilizadorService, UtilizadorService>();
builder.Services.AddScoped<IProjetoService, ProjetoService>();
builder.Services.AddScoped<ITarefaService, TarefaService>();
builder.Services.AddScoped<IProductService, ProductService>();
builder.Services.AddScoped<IAuthService, AuthService>();

builder.Services.AddOptions();
builder.Services.AddAuthorizationCore();
builder.Services.AddScoped<AuthenticationStateProvider, CustomAuthStateProvider>();

builder.Services.AddSyncfusionBlazor();
Syncfusion.Licensing.SyncfusionLicenseProvider.RegisterLicense("Mgo+DSMBaFt+QHJqVk1nQ1BDaV1CX2BZeVl3RGlcfk4QCV5EYF5SRHBeRVxqSH9WdENjW3s=;Mgo+DSMBPh8sVXJ1S0R+X1pDaV5FQmFJfFBmQmlYflR1dUUmHVdTRHRcQltiTn9ad0RmW3lfdnA=;ORg4AjUWIQA/Gnt2VFhiQlJPcUBDWnxLflF1VWRTfl96cVRWACFaRnZdQV1lSHlSf0RiXH1Ycn1R;MjQ1MDAxMkAzMjMxMmUzMDJlMzBJczNwelJGcHl1aHlCK2dPUGxxODhVWGd3eS9RaCtOZ3lsYjdqbG80WklnPQ==;MjQ1MDAxM0AzMjMxMmUzMDJlMzBKdDlhMUh4WTBiSzlCYWo4bU1DY1VOeWxlMXM2dlRTN1hHTzFYUGxuV1pZPQ==;NRAiBiAaIQQuGjN/V0d+Xk9HfVhdXGRWfFN0RnNedV9xflBHcDwsT3RfQF5jT39Ud0xiWHpcdnxSQg==;MjQ1MDAxNUAzMjMxMmUzMDJlMzBCQ09ZNFBXd29yTllmRjYzV1d3MGZxL25xQ3gzRi9OMnRoQWNMcUhiaFY4PQ==;MjQ1MDAxNkAzMjMxMmUzMDJlMzBSbWZKNjhTbURPRFhKQXNKU21IUHNLTUxhQVZPSDhxR2E3dzM4bzhjbXQ0PQ==;Mgo+DSMBMAY9C3t2VFhiQlJPcUBDWnxLflF1VWRTfl96cVRWACFaRnZdQV1lSHlSf0RiXH1ZdHFR;MjQ1MDAxOEAzMjMxMmUzMDJlMzBYUmRYcUkxdk8rTmx3dWNaU09oSndZV1ZYalg1Y3hZYlRkREtMekI3RmRBPQ==;MjQ1MDAxOUAzMjMxMmUzMDJlMzBtOW9FMjVFNDV3RFgwWUtNN3F6b1dmdkMrUG9qZmY0cVd4WjR3TC96bFRNPQ==;MjQ1MDAyMEAzMjMxMmUzMDJlMzBCQ09ZNFBXd29yTllmRjYzV1d3MGZxL25xQ3gzRi9OMnRoQWNMcUhiaFY4PQ==");
//APos 30 dias abrir o site 

await builder.Build().RunAsync();