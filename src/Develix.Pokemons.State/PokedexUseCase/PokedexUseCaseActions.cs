using PokeApiNet;

namespace Develix.Pokemons.State.PokedexUseCase;

public record GetPokemonAction(int PokedexId);

public record GetPokemonErrorAction(int PokemonId);

public record GetPokemonResultAction(Pokemon Pokemon, PokemonSpecies Species, IReadOnlyList<PokeApiNet.Type> Types);

public record GetPokemonMovesAction(Pokemon Pokemon, int Amount);

public record GetPokemonMovesResultAction(IReadOnlyList<Move> Moves);
