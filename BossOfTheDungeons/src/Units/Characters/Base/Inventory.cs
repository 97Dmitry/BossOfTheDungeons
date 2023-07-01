using System;
using BossOfTheDungeons.Items.Base;
using BossOfTheDungeons.Items.Enums;

namespace BossOfTheDungeons.Units.Characters.Base;

public class Inventory
{
    private Item? _helmet;
    private Item? _gloves;
    private Item? _boots;
    private Item? _belt;
    private Item? _ring1;
    private Item? _ring2;
    private Item? _amulet;
    private Weapon? _weapon1;
    private Weapon? _weapon2;

    public void Show()
    {
        var helmet = _helmet != null ? $"{_helmet.Name}" : "отсутствует";
        Console.WriteLine($"Шлем {helmet}");

        var gloves = _gloves != null ? $"{_gloves.Name}" : "отсутствует";
        Console.WriteLine($"Перчатки {gloves}");

        var boots = _boots != null ? $"{_boots.Name}" : "отсутствует";
        Console.WriteLine($"Ботинки {boots}");

        var belt = _belt != null ? $"{_belt.Name}" : "отсутствует";
        Console.WriteLine($"Пояс {belt}");

        var ring1 = _ring1 != null ? $"{_ring1.Name}" : "отсутствует";
        Console.WriteLine($"Кольцо 1 {ring1}");

        var ring2 = _ring2 != null ? $"{_ring2.Name}" : "отсутствует";
        Console.WriteLine($"Кольцо 2 {ring2}");

        var amulet = _amulet != null ? $"{_amulet.Name}" : "отсутствует";
        Console.WriteLine($"Амулет {amulet}");

        var weapon1 = _weapon1 != null ? $"{_weapon1.Name}" : "отсутствует";
        Console.WriteLine($"Оружие 1 {weapon1}");

        var weapon2 = _weapon2 != null ? $"{_weapon2.Name}" : "отсутствует";
        Console.WriteLine($"Оружие 2 {weapon2}");
    }

    public void SetItem(ItemTypeEnum type, Item item, int? slot)
    {
        switch (type)
        {
            case ItemTypeEnum.Helmet:
                _helmet = item; break;
            case ItemTypeEnum.Gloves:
                _gloves = item; break;
            case ItemTypeEnum.Boots:
                _boots = item; break;
            case ItemTypeEnum.Belt:
                _belt = item; break;
            case ItemTypeEnum.Ring:
                if (slot == 1)
                {
                    _ring1 = item;
                    break;
                }
                if (slot == 2)
                {
                    _ring2 = item;
                    break;
                }
                break;
            case ItemTypeEnum.Amulet:
                _amulet = item; break;
            case ItemTypeEnum.Weapon:
                if (item is Weapon weapon)
                {
                    if (weapon.WeaponType == WeaponItemTypeEnum.TwoHanded)
                    {
                        _weapon1 = weapon;
                        _weapon2 = null;
                        break;
                    }
                    if (weapon.WeaponType == WeaponItemTypeEnum.Shield)
                    {
                        _weapon2 = weapon;
                        break;
                    }
                    if (weapon.WeaponType == WeaponItemTypeEnum.OneHanded)
                    {
                        if (slot == 1)
                        {
                            _weapon1 = weapon;
                            break;
                        }
                        if (slot == 2)
                        {
                            _weapon2 = weapon;
                            break;
                        }
                    }
                }
                break;
        }
    }
}