using System;
using BossOfTheDungeons.Items.Base;
using BossOfTheDungeons.Units.Characters.Enums;

namespace BossOfTheDungeons.Units.Characters.Base
{
    public class Character
    {
        public string Name { get; }
        public CharacterClassEnum? Class { get; }
        
        private Inventory _inventory;
        private Bag _bag;

        public Character(string name)
        {
            Name = name;
            Class = null;

            _inventory = new Inventory();
            _bag = new Bag();
        }

        public void TakeItem(Item item)
        {
            _bag.SetItem(item);
        }

        public void MyBag()
        {
            _bag.Show();
        }
    }
}