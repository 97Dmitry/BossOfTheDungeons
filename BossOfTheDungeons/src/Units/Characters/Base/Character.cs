using System;
using BossOfTheDungeons.Items.Base;
using BossOfTheDungeons.Units.Characters.Enums;

namespace BossOfTheDungeons.Units.Characters.Base
{
    public class Character
    {
        private readonly string _name;
        private CharacterClassEnum? _class;
        
        private readonly Inventory _inventory;
        private readonly Bag _bag;

        public Character(string name, CharacterClassEnum characterClass)
        {
            _name = name;
            _class = characterClass;
            _inventory = new Inventory();
            _bag = new Bag();
        }

        public void CharacterInfo()
        {
            Console.WriteLine("Характеристики вашего персонажа:");
            Console.WriteLine($"Имя: {_name}");
            Console.WriteLine($"Класс: {_class}");
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
    }
}