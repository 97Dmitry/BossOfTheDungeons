using System;
using System.Collections.Generic;
using BossOfTheDungeons.Items.Base;
using BossOfTheDungeons.Items.Utils.Generator;
using BossOfTheDungeons.Shopping.Base;
using BossOfTheDungeons.States.Base;
using BossOfTheDungeons.States.InitCharacter;
using BossOfTheDungeons.States.MainMenu;
using BossOfTheDungeons.Units.Characters.Base;

namespace BossOfTheDungeons;

public class Game
{
    public static int Level = 1;
    private readonly Stack<State> _states;
    private readonly Shop _shop;
    private Character _character;

    public Game()
    {
        var productRange = new Random().Next(1, 7);

        var items = new Item[productRange];

        for (var i = 0; i < productRange; i++) items[i] = ItemGenerator.Generate();

        _states = new Stack<State>();
        _shop = new Shop(items);
    }

    public void Init()
    {
        var initCharacterDataState = new InitCharacterState(_states);
        initCharacterDataState.Update();
        _character = initCharacterDataState.Character;
        _states.Push(new MainMenuState(_states, _character, _shop));
    }

    public void Run()
    {
        while (_states.Count > 0)
        {
            _states.Peek().Update();
            if (_states.Peek().RequestEnd())
                _states.Pop();
        }
    }
}