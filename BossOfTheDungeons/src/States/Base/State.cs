using System.Collections.Generic;
using BossOfTheDungeons.GUI;

namespace BossOfTheDungeons.States.Base;

public class State
{
    protected readonly Stack<State> Stacks;
    protected bool End = false;
    protected bool EndGame = false;

    protected State(Stack<State> stacks)
    {
        Stacks = stacks;
    }

    public bool RequestEnd()
    {
        return End;
    }

    public bool RequestEndGame()
    {
        return EndGame;
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