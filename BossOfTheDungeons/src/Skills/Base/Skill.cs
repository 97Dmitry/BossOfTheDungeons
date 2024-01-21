using System;
using System.Collections.Generic;
using BossOfTheDungeons.Common.Structs;
using BossOfTheDungeons.Skills.Enums;
using BossOfTheDungeons.Skills.Utils;
using BossOfTheDungeons.Units.Characters.Base;
using BossOfTheDungeons.Units.Common;

namespace BossOfTheDungeons.Skills.Base;

public class Skill
{
  public readonly string Name;
  private readonly int _damage;
  private readonly DamageType _damageType;
  private readonly SkillType _type;
  public bool SpecialAttackIsUsed = false;
  public string SpecialAttackDescription;

  protected Skill(string name, int damage, DamageType damageType, SkillType skillType,
    string specialAttackDescription)
  {
    Name = name;
    _damage = damage;
    _damageType = damageType;
    _type = skillType;
    SpecialAttackDescription = specialAttackDescription;
  }

  public virtual Damage DamageCalculation(DamageCalculationParameters parameters)
  {
    var damage = 0f;
    switch (_damageType)
    {
      case DamageType.PhysicalDamage:
        damage = _damage + parameters.PhysicalDamage + parameters.Strength;
        damage += parameters.Dexterity * parameters.Accuracy / 100.0f;
        damage += parameters.Dexterity * parameters.AttackSpeed / 100.0f;
        break;
      case DamageType.MagicalDamage:
        damage = parameters.MagicalDamage + parameters.Intelligence;
        damage += parameters.CastSpeed * parameters.Intelligence / 50.0f;
        break;
      case DamageType.ChaosDamage:
        damage = parameters.ChaosDamage + parameters.Intelligence / 2f;
        damage += parameters.CastSpeed / 2f * parameters.Intelligence / 100.0f;
        damage += parameters.AttackSpeed / 2f * parameters.Intelligence / 100.0f;
        break;
      default:
        throw new ArgumentOutOfRangeException();
    }

    switch (_type)
    {
      case SkillType.Normal:
        break;
      case SkillType.Rare:
        damage += damage * 0.5f;
        break;
      case SkillType.Legendary:
        damage *= 2f;
        break;
      default:
        throw new ArgumentOutOfRangeException();
    }

    return new Damage(damage, _damageType);
  }

  public virtual SpecialAttackDamage SpecialAttack(
    IEnumerable<Unit> units,
    int selectedUnitIndex,
    DamageCalculationParameters parameters,
    Character character
  )
  {
    throw new NotImplementedException();
  }
}