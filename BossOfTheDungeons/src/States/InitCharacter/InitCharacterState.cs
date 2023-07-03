using BossOfTheDungeons.States.Base;
using BossOfTheDungeons.Units.Characters.Base;
using System.Collections.Generic;
using System;
using BossOfTheDungeons.GUI;
using BossOfTheDungeons.Items.Base;
using BossOfTheDungeons.Items.Enums;
using BossOfTheDungeons.Units.Characters.Enums;

namespace BossOfTheDungeons.States.InitCharacter;

public class InitCharacterState : State
{
    public Character Character { get; private set; }

    public InitCharacterState(Stack<State> states)
        : base(states)
    {
    }

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

        var item = selectedClass switch
        {
            CharacterClassEnum.Warrior => new Weapon("Палка", ItemTypeEnum.Weapon, WeaponItemTypeEnum.TwoHanded, 5),
            CharacterClassEnum.Shadow => new Weapon("Кинжал", ItemTypeEnum.Weapon, WeaponItemTypeEnum.OneHanded, 2),
            CharacterClassEnum.Mage => new Weapon("Жезл", ItemTypeEnum.Weapon, WeaponItemTypeEnum.OneHanded, 4),
            _ => new Item("Тряпичные перчатки", ItemTypeEnum.Gloves, 1)
        };

        Character.TakeItem(item);
        End = true;
    }
}