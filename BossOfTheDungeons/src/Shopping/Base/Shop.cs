using System;
using System.Collections.Generic;
using BossOfTheDungeons.Items.Base;
using BossOfTheDungeons.Units.Characters.Base;
using BossOfTheDungeons.Utils;

namespace BossOfTheDungeons.Shopping.Base;

public class Shop
{
    private int _money;
    private readonly List<Item> _products = new();

    public Shop(Item[] items)
    {
        _money = 1000;
        _products.AddRange(items);
        ;
    }

    public void Show()
    {
        Console.WriteLine("Товары магазина:\n");
        for (var i = 0; i < _products.Count; i++)
            if (_products[i] is Weapon weapon)
                Console.WriteLine($"{i + 1}. {weapon.Name} {weapon.Type} {weapon.WeaponType}. Цена: {weapon.Price}");
            else
                Console.WriteLine($"{i + 1}. {_products[i].Name} {_products[i].Type}. Цена: {_products[i].Price} ");
        Console.Write("\n");
    }

    public void AddProducts(Item product)
    {
        _products.Add(product);
    }

    public void AddProducts(Item[] products)
    {
        _products.AddRange(products);
    }

    public Item GetProduct(int id)
    {
        return _products[id];
    }

    public int ProductCount()
    {
        return _products.Count;
    }

    public Item SellProduct(int id, Character character)
    {
        var money = character.BuyItem(_products[id]);
        _money += money;
        return _products.RemoveAtAndReturn(id);
    }
}