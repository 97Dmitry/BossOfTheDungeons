using BossOfTheDungeons.Skills.Enums;
using BossOfTheDungeons.Units.Common;

namespace BossOfTheDungeons.Common.Structs;

public struct SpecialAttackDamage
{
  public float DamageValue;
  public DamageType DamageType;
  public Unit[] TakenDamageEnemyList;
}