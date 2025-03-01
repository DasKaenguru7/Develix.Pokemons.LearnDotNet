﻿using Develix.Pokemons.State.Moves;
using Microsoft.VisualBasic;
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
            var movesAction = new GetPokemonMovesAction(pokemon, 5);
            dispatcher.Dispatch(movesAction);

            var types = new List<PokeApiNet.Type>();
            foreach (var type in pokemon.Types)
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

    [EffectMethod]
    public async Task HandleGetPokemonMovesAction(GetPokemonMovesAction action, IDispatcher dispatcher)
    {
        foreach (var move in action.Pokemon.Moves.Take(action.Amount))
        {
            var concreteMove = await pokeApiClient.GetResourceAsync<Move>(move.Move.Name);
            var concreteMoveTableRow = new PokemonMoveTableRow(concreteMove);
            var addAction = new AddPokemonMoveAction(concreteMoveTableRow);
            dispatcher.Dispatch(addAction);
        }
    }

    [EffectMethod]
    public async Task HandleShowMoveDetailsAction(ShowMoveDetailsAction action, IDispatcher dispatcher)
    {
        var damageClass = await pokeApiClient.GetResourceAsync<MoveDamageClass>(action.Move.ApiDamageClass.Name);
        var target = await pokeApiClient.GetResourceAsync<MoveTarget>(action.Move.ApiTarget.Name);
        var type = await pokeApiClient.GetResourceAsync<PokeApiNet.Type>(action.Move.ApiType.Name);
        var resultAction = new ShowMoveDetailsResultAction(action.Move, damageClass, target, type);
        dispatcher.Dispatch(resultAction);
    }
}
