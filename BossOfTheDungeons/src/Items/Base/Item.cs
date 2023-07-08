using BossOfTheDungeons.Items.Enums;
using BossOfTheDungeons.Units.Characters.Structs;

namespace BossOfTheDungeons.Items.Base;

public class Item
{
    public string Name { get; }
    public ItemTypeEnum Type { get; }
    public readonly int Price;
    public ItemRate ItemRate { get; }

    protected int Armor { get; }
    protected Strength Strength { get; }
    protected Dexterity Dexterity { get; }
    protected Intelligence Intelligence { get; }
    protected int Health { get; }
    protected int ElementalResistance { get; }
    protected int ChaosResistance { get; }
    protected ItemPropertyType ItemPropertyType { get; }


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