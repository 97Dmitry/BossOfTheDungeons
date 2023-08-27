using System;
using System.Collections.Generic;
using BossOfTheDungeons.Dungeons.Base;
using BossOfTheDungeons.States.Base;
using BossOfTheDungeons.Units.Characters.Base;

namespace BossOfTheDungeons.States.EndGame;

public class EndGameState : State
{
    private readonly Character _character;
    private readonly Dungeon _dungeon;


    public EndGameState(Stack<State> states, Character character, Dungeon dungeon) : base(states)
    {
        _character = character;
        _dungeon = dungeon;
    }

    public override void Update()
    {
        base.Update();
        Console.WriteLine("Конец игры\n");
        Console.WriteLine($"Вы прошли {Dungeon.Level - 1} уровней подземелья");

        Console.WriteLine($"В подземелье {Dungeon.Level} уровня остались:");
        foreach (var enemy in _dungeon.Enemies)
            Console.WriteLine($"\t{enemy.Name} - {enemy.Health}/{enemy.FullHealth}");

        Console.ReadLine();
        EndGame = true;
    }
}