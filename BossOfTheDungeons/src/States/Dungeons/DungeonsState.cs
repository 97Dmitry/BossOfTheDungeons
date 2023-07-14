using System;
using System.Collections.Generic;
using BossOfTheDungeons.Dungeons.Base;
using BossOfTheDungeons.GUI;
using BossOfTheDungeons.States.Base;
using BossOfTheDungeons.Units.Characters.Base;

namespace BossOfTheDungeons.States.Dungeons;

public class DungeonsState : State
{
    private readonly Dungeon _dungeon;
    private readonly Character _character;

    public DungeonsState(Stack<State> states, Dungeon dungeon, Character character) : base(states)
    {
        _dungeon = dungeon;
        _character = character;
    }

    public override void Update()
    {
        var enemies = new string[_dungeon.Enemies.Count];
        string[] character =
        {
            $"{_character.Name} Здоровье: {_character.Health}/{_character.FullHealth}"
        };

        for (var i = 0; i < _dungeon.Enemies.Count; i++)
            enemies[i] =
                $"{_dungeon.Enemies[i].Name} Здоровье: {_dungeon.Enemies[i].Health}/{_dungeon.Enemies[i].Health}";

        while (enemies.Length > 0)
        {
            base.Update();
            Console.WriteLine($"Подземелье уровня {Dungeon.Level}\n");
            Gui.RenderColumnsWithSpacing(enemies, character, 4);
            Console.ReadKey();
        }
    }
}