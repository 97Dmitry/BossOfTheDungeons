using System;
using System.Collections.Generic;
using BossOfTheDungeons.GUI;
using BossOfTheDungeons.Items.Utils.Generator;
using BossOfTheDungeons.States.Base;
using BossOfTheDungeons.Units.Characters.Base;
using BossOfTheDungeons.Units.Characters.Enums;

namespace BossOfTheDungeons.States.InitCharacter;

public class InitCharacterState : State
{
    public InitCharacterState(Stack<State> states)
        : base(states)
    {
    }

    public Character Character { get; private set; }

    public override void Update()
    {
        base.Update();
        Console.Write("Введите имя вашего персонажа: ");
        var charName = Console.ReadLine();

        Gui.ConsoleClear();

        CharacterClassEnum? selectedClass = null;

        while (selectedClass == null)
        {
            Console.WriteLine("Выберите класс вашего персонажа: ");

            var classes = (CharacterClassEnum[])Enum.GetValues(typeof(CharacterClassEnum));

            for (var i = 0; i < classes.Length; i++)
            {
                var separator = i == classes.Length - 1 ? "\n" : ", ";
                Console.Write($"{i + 1}. {classes[i]}{separator}");
            }

            var pressedKey = Console.ReadKey();

            selectedClass = pressedKey.Key switch
            {
                ConsoleKey.D1 => classes[0],
                ConsoleKey.D2 => classes[1],
                ConsoleKey.D3 => classes[2],
                _ => null
            };
            Console.WriteLine();
            if (selectedClass == null)
            {
                Console.WriteLine("Введено не корректное значение, попробуйте еще раз");
                Console.ReadKey();
                Gui.ConsoleClear();
            }
        }

        Character = new Character(charName, (CharacterClassEnum)selectedClass);

        var item = ItemGenerator.Generate();

        Character.TakeItem(item);
        End = true;
    }
}