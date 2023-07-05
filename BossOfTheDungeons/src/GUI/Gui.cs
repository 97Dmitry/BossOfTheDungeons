using System;
using static System.Console;

namespace BossOfTheDungeons.GUI;

public static class Gui
{
    public static void ConsoleClear()
    {
        Clear();
        ForegroundColor = ConsoleColor.Red;
        WriteLine("--- Boss Of The Dungeons ---");
        ResetColor();
        SetCursorPosition(0, 2);
    }
}