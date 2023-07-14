using BossOfTheDungeons.Common.Structs;
using BossOfTheDungeons.Skills.Base;
using BossOfTheDungeons.Skills.Enums;
using BossOfTheDungeons.Skills.Utils;

namespace BossOfTheDungeons.Skills.PhysicalSkills;

public class SteelStrike : Skill
{
    public SteelStrike() : base("Стальной удар", 5, DamageType.PhysicalDamage, SkillType.Normal)
    {
    }

    public override Damage DamageCalculation(DamageCalculationParameters parameters)
    {
        return base.DamageCalculation(parameters);
    }
}