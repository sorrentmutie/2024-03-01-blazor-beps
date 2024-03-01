using DemoBlazor.Models.Interfaces;
using DemoBlazor.Models.Services;
using DemoBlazor.WASM;
using DemoBlazor.WASM.Services;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });
builder.Services.AddScoped<IDatiEventi, ServizioDatiEventi>();
builder.Services.AddScoped<ICategorie, ServizioCategorieWASM>();
builder.Services.AddScoped<IReqResData, ReqResService>();

await builder.Build().RunAsync();
