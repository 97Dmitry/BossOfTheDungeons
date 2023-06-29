using System;
using BossOfTheDungeons.Items.Base;
using BossOfTheDungeons.Items.Enums;
using BossOfTheDungeons.Structs.Initialization;
using BossOfTheDungeons.Units.Characters.Base;
using BossOfTheDungeons.Units.Characters.Enums;

namespace BossOfTheDungeons
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            ConsoleClear();

            var initData = InitCharacterData();

            while (true)
            {
                ConsoleClear();
                
                Character character = new (initData.Name, initData.Class);
                Weapon item = new ("Палка", ItemTypeEnum.Weapon, WeaponItemTypeEnum.TwoHanded);
                character.TakeItem(item);

                Console.WriteLine("Нажмите '1', что бы открыть характеристики.");
                Console.WriteLine("Нажмите '2', что бы открыть сумку.");
                var pressedKey = Console.ReadKey();

                if (pressedKey.Key == ConsoleKey.D1)
                {
                    ConsoleClear();
                    character.CharacterInfo();
                    Console.ReadKey();
                }

                if (pressedKey.Key == ConsoleKey.D2)
                {
                    ConsoleClear();
                    character.MyBag();
                    Console.ReadKey();
                }
            }
            
        }

        private static void ConsoleClear()
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("--- Boss Of The Dungeons ---");
            Console.ResetColor();
            Console.SetCursorPosition(0, 2);
        }

        private static InitCharacter InitCharacterData()
        {
            Console.Write("Введите имя вашего персонажа: ");
            var charName = Console.ReadLine();

            ConsoleClear();

            CharacterClassEnum? selectedClass = null;

            while (!Convert.ToBoolean(selectedClass))
            {
                Console.WriteLine("Выберите класс вашего персонажа: ");

                var classes = (CharacterClassEnum[])Enum.GetValues(typeof(CharacterClassEnum));
                
                for (var i = 0; i < classes.Length; i++)
                {
                    string separator = i == classes.Length - 1 ? "\n" : ", ";
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
                if (!Convert.ToBoolean(selectedClass))
                {
                    Console.WriteLine("Введено не корректное значение, попробуйте еще раз");
                    Console.ReadKey();
                    ConsoleClear();
                }
            }

            return new InitCharacter(charName, (CharacterClassEnum)selectedClass);
        }
    }
}