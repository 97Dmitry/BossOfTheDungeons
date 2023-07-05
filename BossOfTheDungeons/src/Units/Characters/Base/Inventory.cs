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
        Console.WriteLine($"1. Шлем {helmet}");

        var gloves = _gloves != null ? $"{_gloves.Name}" : "отсутствует";
        Console.WriteLine($"2. Перчатки {gloves}");

        var boots = _boots != null ? $"{_boots.Name}" : "отсутствует";
        Console.WriteLine($"3. Ботинки {boots}");

        var belt = _belt != null ? $"{_belt.Name}" : "отсутствует";
        Console.WriteLine($"4. Пояс {belt}");

        var ring1 = _ring1 != null ? $"{_ring1.Name}" : "отсутствует";
        Console.WriteLine($"5. Кольцо 1 {ring1}");

        var ring2 = _ring2 != null ? $"{_ring2.Name}" : "отсутствует";
        Console.WriteLine($"6. Кольцо 2 {ring2}");

        var amulet = _amulet != null ? $"{_amulet.Name}" : "отсутствует";
        Console.WriteLine($"7. Амулет {amulet}");

        var weapon1 = _weapon1 != null ? $"{_weapon1.Name}" : "отсутствует";
        Console.WriteLine($"8. Оружие 1 {weapon1}");

        var weapon2 = _weapon2 != null ? $"{_weapon2.Name}" : "отсутствует";
        Console.WriteLine($"9. Оружие 2 {weapon2}");
    }

    public void SetItem(Item item, Bag bag, int? slot = 1)
    {
        switch (item.Type)
        {
            case ItemTypeEnum.Helmet:
                if (_helmet != null) bag.SetItem(_helmet);
                _helmet = item;
                bag.DeleteItem(item);
                break;
            case ItemTypeEnum.Gloves:
                if (_gloves != null) bag.SetItem(_gloves);
                _gloves = item;
                bag.DeleteItem(item);
                break;
            case ItemTypeEnum.Boots:
                if (_boots != null) bag.SetItem(_boots);
                _boots = item;
                bag.DeleteItem(item);
                break;
            case ItemTypeEnum.Belt:
                if (_belt != null) bag.SetItem(_belt);
                _belt = item;
                bag.DeleteItem(item);
                break;
            case ItemTypeEnum.Ring:
                if (slot == 1)
                {
                    if (_ring1 != null) bag.SetItem(_ring1);
                    _ring1 = item;
                    bag.DeleteItem(item);
                    break;
                }

                if (slot == 2)
                {
                    if (_ring2 != null) bag.SetItem(_ring2);
                    _ring2 = item;
                    bag.DeleteItem(item);
                }

                break;
            case ItemTypeEnum.Amulet:
                if (_amulet != null) bag.SetItem(_amulet);
                _amulet = item;
                bag.DeleteItem(item);
                break;
            case ItemTypeEnum.Weapon:
                if (item is Weapon weapon)
                {
                    if (weapon.WeaponType == WeaponItemTypeEnum.TwoHanded)
                    {
                        if (_weapon1 != null) bag.SetItem(_weapon1);
                        if (_weapon2 != null) bag.SetItem(_weapon2);
                        _weapon1 = weapon;
                        _weapon2 = null;
                        bag.DeleteItem(item);
                        break;
                    }

                    if (weapon.WeaponType == WeaponItemTypeEnum.Shield)
                    {
                        if (_weapon2 != null) bag.SetItem(_weapon2);
                        _weapon2 = weapon;
                        bag.DeleteItem(item);
                        break;
                    }

                    if (weapon.WeaponType == WeaponItemTypeEnum.OneHanded)
                    {
                        if (slot == 1)
                        {
                            if (_weapon1 != null) bag.SetItem(_weapon1);
                            _weapon1 = weapon;
                            bag.DeleteItem(item);
                            break;
                        }

                        if (slot == 2)
                        {
                            if (_weapon2 != null) bag.SetItem(_weapon2);
                            _weapon2 = weapon;
                            bag.DeleteItem(item);
                        }
                    }
                }

                break;
        }
    }
}