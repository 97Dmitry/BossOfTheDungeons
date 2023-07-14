using BossOfTheDungeons.Skills.Enums;

namespace BossOfTheDungeons.Common.Structs;

public struct Damage
{
    public float DamageValue;
    public DamageType DamageType;

    public Damage(float damageValue, DamageType damageType)
    {
        DamageValue = damageValue;
        DamageType = damageType;
    }
}