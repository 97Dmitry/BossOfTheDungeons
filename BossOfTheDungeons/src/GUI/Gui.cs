using System;
using System.Linq;
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

    public static void RenderColumnsWithSpacing(string[] column1, string[] column2, int columnSpacing)
    {
        var maxLength = Math.Max(column1.Length, column2.Length);

        for (var i = 0; i < maxLength; i++)
        {
            var value1 = i < column1.Length ? column1[i] : string.Empty;
            var value2 = i < column2.Length ? column2[i] : string.Empty;

            var maxColumnLength = column1.Select(item => item.Length).Prepend(0).Max();

            var output = value1.PadRight(column1[i].Length + columnSpacing + (maxColumnLength - column1[i].Length)) +
                         value2;
            WriteLine(output);
        }
    }
}