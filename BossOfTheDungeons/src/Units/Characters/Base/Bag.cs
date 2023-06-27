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
        foreach (Item item in _items)
        {
            if (item is Weapon weapon)
            {
                Console.WriteLine($"1. {weapon.Type} {weapon.WeaponType} {weapon.Name}");
            }
            else
                Console.WriteLine($"1. {item.Type} {item.Name}");
        }
    }
}