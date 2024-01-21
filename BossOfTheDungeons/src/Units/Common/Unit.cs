using System.Collections.Generic;
using BossOfTheDungeons.Common.Structs;
using BossOfTheDungeons.Units.Characters.Base;

namespace BossOfTheDungeons.Units.Common;

public abstract class Unit
{
  public abstract float TakeDamage(Damage damage);
  public abstract DamageInfo Attack(Unit unit);

  public abstract SpecialAttackDamageInfo SpecialAttack(
    IEnumerable<Unit> units,
    int selectedUnitIndex,
    Character character
  );
}