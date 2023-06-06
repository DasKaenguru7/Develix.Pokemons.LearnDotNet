using Develix.Pokemons.State;
using Develix.Pokemons.State.PokedexUseCase;
using Develix.Pokemons.UI.Blazor;
using Fluxor;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using MudBlazor.Services;
using PokeApiNet;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddFluxor(op => op.ScanAssemblies(typeof(PokedexState).Assembly));
builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });
builder.Services.AddScoped<PokeApiClient>();
builder.Services.AddMudServices();
builder.Services.AddScoped<ISnackbarService, Develix.Pokemons.UI.Blazor.Shared.SnackbarService>();

await builder.Build().RunAsync();
