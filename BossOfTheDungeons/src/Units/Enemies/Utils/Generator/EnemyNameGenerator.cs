using System;
using System.Collections.Generic;

namespace BossOfTheDungeons.Units.Enemies.Utils.Generator;

public static class EnemyNameGenerator
{
    private static readonly Random random = new();

    private static readonly List<string> prefixes = new()
        { "Темный", "Злой", "Огненный", "Ледяной", "Теневой", "Ядовитый", "Кровавый" };

    private static readonly List<string> names = new()
        { "Маг", "Воин", "Дракон", "Гоблин", "Орк", "Нежить", "Элементаль", "Демон" };

    private static readonly List<string> suffixes = new()
        { "Убийца", "Разрушитель", "Пожиратель", "Мучитель", "Завоеватель", "Повелитель", "Властелин" };

    public static string GenerateEnemyName()
    {
        var prefix = prefixes[random.Next(prefixes.Count)];
        var name = names[random.Next(names.Count)];
        var suffix = suffixes[random.Next(suffixes.Count)];

        return $"{prefix} {name} {suffix}";
    }
}