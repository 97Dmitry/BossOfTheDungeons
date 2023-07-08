using System.Collections.Generic;
using BossOfTheDungeons.Items.Base;
using BossOfTheDungeons.Items.Enums;
using BossOfTheDungeons.Shopping.Base;
using BossOfTheDungeons.States.Base;
using BossOfTheDungeons.States.InitCharacter;
using BossOfTheDungeons.States.MainMenu;
using BossOfTheDungeons.Units.Characters.Base;

namespace BossOfTheDungeons;

public class Game
{
    private readonly Stack<State> _states;
    private Character _character;
    private readonly Shop _shop;

    public static int Level = 1;

    public Game()
    {
        _states = new Stack<State>();
        _shop = new Shop(new[]
        {
            new Item("Обычная кольчуга", ItemTypeEnum.Armor, 15),
            new Item("Шлем", ItemTypeEnum.Helmet, 10),
            new Weapon("Волшебная палка", ItemTypeEnum.Weapon, WeaponItemTypeEnum.OneHanded, 25)
        });
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