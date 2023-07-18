using Artify.WEB;
using Artify.WEB.Services;
using Artify.WEB.Services.Contracts;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");


builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri("https://localhost:7062/") });

builder.Services.AddScoped<IArtworkService, ArtworkService>();

await builder.Build().RunAsync();
