using DestinyLineWebApp.Client;
using DestinyLineWebApp.Client.Services;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.Services.AddSingleton<IMemberService, MemberService>();
builder.RootComponents.Add<Routes>("#app");
await builder.Build().RunAsync();
