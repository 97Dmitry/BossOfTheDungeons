using System;
using System.Collections.Generic;
using BossOfTheDungeons.Items.Base;
using BossOfTheDungeons.Items.Enums;

namespace BossOfTheDungeons.Units.Characters.Base;

public class Bag
{
    private readonly List<Item> _items = new List<Item>();

    public void SetItem(Item item)
    {
        _items.Add(item);
    }

    public void Show()
    {
        for (int i = 0; i < _items.Count; i++)
        {
            if (_items[i] is Weapon weapon)
            {
                Console.WriteLine($"{i + 1}. {weapon.Name} {weapon.Type} {weapon.WeaponType}");
            }
            else
                Console.WriteLine($"{i + 1}. {_items[i].Name} {_items[i].Type}");
        }
    }
}