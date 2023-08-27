using System;
using System.Collections.Generic;
using BossOfTheDungeons.Items.Base;
using BossOfTheDungeons.Items.Utils.Generator;
using BossOfTheDungeons.Units.Characters.Base;
using BossOfTheDungeons.Utils;

namespace BossOfTheDungeons.Shopping.Base;

public class Shop
{
    private int _money;
    private readonly List<Item> _products = new();
    private readonly Random random = new();

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
            {
                Console.WriteLine($"{i + 1}. {weapon.Name} {weapon.Type} {weapon.WeaponType}. Цена: {weapon.Price}");
                Console.WriteLine(
                    $"\tУрон предмета: Физический урон: {weapon.PhysicalDamage}, Магический урон: {weapon.MagicalDamage}, Урон хаосом: {weapon.ChaosDamage}.");
                Console.WriteLine(
                    $"\tБонусные характеристики: Точность: {weapon.Accuracy}, Скорость атаки: {weapon.AttackSpeed}, Скорость сотворения чар: {weapon.CastSpeed}.");
            }
            else
            {
                var item = _products[i];
                Console.WriteLine($"{i + 1}. {item.Name} {item.Type}. Цена: {item.Price} ");
                Console.WriteLine(
                    $"\tХарактеристик: Сила: {(int)item.Strength}, Ловкость: {(int)item.Dexterity}, Интеллект: {(int)item.Intelligence}.");
                Console.WriteLine(
                    $"\tБонусные характеристики: Здоровье: {item.Health}, Броня: {item.Armor}.");
                Console.WriteLine(
                    $"\tСопротивления: Стихиям: {item.ElementalResistance}, Хаосу: {item.ChaosResistance}.");
            }

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

    public void UpdateProducts()
    {
        _products.Clear();
        var productRange = random.Next(1, 7);
        var items = new Item[productRange];
        for (var i = 0; i < productRange; i++) items[i] = ItemGenerator.Generate();
        _products.AddRange(items);
    }
}