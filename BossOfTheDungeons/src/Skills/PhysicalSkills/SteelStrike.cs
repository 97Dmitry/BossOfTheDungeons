using System.Collections.Generic;
using System.Linq;
using BossOfTheDungeons.Common.Structs;
using BossOfTheDungeons.Skills.Base;
using BossOfTheDungeons.Skills.Enums;
using BossOfTheDungeons.Skills.Utils;
using BossOfTheDungeons.Units.Characters.Base;
using BossOfTheDungeons.Units.Common;

namespace BossOfTheDungeons.Skills.PhysicalSkills;

public class SteelStrike : Skill
{
  public bool SpecialAttackIsUsed = false;

  public SteelStrike() : base("Стальной удар", 5, DamageType.PhysicalDamage, SkillType.Normal,
    "Специальная атака наносит урон по одному врагу" +
    "\n\tУрон рассчитывается об базового урона + сила персонажа")
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
    damage.DamageValue += parameters.Strength;

    return new SpecialAttackDamage
    {
      DamageValue = damage.DamageValue, DamageType = damage.DamageType,
      TakenDamageEnemyList = new[] { units.ElementAt(selectedUnitIndex) }
    };
  }
}