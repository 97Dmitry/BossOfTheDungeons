using System;
using System.Collections.Generic;
using BossOfTheDungeons.Common.Structs;
using BossOfTheDungeons.Items.Base;
using BossOfTheDungeons.Items.Enums;
using BossOfTheDungeons.Skills.Base;
using BossOfTheDungeons.Skills.Enums;
using BossOfTheDungeons.Skills.MagicalSkills;
using BossOfTheDungeons.Skills.PhysicalSkills;
using BossOfTheDungeons.Skills.Utils;
using BossOfTheDungeons.Units.Characters.Enums;
using BossOfTheDungeons.Units.Characters.Structs;
using BossOfTheDungeons.Units.Common;

namespace BossOfTheDungeons.Units.Characters.Base;

public class Character : Unit
{
    // Base
    public readonly string Name;

    // Character info
    private readonly CharacterClassEnum? _class;

    // Common
    private readonly Inventory _inventory;
    private readonly Bag _bag;
    private Strength _strength;
    private Dexterity _dexterity;
    private Intelligence _intelligence;

    // Combat
    public float Health { get; private set; }
    public int FullHealth { get; private set; }
    private int _physicalDamage;
    private int _magicalDamage;
    private int _chaosDamage;
    private int _armor;
    private int _attackSpeed;
    private int _castSpeed;
    private int _elementalResistance;
    private int _chaosResistance;
    private int _accuracy;

    // Skills
    private Skill _skill;

    public Character(string name, CharacterClassEnum characterClass)
    {
        Name = name;
        _class = characterClass;
        _inventory = new Inventory();
        _bag = new Bag();
        CalculateCharacterAttributes(characterClass);
    }

    private void CalculateCharacterAttributes(CharacterClassEnum characterClass)
    {
        switch (characterClass)
        {
            case CharacterClassEnum.Warrior:
                _strength = 10;
                _dexterity = 4;
                _intelligence = 1;

                Health = 100f;
                FullHealth = (int)Health;
                _physicalDamage = 10;
                _magicalDamage = 0;
                _chaosDamage = 0;
                _armor = 10;
                _attackSpeed = 1;
                _castSpeed = 1;
                _elementalResistance = 1;
                _chaosResistance = 1;
                _accuracy = 4;

                _skill = new SteelStrike();
                break;
            case CharacterClassEnum.Shadow:
                _strength = 4;
                _dexterity = 10;
                _intelligence = 2;

                Health = 75f;
                FullHealth = (int)Health;
                _physicalDamage = 6;
                _magicalDamage = 1;
                _chaosDamage = 2;
                _armor = 4;
                _attackSpeed = 3;
                _castSpeed = 1;
                _elementalResistance = 1;
                _chaosResistance = 2;
                _accuracy = 10;

                _skill = new DoubleStrike();
                break;
            case CharacterClassEnum.Mage:
                _strength = 2;
                _dexterity = 2;
                _intelligence = 12;

                Health = 50f;
                FullHealth = (int)Health;
                _physicalDamage = 1;
                _magicalDamage = 8;
                _chaosDamage = 1;
                _armor = 2;
                _attackSpeed = 1;
                _castSpeed = 6;
                _elementalResistance = 3;
                _chaosResistance = 2;
                _accuracy = 1;

                _skill = new FireBall();
                break;
        }
    }

    public void CharacterInfo()
    {
        var damage = _skill.DamageCalculation(GetDamageCalculationParameters());

        Console.WriteLine("Данные о вашем персонаже:");
        Console.WriteLine($"Имя: {Name}");
        Console.WriteLine($"Класс: {_class}\n");
        Console.WriteLine($"Здоровье: {FullHealth}");
        Console.WriteLine($"Выбранная способность: {_skill.Name}");
        Console.WriteLine($"Урон: {damage}");
    }

    public void MyBag()
    {
        Console.WriteLine("Ваша сумка:\n");
        _bag.Show();
    }

    public Dictionary<int, Item> GetBagItemsByType(ItemTypeEnum type)
    {
        return _bag.GetItemsByType(type);
    }

    public void TakeItem(Item item)
    {
        _bag.SetItem(item);
    }

    public void MyInventory()
    {
        Console.WriteLine("Ваш инвентарь:\n");
        _inventory.Show();
    }

    public void PutItem(Item item, int? slot = 1)
    {
        _inventory.SetItem(item, _bag, slot);
    }

    public bool IsCanPay(Item item)
    {
        return item.Price < _bag.Money;
    }

    public int BuyItem(Item item)
    {
        var money = item.Price;
        _bag.SpendMoney(money);
        TakeItem(item);
        return money;
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
            default:
                throw new ArgumentOutOfRangeException();
        }

        var finalDamage = Math.Max(0, damage.DamageValue - defense);
        Health -= finalDamage;
    }

    public override void Attack(Unit unit)
    {
        var damage = _skill.DamageCalculation(GetDamageCalculationParameters());
        unit.TakeDamage(damage);
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