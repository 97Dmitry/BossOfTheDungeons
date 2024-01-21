using System.Collections.Generic;
using System.Linq;
using BossOfTheDungeons.Common.Structs;
using BossOfTheDungeons.Skills.Base;
using BossOfTheDungeons.Skills.Enums;
using BossOfTheDungeons.Skills.Utils;
using BossOfTheDungeons.Units.Characters.Base;
using BossOfTheDungeons.Units.Common;

namespace BossOfTheDungeons.Skills.MagicalSkills;

public class FireBall : Skill
{
  public bool SpecialAttackIsUsed = false;

  public FireBall() : base("Огненный шар", 15, DamageType.MagicalDamage, SkillType.Normal,
    "Специальная атака наносит урон по одному врагу" +
    "\n\tУрон рассчитывается об базового урона + интеллект персонажа умноженный на 2")
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
    damage.DamageValue += parameters.Intelligence * 2;

    return new SpecialAttackDamage
    {
      DamageValue = damage.DamageValue, DamageType = damage.DamageType,
      TakenDamageEnemyList = new[] { units.ElementAt(selectedUnitIndex) }
    };
  }
}