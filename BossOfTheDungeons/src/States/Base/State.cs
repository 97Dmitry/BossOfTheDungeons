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

    public void AddStack(State state)
    {
        Stacks.Push(state);
    }

    public virtual void Update()
    {
        ConsoleClear();
    }

    protected static void ConsoleClear()
    {
        Console.Clear();
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine("--- Boss Of The Dungeons ---");
        Console.ResetColor();
        Console.SetCursorPosition(0, 2);
    }
}