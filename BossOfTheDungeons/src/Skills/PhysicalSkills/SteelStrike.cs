using BossOfTheDungeons.Skills.Base;
using BossOfTheDungeons.Skills.Enums;
using BossOfTheDungeons.Skills.Utils;
using BossOfTheDungeons.Units.Characters.Structs;

namespace BossOfTheDungeons.Skills.PhysicalSkills;

public class SteelStrike : Skill
{
    public SteelStrike() : base("Стальной удар", 5, DamageType.PhysicalDamage, SkillType.Normal) {}

    public override int DamageCalculation(DamageCalculationParameters parameters)
    {
        return base.DamageCalculation(parameters) * parameters.AttackSpeed + parameters.Strength;
    }
}