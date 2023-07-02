using BossOfTheDungeons.Units.Characters.Structs;

namespace BossOfTheDungeons.Skills.Utils;

public class DamageCalculationParameters
{
    public int PhysicalDamage { get; set; }
    public int MagicalDamage { get; set; }
    public int ChaosDamage { get; set; }
    public int AttackSpeed { get; set; }
    public int CastSpeed { get; set; }
    public Strength Strength { get; set; }
    public Dexterity Dexterity { get; set; }
    public Intelligence Intelligence { get; set; }
}