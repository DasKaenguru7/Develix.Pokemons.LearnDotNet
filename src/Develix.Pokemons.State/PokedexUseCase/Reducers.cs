using System.Data;

namespace Develix.Pokemons.State.PokedexUseCase;

public static class Reducers
{
    [ReducerMethod(typeof(GetPokemonAction))]
    public static PokedexState ReduceGetPokemonAction(PokedexState state)
    {
        return state with
        {
            IsLoading = true,
        };
    }

    [ReducerMethod]
    public static PokedexState ReduceGetPokemonResultAction(PokedexState state, GetPokemonResultAction action)
    {
        return state with
        {
            Pokemon = action.Pokemon,
            Species = action.Species,
            IsLoading = false,
        };
    }
}
