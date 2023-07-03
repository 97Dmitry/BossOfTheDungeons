using BossOfTheDungeons.Shopping.Base;
using BossOfTheDungeons.States.Base;
using BossOfTheDungeons.Units.Characters.Base;
using System.Collections.Generic;
using System;

namespace BossOfTheDungeons.States.Characteristic;

public class CharacteristicState : State
{
    private readonly Character _character;

    public CharacteristicState(Stack<State> states, Character character)
        : base(states)
    {
        _character = character;
    }

    public override void Update()
    {
        base.Update();
        _character.CharacterInfo();
        Console.ReadKey();
        End = true;
    }
}