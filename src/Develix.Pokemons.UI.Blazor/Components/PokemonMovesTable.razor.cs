using Develix.Pokemons.State.PokedexUseCase;
using Fluxor;
using Microsoft.AspNetCore.Components;
using PokeApiNet;

namespace Develix.Pokemons.UI.Blazor.Components;

public partial class PokemonMovesTable
{
    [Inject]
    public IDispatcher Dispatcher { get; set; } = null!;

    [Parameter]
    [EditorRequired]
    public Pokemon? Pokemon { get; set; }

    [Parameter]
    [EditorRequired]
    public IReadOnlyList<Move> Moves { get; set; } = new List<Move>();

    [Parameter]
    [EditorRequired]
    public bool IsLoading { get; set; }

    private void GetAllMoves()
    {
        if (Pokemon is null)
        {
            return;
        }
        else
        {
            var moveCount = Pokemon.Moves.Count;
            var action = new GetPokemonMovesAction(Pokemon, moveCount);
            Dispatcher.Dispatch(action);
        }
    }

    private string GetGermanFlavorText(IEnumerable<MoveFlavorText> flavorTexts)
    {
        var flavorText = flavorTexts.FirstOrDefault(n => n.Language.Name == "de");
        if (flavorText == null)
        {
            return "nicht gefunden";
        }
        else
        {
            return flavorText.FlavorText;
        }
    }

    private string GetGermanAttackeName(IEnumerable<Names> names)
    {
        var attackeName = names.FirstOrDefault(n => n.Language.Name == "de");
        if (attackeName == null)
        {
            return "nicht gefunden";
        }
        else
        {
            return attackeName.Name;
        }
    }

    private bool GetMovesDisabled() => IsLoading;
}
