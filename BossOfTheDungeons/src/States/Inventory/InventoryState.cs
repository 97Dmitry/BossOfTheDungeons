using BossOfTheDungeons.States.Base;
using BossOfTheDungeons.Units.Characters.Base;
using System.Collections.Generic;
using System;

namespace BossOfTheDungeons.States.Inventory;

public class InventoryState : State
{
    private readonly Character _character;

    public InventoryState(Stack<State> states, Character character)
        : base(states)
    {
        _character = character;
    }

    public override void Update()
    {
        base.Update();
        _character.MyInventory();
        Console.ReadKey();
        End = true;
    }
}