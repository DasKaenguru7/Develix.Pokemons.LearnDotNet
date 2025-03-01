﻿using Develix.Pokemons.State.Moves;
using PokeApiNet;

namespace Develix.Pokemons.State.PokedexUseCase;

[FeatureState]
public record PokedexState
{
    public bool IsLoading { get; init; }
    public Pokemon? Pokemon { get; init; }
    public PokemonSpecies? Species { get; init; }
    public IReadOnlyList<PokeApiNet.Type> Types { get; init; } = new List<PokeApiNet.Type>();
    public IReadOnlyList<PokemonMoveTableRow> Moves { get; init; } = new List<PokemonMoveTableRow>();
}
