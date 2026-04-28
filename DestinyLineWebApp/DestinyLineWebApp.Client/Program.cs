using DestinyLineWebApp.Client.Services;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.Services.AddSingleton<IMemberService, MemberService>();

await builder.Build().RunAsync();
