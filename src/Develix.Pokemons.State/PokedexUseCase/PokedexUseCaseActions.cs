using PokeApiNet;

namespace Develix.Pokemons.State.PokedexUseCase;

public record GetPokemonAction(int PokedexId);

public record GetPokemonResultAction(Pokemon Pokemon, PokemonSpecies Species);
