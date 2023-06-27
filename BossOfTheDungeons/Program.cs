using System;
using BossOfTheDungeons.Items.Base;
using BossOfTheDungeons.Items.Enums;
using BossOfTheDungeons.Units.Characters.Base;

namespace BossOfTheDungeons
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            ConsoleClear();
            
            Console.Write("Введите имя вашего персонажа: ");
            var charName = Console.ReadLine();

            while (true)
            {
                ConsoleClear();
                
                Character character = new Character(charName);
                Weapon item = new Weapon("Палка", ItemTypeEnum.Weapon, WeaponItemTypeEnum.TwoHanded);
                character.TakeItem(item);

                Console.WriteLine("Нажмите '1', что бы открыть сумку.");
                ConsoleKeyInfo pressedKey = Console.ReadKey();

                if (pressedKey.Key == ConsoleKey.D1)
                {
                    ConsoleClear();
                    Console.WriteLine("Ваша сумка:");
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
    }
}