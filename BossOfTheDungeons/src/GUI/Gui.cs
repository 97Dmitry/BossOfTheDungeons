using System;

namespace BossOfTheDungeons.GUI;

public class Gui
{
    public static void ConsoleClear()
    {
        Console.Clear();
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine("--- Boss Of The Dungeons ---");
        Console.ResetColor();
        Console.SetCursorPosition(0, 2);
    }
}