using System.Collections.Generic;
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

    public void GenerateEnemies()
    {
        if (Level < 10) Enemies.Add(new Enemy(Level));

        if (Level is > 9 and < 20)
        {
            Enemies.Add(new Enemy(Level));
            Enemies.Add(new Enemy(Level));
        }

        if (Level > 19)
        {
            Enemies.Add(new Enemy(Level));
            Enemies.Add(new Enemy(Level));
            Enemies.Add(new Enemy(Level));
        }
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
}