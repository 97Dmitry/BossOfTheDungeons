using BossOfTheDungeons.Common.Structs;

namespace BossOfTheDungeons.Units.Common;

public abstract class Unit
{
    public abstract float TakeDamage(Damage damage);
    public abstract DamageInfo Attack(Unit unit);
}