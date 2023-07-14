using BossOfTheDungeons.Common.Structs;
using BossOfTheDungeons.Skills.Base;
using BossOfTheDungeons.Skills.Enums;
using BossOfTheDungeons.Skills.Utils;

namespace BossOfTheDungeons.Skills.EnemySkills;

public class DefaultAttack : Skill
{
    public DefaultAttack(int damage) : base("Обычная атака", damage, DamageType.PhysicalDamage, SkillType.Normal)
    {
    }

    public override Damage DamageCalculation(DamageCalculationParameters parameters)
    {
        return base.DamageCalculation(parameters);
    }
}