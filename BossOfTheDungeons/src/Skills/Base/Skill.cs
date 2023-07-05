using BossOfTheDungeons.Skills.Enums;
using BossOfTheDungeons.Skills.Utils;

namespace BossOfTheDungeons.Skills.Base;

public class Skill
{
    public readonly string Name;
    private readonly int _damage;
    private readonly DamageType _damageType;
    private readonly SkillType _type;

    protected Skill(string name, int damage, DamageType damageType, SkillType skillType)
    {
        Name = name;
        _damage = damage;
        _damageType = damageType;
        _type = skillType;
    }

    public virtual int DamageCalculation(DamageCalculationParameters parameters)
    {
        var damage = _damageType switch
        {
            DamageType.PhysicalDamage => _damage + parameters.PhysicalDamage,
            DamageType.MagicalDamage => _damage + parameters.MagicalDamage,
            DamageType.ChaosDamage => _damage + parameters.ChaosDamage,
            _ => _damage
        };

        switch (_type)
        {
            case SkillType.Normal:
                return damage;
            case SkillType.Rare:
                return (int)(damage + damage * 0.5);
            case SkillType.Legendary:
                return damage * 2;
            default:
                return damage;
        }

        ;
    }
}