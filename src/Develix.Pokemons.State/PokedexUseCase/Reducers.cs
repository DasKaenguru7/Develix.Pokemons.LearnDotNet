using System.Data;
using System.Xml;

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

    [ReducerMethod(typeof(GetPokemonErrorAction))]
    public static PokedexState ReduceGetPokemonErrorAction(PokedexState state)
    {
        return state with
        {
            IsLoading = false,
            Pokemon = null,
            Species = null,
            Types = new List<PokeApiNet.Type>(),
            Moves = new List<PokeApiNet.Move>(),
        };
    }

    [ReducerMethod]
    public static PokedexState ReduceGetPokemonResultAction(PokedexState state, GetPokemonResultAction action)
    {
        return state with
        {
            Pokemon = action.Pokemon,
            Species = action.Species,
            Types = action.Types,
            Moves = action.Moves,
            IsLoading = false,
        };
    }
}
