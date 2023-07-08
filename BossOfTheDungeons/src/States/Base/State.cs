using BossOfTheDungeons.GUI;
using System;
using System.Collections.Generic;

namespace BossOfTheDungeons.States.Base;

public class State
{
    protected readonly Stack<State> Stacks;
    protected bool End = false;

    protected State(Stack<State> stacks)
    {
        Stacks = stacks;
    }

    public bool RequestEnd()
    {
        return End;
    }

    protected void AddStack(State state)
    {
        Stacks.Push(state);
    }

    public virtual void Update()
    {
        Gui.ConsoleClear();
    }
}