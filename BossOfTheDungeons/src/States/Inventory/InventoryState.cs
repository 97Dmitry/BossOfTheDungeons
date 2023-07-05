using BossOfTheDungeons.States.Base;
using BossOfTheDungeons.Units.Characters.Base;
using System.Collections.Generic;
using System;
using BossOfTheDungeons.GUI;
using BossOfTheDungeons.Items.Base;
using BossOfTheDungeons.Items.Enums;
using System.Linq;

namespace BossOfTheDungeons.States.Inventory;

public class InventoryState : State
{
    private readonly Character _character;

    public InventoryState(Stack<State> states, Character character)
        : base(states)
    {
        _character = character;
    }

    private void ShowItems(Dictionary<int, Item> items, int? slot = 1)
    {
        Console.WriteLine("Вы можете надеть:\n");

        var index = 1;
        var keys = items.Keys.ToArray();

        foreach (var pair in items)
        {
            var item = pair.Value;
            if (item is Weapon weapon)
                Console.WriteLine($"{index}. {weapon.Name} {weapon.WeaponType}");
            else
                Console.WriteLine($"{index}. {pair.Value.Name}");
            index++;
        }

        Console.WriteLine("\n(Что бы вернуться, введите 'exit')");
        Console.Write("Введите номер предмета, который хотите надеть: ");
        var input = Console.ReadLine();

        if (input == "exit") return;

        if (int.TryParse(input, out var selectedItemIndex))
        {
            if (selectedItemIndex > keys.Length || selectedItemIndex < 1)
            {
                Console.WriteLine("Выбранный предмет не существует");
                Console.ReadKey();
            }
            else
            {
                _character.PutItem(items[keys[selectedItemIndex - 1]], slot);
            }
        }
        else
        {
            Console.WriteLine("Выбранный предмет не существует");
            Console.ReadKey();
        }
    }

    public override void Update()
    {
        var selector = new Selector(
            new[] { "Выбрать слот", "Выход" },
            beforeSelector: () => _character.MyInventory()
        );

        var selectedSlot = selector.Run();

        if (selectedSlot == 0)
        {
            base.Update();
            _character.MyInventory();

            Console.Write("\nВведите номер слота: ");
            var keyInfo = Console.ReadKey();

            switch (keyInfo.Key)
            {
                case ConsoleKey.D1:
                    var helmets = _character.GetBagItemsByType(ItemTypeEnum.Helmet);
                    base.Update();
                    ShowItems(helmets);

                    break;
                case ConsoleKey.D2:
                    var gloves = _character.GetBagItemsByType(ItemTypeEnum.Gloves);
                    base.Update();
                    ShowItems(gloves);

                    break;
                case ConsoleKey.D3:
                    var boots = _character.GetBagItemsByType(ItemTypeEnum.Boots);
                    base.Update();
                    ShowItems(boots);

                    break;
                case ConsoleKey.D4:
                    var belts = _character.GetBagItemsByType(ItemTypeEnum.Belt);
                    base.Update();
                    ShowItems(belts);

                    break;
                case ConsoleKey.D5:
                    var rings1 = _character.GetBagItemsByType(ItemTypeEnum.Ring);
                    base.Update();
                    ShowItems(rings1);

                    break;
                case ConsoleKey.D6:
                    var rings2 = _character.GetBagItemsByType(ItemTypeEnum.Ring);
                    base.Update();
                    ShowItems(rings2, 2);

                    break;
                case ConsoleKey.D7:
                    var amulets = _character.GetBagItemsByType(ItemTypeEnum.Amulet);
                    base.Update();
                    ShowItems(amulets);

                    break;
                case ConsoleKey.D8:
                    var weapons1 = _character.GetBagItemsByType(ItemTypeEnum.Weapon);
                    base.Update();
                    ShowItems(weapons1);

                    break;
                case ConsoleKey.D9:
                    var weapons2 = _character.GetBagItemsByType(ItemTypeEnum.Weapon);
                    base.Update();
                    ShowItems(weapons2, 2);

                    break;
            }
        }
        else
        {
            End = true;
        }
    }
}