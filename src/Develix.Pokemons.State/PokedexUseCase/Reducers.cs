using System.ComponentModel;
using System.Data;
using System.Xml;
using Develix.Pokemons.State.Moves;
using PokeApiNet;

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
            Moves = new List<PokemonMoveTableRow>(),
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
            IsLoading = false,
        };
    }

    [ReducerMethod]
    public static PokedexState ReduceGetPokemonMovesAction(PokedexState state, GetPokemonMovesAction action)
    {
        return state with
        {
            Moves = new List<PokemonMoveTableRow>(),
        };
    }

    [ReducerMethod]
    public static PokedexState ReduceAddPokemonMoveAction(PokedexState state, AddPokemonMoveAction action)
    {
        return state with
        {
            Moves = new List<PokemonMoveTableRow>(state.Moves) { action.Move },
        };
    }

    [ReducerMethod]
    public static PokedexState ReduceShowMoveDetailsAction(PokedexState state, ShowMoveDetailsAction action)
    {
        var currentMove = state.Moves.FirstOrDefault(m => m.Id == action.Move.Id);
        if (currentMove != null)
            currentMove.ShowDetails = !currentMove.ShowDetails;

        return state;
    }

    [ReducerMethod]
    public static PokedexState ReduceShowMoveDetailsResultAction(PokedexState state, ShowMoveDetailsResultAction action)
    {
        var currentMove = state.Moves.FirstOrDefault(m => m.Id == action.Move.Id);
        if (currentMove != null)
        {
            var moveWithDamageClass = currentMove with { DamageClass = action.MoveDamageClass };
            var moveList = state.Moves.ToList();
            var index = moveList.IndexOf(currentMove);
            moveList[index] = moveWithDamageClass;
            return state with
            {
                Moves = moveList
            };
        }
        return state;
    }
}
