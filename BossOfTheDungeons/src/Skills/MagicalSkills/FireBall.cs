using BossOfTheDungeons.Skills.Base;
using BossOfTheDungeons.Skills.Enums;
using BossOfTheDungeons.Skills.Utils;
using BossOfTheDungeons.Units.Characters.Structs;

namespace BossOfTheDungeons.Skills.MagicalSkills;

public class FireBall : Skill
{
    public FireBall() : base("Огненный шар", 5, DamageType.MagicalDamage, SkillType.Normal) { }

    public override int DamageCalculation(DamageCalculationParameters parameters)
    {
        return base.DamageCalculation(parameters) * parameters.CastSpeed + parameters.Intelligence;
    }
}