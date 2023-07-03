using System;
using System.Collections.Generic;
using BossOfTheDungeons.Shopping.Base;
using BossOfTheDungeons.States.Bag;
using BossOfTheDungeons.States.Base;
using BossOfTheDungeons.States.Characteristic;
using BossOfTheDungeons.States.Inventory;
using BossOfTheDungeons.States.Shopping;
using BossOfTheDungeons.Units.Characters.Base;

namespace BossOfTheDungeons.States.MainMenu;

public class MainMenuState : State
{
    private readonly Character _character;
    private readonly Shop _shop;

    public MainMenuState(Stack<State> states, Character character, Shop shop)
        : base(states)
    {
        _character = character;
        _shop = shop;
    }

    public override void Update()
    {
        base.Update();
        Console.WriteLine("Нажмите '1', что бы открыть характеристики.");
        Console.WriteLine("Нажмите '2', что бы открыть сумку.");
        Console.WriteLine("Нажмите '3', что бы открыть магазин.");
        Console.WriteLine("Нажмите '4', что бы открыть инвентарь.");
        Console.WriteLine("Нажмите '9', что бы выйти.");

        var pressedKey = Console.ReadKey();

        if (pressedKey.Key == ConsoleKey.D1) AddStack(new CharacteristicState(Stacks, _character));
        if (pressedKey.Key == ConsoleKey.D2) AddStack(new BagState(Stacks, _character));
        if (pressedKey.Key == ConsoleKey.D3) AddStack(new ShopState(Stacks, _character, _shop));
        if (pressedKey.Key == ConsoleKey.D4) AddStack(new InventoryState(Stacks, _character));
        if (pressedKey.Key == ConsoleKey.D9) End = true;
    }
}