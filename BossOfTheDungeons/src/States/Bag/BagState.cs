using BossOfTheDungeons.States.Base;
using BossOfTheDungeons.Units.Characters.Base;
using System.Collections.Generic;
using System;

namespace BossOfTheDungeons.States.Bag;

public class BagState : State
{
    private readonly Character _character;

    public BagState(Stack<State> states, Character character)
        : base(states)
    {
        _character = character;
    }

    public override void Update()
    {
        base.Update();
        _character.MyBag();
        Console.ReadKey();
        End = true;
    }
}