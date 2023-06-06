using PokeApiNet;

namespace Develix.Pokemons.State.PokedexUseCase;

public record GetPokemonAction(int PokedexId);

public record GetPokemonErrorAction(int PokemonId);

public record GetPokemonResultAction(Pokemon Pokemon, PokemonSpecies Species);
