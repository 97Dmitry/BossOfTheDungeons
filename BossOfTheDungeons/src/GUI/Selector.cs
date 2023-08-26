using System;

namespace BossOfTheDungeons.GUI;

public class Selector
{
    private int _selectedIndex;
    private readonly string[] _options;
    private readonly string _prompt;
    private readonly int[]? _separator;
    private readonly Action? _beforeSelector;
    private readonly Action? _afterSelector;

    public Selector(
        string[] options,
        string prompt = "(С помощью стрелок выберите действие. Enter для подтверждения)",
        int[]? separator = null,
        Action? beforeSelector = null,
        Action? afterSelector = null
    )
    {
        _options = options;
        _prompt = prompt;
        _separator = separator;
        _beforeSelector = beforeSelector;
        _afterSelector = afterSelector;
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
            Console.CursorVisible = false;
            Gui.ConsoleClear();
            _beforeSelector?.Invoke();
            Console.Write("\n");

            DisplayOptions();

            _afterSelector?.Invoke();

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

        Console.CursorVisible = true;
        return _selectedIndex;
    }
}