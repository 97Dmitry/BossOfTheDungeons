using System;
using System.Linq;
using BossOfTheDungeons.Items.Enums;

namespace BossOfTheDungeons.Items.Utils.Generator;

public static class ItemRareGenerator
{
    private static readonly Random Random = new();

    private static readonly ItemRate[] rates = Enumerable.Repeat(ItemRate.Common, 70)
        .Concat(Enumerable.Repeat(ItemRate.Magical, 20))
        .Concat(Enumerable.Repeat(ItemRate.Rare, 9))
        .Concat(Enumerable.Repeat(ItemRate.Legendary, 1))
        .ToArray();

    public static ItemRate GetRandomItemRate()
    {
        var index = Random.Next(rates.Length);
        return rates[index];
    }
}