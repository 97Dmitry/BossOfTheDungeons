using System;

namespace BossOfTheDungeons.GUI;

public class Selector
{
    private int _selectedIndex;
    private string[] _options;
    private string _prompt;
    private int[] _separator;
    private Action _afterClear;

    public Selector(
        string[] options,
        string prompt = "(С помощью стрелок выберите действие. Enter для подтверждения)",
        int[] separator = null,
        Action afterClear = null
    )
    {
        _options = options;
        _prompt = prompt;
        _separator = separator;
        _afterClear = afterClear;
    }

    private void DisplayOptions()
    {
        Console.WriteLine(_prompt + "\n");
        for (var i = 0; i < _options.Length; i++)
        {
            var currentOption = _options[i];
            var prefix = ' ';

            if (i == _selectedIndex)
            {
                prefix = '*';
                Console.ForegroundColor = ConsoleColor.Black;
                Console.BackgroundColor = ConsoleColor.White;
            }

            Console.WriteLine($"{prefix} << {currentOption} >>");

            if (_separator != null)
                if (Array.Exists(_separator, separator => separator == i))
                    Console.Write("\n");

            Console.ResetColor();
        }
    }

    public int Run()
    {
        ConsoleKey pressedKey;

        do
        {
            Gui.ConsoleClear();
            _afterClear?.Invoke();

            DisplayOptions();

            var keyInfo = Console.ReadKey();
            pressedKey = keyInfo.Key;

            if (pressedKey == ConsoleKey.UpArrow)
            {
                _selectedIndex--;
                if (_selectedIndex < 0)
                    _selectedIndex = _options.Length - 1;
            }
            else if (pressedKey == ConsoleKey.DownArrow)
            {
                _selectedIndex++;
                if (_selectedIndex == _options.Length)
                    _selectedIndex = 0;
            }
        } while (pressedKey != ConsoleKey.Enter);

        return _selectedIndex;
    }
}