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
    private static readonly Random Random = new();

    public readonly string Name;

    public float Health { get; private set; }
    public int FullHealth { get; private set; }
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
        Name = EnemyNameGenerator.GenerateEnemyName();

        _strength = Random.Next(1, 5 + level);
        _dexterity = Random.Next(1, 5 + level);
        _intelligence = Random.Next(1, 5 + level);

        Health = Random.Next(1, 51) + Random.Next(1, 5 * level);
        FullHealth = (int)Health;
        _armor = Random.Next(1, 5 + level);
        _magicalDamage = Random.Next(1, 5 + level);
        _physicalDamage = Random.Next(1, 5 + level);
        _chaosDamage = Random.Next(1, 5 + level);
        _attackSpeed = Random.Next(1, 5 + level);
        _castSpeed = Random.Next(1, 5 + level);
        _chaosResistance = Random.Next(1, 5 + level);
        _elementalResistance = Random.Next(1, 5 + level);
        _accuracy = Random.Next(1, 6 + level);

        var damageTypes = Enum.GetValues(typeof(DamageType));
        var damageType = (DamageType)damageTypes.GetValue(Random.Next(damageTypes.Length));

        _damageType = damageType;
        _skill = new DefaultAttack(Random.Next(1, 5 + level));
    }

    public override DamageInfo Attack(Unit unit)
    {
        var damage = _skill.DamageCalculation(GetDamageCalculationParameters());
        var damageReceived = unit.TakeDamage(damage);


        return new DamageInfo
        {
            PotentialDamage = damage.DamageValue,
            FinalDamage = damageReceived
        };
    }

    public override float TakeDamage(Damage damage)
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
        Health -= finalDamage;

        return finalDamage;
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