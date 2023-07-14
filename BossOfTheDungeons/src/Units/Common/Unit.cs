using BossOfTheDungeons.Common.Structs;

namespace BossOfTheDungeons.Units.Common;

public abstract class Unit
{
    public abstract void TakeDamage(Damage damage);
    public abstract void Attack(Unit unit);
}