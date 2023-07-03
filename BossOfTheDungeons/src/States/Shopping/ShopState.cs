using BossOfTheDungeons.States.Base;
using BossOfTheDungeons.Units.Characters.Base;
using System.Collections.Generic;
using BossOfTheDungeons.Shopping.Base;
using System;
using BossOfTheDungeons.GUI;

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

        var selector = new Selector(
            new[] { "К покупкам", "Выход" },
            separator: new[] { 0 },
            afterClear: () => _shop.Show()
        );
        var selectedIndex = selector.Run();

        if (selectedIndex == 0)
            while (true)
            {
                Gui.ConsoleClear();
                _shop.Show();

                var shopSelector = new Selector(
                    new[] { "Выбрать товар", "Выход" },
                    separator: new[] { 0 },
                    afterClear: () => _shop.Show()
                );
                var shopSelectedIndex = shopSelector.Run();

                if (shopSelectedIndex == 1) break;

                Gui.ConsoleClear();
                _shop.Show();
                Console.Write("Введите номер товара: ");
                var productIndex = Console.ReadLine();

                if (int.TryParse(productIndex, out var item))
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

        if (selectedIndex == 1) End = true;
    }
}