using System.Collections.Generic;
using BossOfTheDungeons.Units.Enemies.Base;

namespace BossOfTheDungeons.Dungeons.Base;

public class Dungeon
{
    public Dungeon()
    {
        Level = 1;
    }

    public static int Level { get; private set; }

    public List<Enemy> Enemies { get; private set; } = null;
}