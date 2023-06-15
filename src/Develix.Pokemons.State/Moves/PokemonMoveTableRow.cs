using PokeApiNet;

namespace Develix.Pokemons.State.Moves;
public class PokemonMoveTableRow
{
    public int? Accuracy { get; }
    public NamedApiResource<MoveDamageClass> DamageClass { get; }
    public int? EffectChance { get; }
    public List<VerboseEffect> EffectEntries { get; }
    public List<MoveFlavorText> FlavorTextEntries { get; }
    public int Id { get; }
    public string Name { get; }
    public List<Names> Names { get; }
    public int? Pp { get; }
    public int? Power { get; }
    public int Priority { get; }
    public bool ShowDetails { get; set; }
    public NamedApiResource<MoveTarget> Target { get; }

    public PokemonMoveTableRow(Move move)
    {
        Accuracy = move.Accuracy;
        DamageClass = move.DamageClass;
        EffectChance = move.EffectChance;
        EffectEntries = move.EffectEntries;
        FlavorTextEntries = move.FlavorTextEntries;
        Id = move.Id;
        Name = move.Name;
        Names = move.Names;
        Pp = move.Pp;
        Power = move.Power;
        Priority = move.Priority;
        ShowDetails = false;
        Target = move.Target;
    }
}
