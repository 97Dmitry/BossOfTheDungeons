using System;
using System.Collections.Generic;
using BossOfTheDungeons.Items.Base;

namespace BossOfTheDungeons.Shopping.Base;

public class Shop
{
    private int _money;
    private readonly List<Item> _products = new ();

    public Shop(Item[] items)
    {
        _money = 1000;
        _products.AddRange(items);;
    }

    public void Show()
    {
        Console.WriteLine("Товары магазина:\n");
        for (int i = 0; i < _products.Count; i++)
        {
            if (_products[i] is Weapon weapon)
            {
                Console.WriteLine($"{i + 1}. {weapon.Type} {weapon.Type} {weapon.WeaponType} ");
            }
            else
            {
                Console.WriteLine($"{i + 1}. {_products[i].Type} {_products[i].Name}");
            }
        }
    }

    public void AddProducts(Item product)
    {
        _products.Add(product);
    }
    public void AddProducts(Item[] product)
    {
        _products.AddRange(product);
    }
}