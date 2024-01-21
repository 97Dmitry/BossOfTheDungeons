using System;
using System.Collections.Generic;
using System.Linq;
using BossOfTheDungeons.Common.Structs;
using BossOfTheDungeons.Skills.Base;
using BossOfTheDungeons.Skills.Enums;
using BossOfTheDungeons.Skills.Utils;
using BossOfTheDungeons.Units.Characters.Base;
using BossOfTheDungeons.Units.Common;

namespace BossOfTheDungeons.Skills.PhysicalSkills;

public class DoubleStrike : Skill
{
  public static Random random = new();

  public bool SpecialAttackIsUsed = false;

  public DoubleStrike() : base("Двойной удар", 5, DamageType.PhysicalDamage, SkillType.Normal,
    "Специальная атака наносит урон по одному врагу и по одному случайному врагу" +
    "\n\tУрон рассчитывается об базового урона + ловкость персонажа")
  {
  }

  public override SpecialAttackDamage SpecialAttack(
    IEnumerable<Unit> units,
    int selectedUnitIndex,
    DamageCalculationParameters parameters,
    Character character
  )
  {
    var damage = DamageCalculation(parameters);
    damage.DamageValue += parameters.Dexterity;

    return new SpecialAttackDamage
    {
      DamageValue = damage.DamageValue, DamageType = damage.DamageType,
      TakenDamageEnemyList = new[]
        { units.ElementAt(selectedUnitIndex), units.ElementAt(random.Next(0, units.Count() - 1)) }
    };
  }
}