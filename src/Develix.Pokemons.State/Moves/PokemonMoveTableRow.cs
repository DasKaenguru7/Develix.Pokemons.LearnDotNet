using PokeApiNet;

namespace Develix.Pokemons.State.Moves;
public record PokemonMoveTableRow
{
    public int? Accuracy { get; }
    public NamedApiResource<MoveDamageClass> ApiDamageClass { get; }
    public NamedApiResource<MoveTarget> ApiTarget { get; }
    public NamedApiResource<PokeApiNet.Type> ApiType { get; }
    public MoveDamageClass? DamageClass { get; init; }
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
    public MoveTarget? Target { get; init; }
    public PokeApiNet.Type? Type { get; init; }

    public PokemonMoveTableRow(Move move)
    {
        Accuracy = move.Accuracy;
        ApiDamageClass = move.DamageClass;
        ApiTarget = move.Target;
        ApiType = move.Type;
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
    }
}
