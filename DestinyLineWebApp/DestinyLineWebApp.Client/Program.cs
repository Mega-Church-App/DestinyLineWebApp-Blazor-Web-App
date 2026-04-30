using Microsoft.AspNetCore.Components.Web;
using DestinyLineWebApp.Client;
using DestinyLineWebApp.Client.Services;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.Services.AddScoped<IAttendeeService, AttendeeService>();
builder.Services.AddSingleton<IMemberService, MemberService>();

builder.RootComponents.Add<Routes>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");
await builder.Build().RunAsync();
