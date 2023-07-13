using System;
using BossOfTheDungeons.Units.Characters.Structs;
using BossOfTheDungeons.Units.Enemies.Utils.Generator;
using BossOfTheDungeons.Units.Interfaces;

namespace BossOfTheDungeons.Units.Enemies.Base;

public class Enemy : IUnit
{
    public readonly string Name;

    private readonly float _health;
    private int _fullHealth;
    private int _armor;
    private int _magicalDamage;
    private int _physicalDamage;
    private int _chaosDamage;
    private int _attackSpeed;
    private int _castSpeed;
    private int _chaosResistance;
    private int _elementalResistance;
    private int _accuracy;


    private Strength _strength;
    private Dexterity _dexterity;
    private Intelligence _intelligence;

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
    }
}