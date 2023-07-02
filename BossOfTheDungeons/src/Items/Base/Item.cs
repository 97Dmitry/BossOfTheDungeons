using BossOfTheDungeons.Items.Enums;

namespace BossOfTheDungeons.Items.Base;

public class Item
{
    public string Name { get; }
    public ItemTypeEnum Type { get; }
    public readonly int Price;

    public Item(string name, ItemTypeEnum type, int price)
    {
        Name = name;
        Type = type;
        Price = price;
    }

    public int PriceForSell()
    {
        return Price / 2;
    }
}