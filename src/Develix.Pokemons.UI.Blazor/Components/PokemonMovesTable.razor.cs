using Develix.Pokemons.State.Moves;
using Develix.Pokemons.State.PokedexUseCase;
using Fluxor;
using Microsoft.AspNetCore.Components;
using MudBlazor;
using PokeApiNet;
using static MudBlazor.CategoryTypes;

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
    public IReadOnlyList<PokemonMoveTableRow> Moves { get; set; } = new List<PokemonMoveTableRow>();

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
    private string GetDisplayName(int? value)
    {
        if (value == null)
        {
            return "-";
        }
        else
        {
            return value.ToString();
        }
    }

    private void RowClickEvent(TableRowClickEventArgs<PokemonMoveTableRow> row)
    {
        if (row.Item.ShowDetails == false)
            row.Item.ShowDetails = true;
        else
            row.Item.ShowDetails = false;
    }
    private bool GetMovesDisabled() => IsLoading;

    private string GetGermanEffectEntriesName(IEnumerable<VerboseEffect> verboseEffects)
    {
        var verboseEffectName = verboseEffects.FirstOrDefault(n => n.Language.Name == "de");
        if (verboseEffectName == null)
        { 
            verboseEffectName = verboseEffects.FirstOrDefault(n => n.Language.Name == "en");
        }
        if (verboseEffectName == null)
        {
            return "nicht gefunden";
        }
        else
        {
            return verboseEffectName.Effect;
        }
    }
}
