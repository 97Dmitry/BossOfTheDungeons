using System;
using BossOfTheDungeons.Items.Base;
using BossOfTheDungeons.Items.Enums;
using BossOfTheDungeons.Structs.Initialization;
using BossOfTheDungeons.Units.Characters.Base;
using BossOfTheDungeons.Units.Characters.Enums;
using BossOfTheDungeons.Shopping.Base;

namespace BossOfTheDungeons
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            ConsoleClear();

            var initData = InitCharacterData();
            Character character = new(initData.Name, initData.Class);

            Weapon item = new("Палка", ItemTypeEnum.Weapon, WeaponItemTypeEnum.TwoHanded, 1);
            character.TakeItem(item);

            Shop shop = new Shop(new[]
                {
                    new Item("Обычная кольчуга", ItemTypeEnum.Gloves, 15),
                    new Item("Шлем", ItemTypeEnum.Helmet, 10),
                    new Weapon("Волшебная палка", ItemTypeEnum.Weapon, WeaponItemTypeEnum.OneHanded, 25)
                }
            );

            while (true)
            {
                ConsoleClear();
                ShowCharacterGameActions(character, shop);
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

            while (selectedClass == null)
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
                if (selectedClass == null)
                {
                    Console.WriteLine("Введено не корректное значение, попробуйте еще раз");
                    Console.ReadKey();
                    ConsoleClear();
                }
            }

            return new InitCharacter(charName, (CharacterClassEnum)selectedClass);
        }

        private static void ShopActions(Character character, Shop shop)
        {
            while (true)
            {
                ConsoleClear();
                shop.Show();

                Console.WriteLine("Нажмите 1, если хотите что то купить");
                Console.WriteLine("Нажмите 2, что бы вернуться");

                var shopPressedKey = Console.ReadKey();

                if (shopPressedKey.Key == ConsoleKey.D1)
                {
                    while (true)
                    {
                        ConsoleClear();
                        shop.Show();

                        Console.WriteLine("Введите номер товара, который хотите купить");
                        Console.WriteLine("Или введите 'exit', что бы вернуться в магазин");

                        var commandOrProduct = Console.ReadLine();

                        if (commandOrProduct == "exit")
                        {
                            break;
                        }

                        if (int.TryParse(commandOrProduct, out int item))
                        {
                            if (item > shop.ProductCount())
                            {
                                Console.WriteLine("Вы выбрали несуществующий продукт");
                                Console.ReadKey();
                                continue;
                            }

                            var product = shop.GetProduct(item - 1);

                            if (product != null)
                            {
                                if (character.IsCanPay(product))
                                {
                                    var purchasedItem = shop.SellProduct(item - 1, character);
                                    Console.WriteLine($"Успешно куплено: {purchasedItem.Name}");
                                    Console.ReadKey();
                                    break;
                                }
                                else
                                {
                                    Console.WriteLine("У вас недостаточно золота");
                                    Console.ReadKey();
                                    break;
                                }
                            }
                        }
                        else
                        {
                            Console.WriteLine("Нужно ввести число или команду");
                            Console.ReadKey();
                        }
                    }
                }

                if (shopPressedKey.Key == ConsoleKey.D2)
                {
                    break;
                }

            }
        }

        private static void ShowCharacterGameActions(Character character, Shop shop)
        {
            Console.WriteLine("Нажмите '1', что бы открыть характеристики.");
            Console.WriteLine("Нажмите '2', что бы открыть сумку.");
            Console.WriteLine("Нажмите '3', что бы открыть магазин.");
            Console.WriteLine("Нажмите '4', что бы открыть инвентарь.");

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

            if (pressedKey.Key == ConsoleKey.D3)
            {
                ShopActions(character, shop);
            }

            if (pressedKey.Key == ConsoleKey.D4)
            {
                ConsoleClear();
                character.MyInventory();
                Console.ReadKey();
            }
        }
    }
}