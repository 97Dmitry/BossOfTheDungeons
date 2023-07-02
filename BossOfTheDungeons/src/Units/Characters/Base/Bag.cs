using System;
using System.Collections.Generic;
using BossOfTheDungeons.Items.Base;
using BossOfTheDungeons.Items.Enums;

namespace BossOfTheDungeons.Units.Characters.Base;

public class Bag
{
    public int Money { get; private set; }


    private readonly List<Item> _items = new ();

    public void SetItem(Item item)
    {
        _items.Add(item);
    }

    public void Show()
    {
        Console.WriteLine($"Золото {Money}\n");

        Console.WriteLine("Предметы:\n");
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

    public int AddMoney(int money)
    {
        Money += money;
        return Money;
    }

    public int SpendMoney(int money)
    {
        Money -= money;
        return Money;
    }
}