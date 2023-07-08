using System.Collections.Generic;
using BossOfTheDungeons.Units.Enemies.Base;

namespace BossOfTheDungeons.Dungeons.Base;

public class Dungeon
{
    public List<Enemy> Enemies { get; private set; } = null;
}