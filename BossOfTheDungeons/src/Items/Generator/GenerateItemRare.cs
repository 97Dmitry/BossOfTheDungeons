using BossOfTheDungeons.Items.Enums;
using System.Linq;
using System;

namespace BossOfTheDungeons.Items.Generator;

public static class GenerateItemRare
{
    private static Random random = new();

    private static ItemRate[] rates = Enumerable.Repeat(ItemRate.Common, 70)
        .Concat(Enumerable.Repeat(ItemRate.Magical, 20))
        .Concat(Enumerable.Repeat(ItemRate.Rare, 9))
        .Concat(Enumerable.Repeat(ItemRate.Legendary, 1))
        .ToArray();

    public static ItemRate GetRandomItemRate()
    {
        var index = random.Next(rates.Length);
        return rates[index];
    }
}