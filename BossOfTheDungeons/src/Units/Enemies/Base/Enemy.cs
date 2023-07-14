using System;
using BossOfTheDungeons.Common.Structs;
using BossOfTheDungeons.Skills.Base;
using BossOfTheDungeons.Skills.EnemySkills;
using BossOfTheDungeons.Skills.Enums;
using BossOfTheDungeons.Skills.Utils;
using BossOfTheDungeons.Units.Characters.Structs;
using BossOfTheDungeons.Units.Common;
using BossOfTheDungeons.Units.Enemies.Utils.Generator;

namespace BossOfTheDungeons.Units.Enemies.Base;

public class Enemy : Unit
{
    public readonly string Name;

    private float _health;
    private int _fullHealth;
    private readonly int _armor;
    private readonly int _magicalDamage;
    private readonly int _physicalDamage;
    private readonly int _chaosDamage;
    private readonly int _attackSpeed;
    private readonly int _castSpeed;
    private readonly int _chaosResistance;
    private readonly int _elementalResistance;
    private readonly int _accuracy;


    private readonly Strength _strength;
    private readonly Dexterity _dexterity;
    private readonly Intelligence _intelligence;

    private DamageType _damageType;
    private readonly Skill _skill;

    public Enemy(int level)
    {
        var random = new Random();

        Name = EnemyNameGenerator.GenerateEnemyName();

        _strength = random.Next(1, 5 + level);
        _dexterity = random.Next(1, 5 + level);
        _intelligence = random.Next(1, 5 + level);

        _health = random.Next(1, 51) + random.Next(1, 5 * level);
        _fullHealth = (int)_health;
        _armor = random.Next(1, 5 + level);
        _magicalDamage = random.Next(1, 5 + level);
        _physicalDamage = random.Next(1, 5 + level);
        _chaosDamage = random.Next(1, 5 + level);
        _attackSpeed = random.Next(1, 5 + level);
        _castSpeed = random.Next(1, 5 + level);
        _chaosResistance = random.Next(1, 5 + level);
        _elementalResistance = random.Next(1, 5 + level);
        _accuracy = random.Next(1, 6 + level);

        var damageTypes = Enum.GetValues(typeof(DamageType));
        var damageType = (DamageType)damageTypes.GetValue(random.Next(damageTypes.Length));

        _damageType = damageType;
        _skill = new DefaultAttack(random.Next(1, 5 + level));
    }

    public override void Attack(Unit unit)
    {
        var damage = _skill.DamageCalculation(GetDamageCalculationParameters());
        unit.TakeDamage(damage);
    }

    public override void TakeDamage(Damage damage)
    {
        var defense = 0f;
        switch (damage.DamageType)
        {
            case DamageType.PhysicalDamage:
                defense = _armor + _strength;
                defense += _dexterity * _armor / 100.0f;
                break;
            case DamageType.MagicalDamage:
                defense = _elementalResistance + _intelligence;
                defense += _intelligence * _elementalResistance / 100.0f;
                break;
            case DamageType.ChaosDamage:
                defense = _chaosResistance + _intelligence / 2f;
                break;
        }

        var finalDamage = Math.Max(0, damage.DamageValue - defense);
        _health -= finalDamage;
    }

    private DamageCalculationParameters GetDamageCalculationParameters()
    {
        return new DamageCalculationParameters
        {
            PhysicalDamage = _physicalDamage,
            MagicalDamage = _magicalDamage,
            ChaosDamage = _chaosDamage,
            AttackSpeed = _attackSpeed,
            CastSpeed = _castSpeed,
            Accuracy = _accuracy,
            Strength = _strength,
            Dexterity = _dexterity,
            Intelligence = _intelligence
        };
    }
}