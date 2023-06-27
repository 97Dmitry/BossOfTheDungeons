using BossOfTheDungeons.Items.Enums;

namespace BossOfTheDungeons.Items.Base;

public class Item
{
    public string Name { get; }
    public ItemTypeEnum Type { get; }

    public Item(string name, ItemTypeEnum type)
    {
        Name = name;
        Type = type;
    }
}