using BossOfTheDungeons.States.Base;
using BossOfTheDungeons.Units.Characters.Base;
using System.Collections.Generic;
using BossOfTheDungeons.Shopping.Base;
using System;

namespace BossOfTheDungeons.States.Shopping;

public class ShopState : State
{
    private readonly Character _character;
    private readonly Shop _shop;

    public ShopState(Stack<State> states, Character character, Shop shop)
        : base(states)
    {
        _character = character;
        _shop = shop;
    }

    public override void Update()
    {
        base.Update();
        _shop.Show();
        Console.WriteLine("Нажмите 1, если хотите что то купить");
        Console.WriteLine("Нажмите 2, что бы вернуться");

        var shopPressedKey = Console.ReadKey();

        if (shopPressedKey.Key == ConsoleKey.D1)
            while (true)
            {
                ConsoleClear();
                _shop.Show();

                Console.WriteLine("Введите номер товара, который хотите купить");
                Console.WriteLine("Или введите 'exit', что бы вернуться в магазин");

                var commandOrProduct = Console.ReadLine();

                if (commandOrProduct == "exit") break;

                if (int.TryParse(commandOrProduct, out var item))
                {
                    if (item > _shop.ProductCount())
                    {
                        Console.WriteLine("Вы выбрали несуществующий продукт");
                        Console.ReadKey();
                        continue;
                    }

                    var product = _shop.GetProduct(item - 1);

                    if (product != null)
                    {
                        if (_character.IsCanPay(product))
                        {
                            var purchasedItem = _shop.SellProduct(item - 1, _character);
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

        if (shopPressedKey.Key == ConsoleKey.D2) End = true;
    }
}