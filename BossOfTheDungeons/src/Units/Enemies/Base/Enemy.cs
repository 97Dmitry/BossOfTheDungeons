using BossOfTheDungeons.Units.Characters.Enums;
using BossOfTheDungeons.Units.Characters.Structs;
using BossOfTheDungeons.Units.Interfaces;

namespace BossOfTheDungeons.Units.Enemies.Base;

public class Enemy : IUnit
{
    private readonly string _name;

    // Character info
    private Strength _strength;
    private Dexterity _dexterity;
    private Intelligence _intelligence;

    private int _health, _fullHealth;
    private int _physicalDamage;
    private int _magicalDamage;
    private int _chaosDamage;
    private int _armor;
    private int _attackSpeed;
    private int _castSpeed;
    private int _elementalResistance;
    private int _chaosResistance;
    private int _accuracy;

    public Enemy()
    {
    }
}