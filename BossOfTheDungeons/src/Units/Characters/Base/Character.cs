using System;
using System.Collections.Generic;
using System.Linq;
using BossOfTheDungeons.Common.Structs;
using BossOfTheDungeons.Dungeons.Structs;
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
    private int _fullHealth;

    public int FullHealth
    {
        get => _fullHealth;
        private set
        {
            if (_fullHealth != value)
            {
                RecalculateHealth(_fullHealth, value);
                _fullHealth = value;
            }
        }
    }

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
        CalculateInitialCharacterAttributes(characterClass);
    }

    private void RecalculateHealth(float oldFullHealthValue, float newFullHealthValue)
    {
        var healthPercentage = Health / oldFullHealthValue;
        Health = healthPercentage * newFullHealthValue;
    }

    private void CalculateInitialCharacterAttributes(CharacterClassEnum characterClass)
    {
        switch (characterClass)
        {
            case CharacterClassEnum.Warrior:
                _strength = 10;
                _dexterity = 4;
                _intelligence = 1;

                Health = 100f;
                _fullHealth = (int)Health;
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
                _fullHealth = (int)Health;
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
                _fullHealth = (int)Health;
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

    private int GetStat<T>(Func<T, int> statSelector, IEnumerable<T> items)
    {
        return items.Sum(statSelector);
    }

    private int GetPhysicalDamage()
    {
        var weapons = _inventory.GetWeaponItemsList();
        return _physicalDamage + GetStat(weapon => weapon.PhysicalDamage, weapons);
    }

    private int GetMagicalDamage()
    {
        var weapons = _inventory.GetWeaponItemsList();
        return _magicalDamage + GetStat(weapon => weapon.MagicalDamage, weapons);
    }

    private int GetChaosDamage()
    {
        var weapons = _inventory.GetWeaponItemsList();
        return _chaosDamage + GetStat(weapon => weapon.ChaosDamage, weapons);
    }

    private int GetAttackSpeed()
    {
        var weapons = _inventory.GetWeaponItemsList();
        return _attackSpeed + GetStat(weapon => weapon.AttackSpeed, weapons);
    }


    private int GetCastSpeed()
    {
        var weapons = _inventory.GetWeaponItemsList();
        return _castSpeed + GetStat(weapon => weapon.CastSpeed, weapons);
    }

    private int GetAccuracy()
    {
        var weapons = _inventory.GetWeaponItemsList();
        return _accuracy + GetStat(weapon => weapon.Accuracy, weapons);
    }

    private int GetArmor()
    {
        var items = _inventory.GetArmorItemsLit();
        return _armor + GetStat(weapon => weapon.Armor, items);
    }

    private int GetElementalResistance()
    {
        var items = _inventory.GetArmorItemsLit();
        return _elementalResistance + GetStat(weapon => weapon.ElementalResistance, items);
    }

    private int GetChaosResistance()
    {
        var items = _inventory.GetArmorItemsLit();
        return _chaosResistance + GetStat(weapon => weapon.ChaosResistance, items);
    }

    private Strength GetStrength()
    {
        var items = _inventory.GetArmorItemsLit();
        return _strength + GetStat(weapon => weapon.Strength, items);
    }

    private Dexterity GetDexterity()
    {
        var items = _inventory.GetArmorItemsLit();
        return _dexterity + GetStat(weapon => weapon.Dexterity, items);
    }

    private Intelligence GetIntelligence()
    {
        var items = _inventory.GetArmorItemsLit();
        return _intelligence + GetStat(weapon => weapon.Intelligence, items);
    }

    public void CharacterInfo()
    {
        var damage = _skill.DamageCalculation(GetDamageCalculationParameters());

        Console.WriteLine("Данные о вашем персонаже:");
        Console.WriteLine($"Имя: {Name}");
        Console.WriteLine($"Класс: {_class}\n");
        Console.WriteLine($"Здоровье: {Health}/{FullHealth}");
        Console.WriteLine($"Выбранная способность: {_skill.Name}");
        Console.WriteLine($"Урон: {damage.DamageValue}");
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
        _inventory.SetItem(item, _bag, slot, addedHealth => FullHealth -= addedHealth);
        if (item is not Weapon) FullHealth += item.Health;
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

    public override float TakeDamage(Damage damage)
    {
        var defense = 0f;
        switch (damage.DamageType)
        {
            case DamageType.PhysicalDamage:
                defense = GetArmor() + GetStrength();
                defense += GetDexterity() * GetArmor() / 100.0f;
                break;
            case DamageType.MagicalDamage:
                defense = GetElementalResistance() + GetIntelligence();
                defense += GetIntelligence() * GetElementalResistance() / 100.0f;
                break;
            case DamageType.ChaosDamage:
                defense = GetChaosResistance() + GetIntelligence() / 2f;
                break;
            default:
                throw new ArgumentOutOfRangeException();
        }

        var finalDamage = Math.Max(0, damage.DamageValue - defense);
        Health -= finalDamage;

        return finalDamage;
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

    private DamageCalculationParameters GetDamageCalculationParameters()
    {
        return new DamageCalculationParameters
        {
            PhysicalDamage = GetPhysicalDamage(),
            MagicalDamage = GetMagicalDamage(),
            ChaosDamage = GetChaosDamage(),
            AttackSpeed = GetAttackSpeed(),
            CastSpeed = GetCastSpeed(),
            Accuracy = GetAccuracy(),
            Strength = GetStrength(),
            Dexterity = GetDexterity(),
            Intelligence = GetIntelligence()
        };
    }

    public void TakeDungeonLoot(DungeonLoot loot)
    {
        _bag.AddMoney(loot.Money);
    }
}