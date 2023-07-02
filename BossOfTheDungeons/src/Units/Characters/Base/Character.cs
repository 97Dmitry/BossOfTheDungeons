using System;
using BossOfTheDungeons.Items.Base;
using BossOfTheDungeons.Skills.Base;
using BossOfTheDungeons.Skills.MagicalSkills;
using BossOfTheDungeons.Skills.PhysicalSkills;
using BossOfTheDungeons.Skills.Utils;
using BossOfTheDungeons.Units.Characters.Enums;
using BossOfTheDungeons.Units.Characters.Structs;

namespace BossOfTheDungeons.Units.Characters.Base
{
    public class Character
    {
        // Base
        private readonly string _name;

        // Character info
        private readonly CharacterClassEnum? _class;
        private Strength _strength;
        private Dexterity _dexterity;
        private Intelligence _intelligence;

        // Common
        private readonly Inventory _inventory;
        private readonly Bag _bag;

        // Combat
        private int _health;
        private int _fullHealth;
        private int _physicalDamage;
        private int _magicalDamage;
        private int _chaosDamage;
        private int _armor;
        private int _attackSpeed;
        private int _castSpeed;
        private int _elementalResistance;
        private int _chaosResistance;

        // Skills
        private Skill _skill;


        public Character(string name, CharacterClassEnum characterClass)
        {
            _name = name;
            _class = characterClass;
            _inventory = new Inventory();
            _bag = new Bag();

            switch (characterClass)
            {
                case CharacterClassEnum.Warrior:
                    _strength = 10;
                    _dexterity = 4;
                    _intelligence = 1;

                    _health = 100;
                    _fullHealth = 100;
                    _physicalDamage = 10;
                    _magicalDamage = 0;
                    _chaosDamage = 0;
                    _armor = 10;
                    _attackSpeed = 1;
                    _castSpeed = 1;
                    _elementalResistance = 1;
                    _chaosResistance = 1;

                    _skill = new SteelStrike();
                    break;
                case CharacterClassEnum.Shadow:
                    _strength = 4;
                    _dexterity = 10;
                    _intelligence = 2;

                    _health = 75;
                    _fullHealth = 75;
                    _physicalDamage = 6;
                    _magicalDamage = 1;
                    _chaosDamage = 2;
                    _armor = 4;
                    _attackSpeed = 2;
                    _castSpeed = 1;
                    _elementalResistance = 1;
                    _chaosResistance = 2;

                    _skill = new DoubleStrike();
                    break;
                case CharacterClassEnum.Mage:
                    _strength = 2;
                    _dexterity = 2;
                    _intelligence = 12;

                    _health = 50;
                    _fullHealth = 75;
                    _physicalDamage = 6;
                    _magicalDamage = 1;
                    _chaosDamage = 1;
                    _armor = 1;
                    _attackSpeed = 2;
                    _castSpeed = 1;
                    _elementalResistance = 2;
                    _chaosResistance = 2;

                    _skill = new FireBall();
                    break;
            }
        }

        public void CharacterInfo()
        {
            var damage = _skill.DamageCalculation(
                new DamageCalculationParameters
                {
                    PhysicalDamage = _physicalDamage,
                    MagicalDamage = _magicalDamage,
                    ChaosDamage = _chaosDamage,
                    AttackSpeed = _attackSpeed,
                    CastSpeed = _castSpeed,
                    Strength = _strength,
                    Dexterity = _dexterity,
                    Intelligence = _intelligence
                }
            );

            Console.WriteLine("Данные о вашем персонаже:");
            Console.WriteLine($"Имя: {_name}");
            Console.WriteLine($"Класс: {_class}\n");
            Console.WriteLine($"Выбранная способность: {_skill.Name}");
            Console.WriteLine($"Урон: {damage}");
        }

        public void MyBag()
        {
            Console.WriteLine("Ваша сумка:\n");
            _bag.Show();
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

        public bool IsCanPay(Item item)
        {
            return item.Price < _bag.Money;
        }

        public int BuyItem(Item item)
        {
            int money = item.Price;
            _bag.SpendMoney(money);
            this.TakeItem(item);
            return money;
        }
    }
}