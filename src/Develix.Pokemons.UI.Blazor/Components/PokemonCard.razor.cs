using ApexCharts;
using Microsoft.AspNetCore.Components;
using PokeApiNet;

namespace Develix.Pokemons.UI.Blazor.Components;

public partial class PokemonCard
{
    private ApexChart<PokemonStat>? chart;

    [Parameter]
    [EditorRequired]
    public Pokemon? Pokemon { get; set; }

    [Parameter]
    [EditorRequired]
    public PokemonSpecies? Species { get; set; }

    [Parameter]
    [EditorRequired]
    public IReadOnlyList<PokeApiNet.Type> TypeNames { get; set; } = new List<PokeApiNet.Type>();

    private string GetPokemonTypeNames(IReadOnlyList<PokeApiNet.Type> types)
    {
        var typeNames = new List<string>();
        foreach (var type in types)
        {
            var name = GetGermanName(type.Names);
            typeNames.Add(name);
        }

        return string.Join(", ", typeNames);
    }

    private string GetPokemonTypeColor(Pokemon pokemon)
    {
        var pokemonType = pokemon.Types[0];
        var pokemonTypeName = pokemonType.Type.Name;

        return pokemonTypeName switch
        {
            "normal" => "#a9a879",
            "fire" => "#c02f27",
            "water" => "#6892f1",
            "grass" => "#7ac852",
            "electric" => "#f7d02f",
            "ice" => "#98d8d7",
            "fighting" => "#c02f27",
            "poison" => "#a040a2",
            "ground" => "#ddc06a",
            "flying" => "#a991f0",
            "psychic" => "#f85789",
            "bug" => "#a8b821",
            "rock" => "#b89f38",
            "ghost" => "#705899",
            "dragon" => "#7536fb",
            "dark" => "#6f5848",
            "steel" => "#b7b8d0",
            "fairy" => "#fe9cff",
            _ => "#888888",
        };
    }

    private static string GetPokemonName(PokemonSpecies species)
    {
        return GetGermanName(species.Names);
    }

    private static string GetPokemonGenus(PokemonSpecies species)
    {
        return GetGermanGenus(species.Genera);
    }

    private static string GetGermanName(IEnumerable<Names> names)
    {
        var name = names.Single(n => n.Language.Name == "de");
        return name.Name;
    }

    private static string GetGermanGenus(IEnumerable<Genuses> genera)
    {
        var genus = genera.SingleOrDefault(n => n.Language.Name == "de");
        if (genus == null)
        {
            return "nicht gefunden";
        }
        else
        {
            return genus.Genus;
        }
    }

    private static string GetPokemonFlavorText(PokemonSpecies species)
    {
        return GetGermanFlavorText(species.FlavorTextEntries);
    }

    private static string GetGermanFlavorText(IEnumerable<PokemonSpeciesFlavorTexts> flavorTexts)
    {
        var flavorText = flavorTexts.LastOrDefault(n => n.Language.Name == "de");
        if (flavorText == null)
        {
            return "nicht gefunden";
        }
        else
        {
            return flavorText.FlavorText;
        }
    }

    protected override async Task OnAfterRenderAsync(bool firstRender)
    {
        await base.OnAfterRenderAsync(firstRender);
        if (chart is not null)
            await chart.UpdateSeriesAsync(true);
    }
}
