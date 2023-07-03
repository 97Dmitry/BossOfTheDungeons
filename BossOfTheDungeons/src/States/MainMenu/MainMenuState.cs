using System;
using System.Collections.Generic;
using BossOfTheDungeons.GUI;
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
        var selector = new Selector(
            new[] { "Характеристики", "Сумка", "Магазин", "Инвентарь", "Выход" },
            separator: new[] { 3 }
        );
        var selectedIndex = selector.Run();

        if (selectedIndex == 0) AddStack(new CharacteristicState(Stacks, _character));
        if (selectedIndex == 1) AddStack(new BagState(Stacks, _character));
        if (selectedIndex == 2) AddStack(new ShopState(Stacks, _character, _shop));
        if (selectedIndex == 3) AddStack(new InventoryState(Stacks, _character));
        if (selectedIndex == 4) End = true;
    }
}