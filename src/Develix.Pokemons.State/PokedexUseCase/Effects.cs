using PokeApiNet;

namespace Develix.Pokemons.State.PokedexUseCase;

public class Effects
{
    private readonly PokeApiClient pokeApiClient;
    private readonly ISnackbarService snackbarService;

    public Effects(PokeApiClient pokeApiClient, ISnackbarService snackbarService)
    {
        this.pokeApiClient = pokeApiClient;
        this.snackbarService = snackbarService;
    }

    [EffectMethod]
    public async Task HandleGetPokemonAction(GetPokemonAction action, IDispatcher dispatcher)
    {
        try
        {
            var pokemon = await pokeApiClient.GetResourceAsync<Pokemon>(action.PokedexId);
            var types = new List<PokeApiNet.Type>();
            foreach(var type in pokemon.Types) 
            {
                var concreteType = await pokeApiClient.GetResourceAsync<PokeApiNet.Type>(type.Type.Name);
                types.Add(concreteType);
            }
            var species = await pokeApiClient.GetResourceAsync<PokemonSpecies>(action.PokedexId);
            var resultAction = new GetPokemonResultAction(pokemon, species, types);
            dispatcher.Dispatch(resultAction);
        }
        catch
        {
            var resultAction = new GetPokemonErrorAction(action.PokedexId);
            dispatcher.Dispatch(resultAction);
        }
    }

    [EffectMethod]
    public Task HandleGetPokemonErrorAction(GetPokemonErrorAction action, IDispatcher dispatcher)
    {
        var message = $"Das Pokémon {action.PokemonId} existiert nicht!";
        snackbarService.ShowErrorMessage(message);
        return Task.CompletedTask;
    }
}
