using System;
using System.Collections.Generic;
using BossOfTheDungeons.Dungeons.Structs;
using BossOfTheDungeons.Items.Base;
using BossOfTheDungeons.Units.Enemies.Base;
using BossOfTheDungeons.Utils;

namespace BossOfTheDungeons.Dungeons.Base;

public class Dungeon
{
    public static int Level { get; private set; }

    public List<Enemy> Enemies { get; } = new();

    public Dungeon()
    {
        Level = 1;
        GenerateEnemies();
    }

    private void GenerateEnemies()
    {
        if (Level < 10) Enemies.Add(new Enemy(Level));
        if (Level is > 9 and < 20) Enemies.AddRange(new List<Enemy> { new(Level), new(Level) });
        if (Level > 19) Enemies.AddRange(new List<Enemy> { new(Level), new(Level), new(Level) });
    }

    public List<Enemy> CheckAndRemoveDeadEnemies()
    {
        var deadEnemies = new List<Enemy>();

        for (var i = 0; i < Enemies.Count; i++)
            if (Enemies[i].Health <= 0)
            {
                var deadEnemy = Enemies.RemoveAtAndReturn(i);
                deadEnemies.Add(deadEnemy);
            }

        return deadEnemies;
    }

    public DungeonLoot Win()
    {
        Level++;
        GenerateEnemies();
        return new DungeonLoot
        {
            Money = 1 + Level,
            Items = Array.Empty<Item>()
        };
    }
}