using BossOfTheDungeons.Items.Enums;
using BossOfTheDungeons.Units.Characters.Structs;

namespace BossOfTheDungeons.Items.Base;

public class Item
{
    public string Name { get; }
    public ItemTypeEnum Type { get; }
    public readonly int Price;
    public ItemRate ItemRate { get; }

    public int Armor { get; }
    public Strength Strength { get; }
    public Dexterity Dexterity { get; }
    public Intelligence Intelligence { get; }
    public int Health { get; }
    public int ElementalResistance { get; }
    public int ChaosResistance { get; }
    public ItemPropertyType ItemPropertyType { get; }


    public Item(string name, ItemTypeEnum type, int price, ItemRate itemRate)
    {
        Name = name;
        Type = type;
        Price = price;
        ItemRate = itemRate;
    }

    public Item(string name, ItemTypeEnum type, int price, ItemRate itemRate, int armor, Strength strength,
        Dexterity dexterity,
        Intelligence intelligence, int health, int elementalResistance, int chaosResistance,
        ItemPropertyType itemPropertyType)
    {
        Name = name;
        Type = type;
        Price = price;
        ItemRate = itemRate;
        Armor = armor;
        Strength = strength;
        Dexterity = dexterity;
        Intelligence = intelligence;
        Health = health;
        ElementalResistance = elementalResistance;
        ChaosResistance = chaosResistance;
        ItemPropertyType = itemPropertyType;
    }

    public int PriceForSell()
    {
        return Price / 2;
    }
}