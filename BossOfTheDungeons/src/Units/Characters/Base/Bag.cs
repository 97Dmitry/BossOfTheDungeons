using System;
using System.Collections.Generic;
using System.Linq;
using BossOfTheDungeons.Items.Base;
using BossOfTheDungeons.Items.Enums;

namespace BossOfTheDungeons.Units.Characters.Base;

public class Bag
{
    public int Money { get; private set; }

    private readonly Dictionary<int, Item> _items = new();

    public void SetItem(Item item)
    {
        _items.Add(item.GetHashCode(), item);
    }

    public void DeleteItem(Item item)
    {
        _items.Remove(item.GetHashCode());
    }

    public void Show()
    {
        Console.WriteLine($"Золото: {Money}\n");

        Console.WriteLine("Предметы:\n");
        var index = 1;
        foreach (var item in _items.Select(collectionItem => collectionItem.Value))
        {
            if (item is Weapon weapon)
                Console.WriteLine($"{index}. {weapon.Name} {weapon.Type} {weapon.WeaponType}");
            else
                Console.WriteLine($"{index}. {item.Name} {item.Type}");
            index++;
        }
    }

    public Dictionary<int, Item> GetItemsByType(ItemTypeEnum type)
    {
        return _items.Where(item => item.Value.Type == type).ToDictionary(pair => pair.Key, pair => pair.Value);
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