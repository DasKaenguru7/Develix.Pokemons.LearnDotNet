using PokeApiNet;

namespace Develix.Pokemons.State.PokedexUseCase;

[FeatureState]
public record PokedexState
{
    public bool IsLoading { get; init; }
    public Pokemon? Pokemon { get; init; }
    public PokemonSpecies? Species { get; init; }
}
