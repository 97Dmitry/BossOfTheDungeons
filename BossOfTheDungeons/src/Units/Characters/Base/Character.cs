using System;
using BossOfTheDungeons.Items.Base;
using BossOfTheDungeons.Units.Characters.Enums;

namespace BossOfTheDungeons.Units.Characters.Base
{
    public class Character
    {
        public string Name { get; }
        public CharacterClassEnum? Class { get; }
        
        private readonly Inventory _inventory;
        private readonly Bag _bag;

        public Character(string name, CharacterClassEnum characterClass)
        {
            Name = name;
            Class = characterClass;

            _inventory = new Inventory();
            _bag = new Bag();
        }

        public void CharacterInfo()
        {
            Console.WriteLine("Характеристики вашего персонажа:");
            Console.WriteLine($"Имя: {Name}");
            Console.WriteLine($"Класс: {Class}");
        }

        public void MyBag()
        {
            Console.WriteLine("Ваша сумка:");
            _bag.Show();
        }

        public void TakeItem(Item item)
        {
            _bag.SetItem(item);
        }
    }
}