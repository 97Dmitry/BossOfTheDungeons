using BossOfTheDungeons.Common.Structs;
using BossOfTheDungeons.Skills.Base;
using BossOfTheDungeons.Skills.Enums;
using BossOfTheDungeons.Skills.Utils;

namespace BossOfTheDungeons.Skills.PhysicalSkills;

public class DoubleStrike : Skill
{
    public DoubleStrike() : base("Двойной удар", 5, DamageType.PhysicalDamage, SkillType.Normal)
    {
    }

    public override Damage DamageCalculation(DamageCalculationParameters parameters)
    {
        return base.DamageCalculation(parameters);
    }
}