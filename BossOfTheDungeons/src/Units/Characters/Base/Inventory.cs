using System;
using System.Collections.Generic;
using BossOfTheDungeons.Items.Base;
using BossOfTheDungeons.Items.Enums;

namespace BossOfTheDungeons.Units.Characters.Base;

public class Inventory
{
    private Item? _helmet;
    private Item? _gloves;
    private Item? _boots;
    private Item? _armor;
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

        var armor = _armor != null ? $"{_armor.Name}" : "отсутствует";
        Console.WriteLine($"4. Броня {armor}");

        var belt = _belt != null ? $"{_belt.Name}" : "отсутствует";
        Console.WriteLine($"5. Пояс {belt}");

        var ring1 = _ring1 != null ? $"{_ring1.Name}" : "отсутствует";
        Console.WriteLine($"6. Кольцо 1 {ring1}");

        var ring2 = _ring2 != null ? $"{_ring2.Name}" : "отсутствует";
        Console.WriteLine($"7. Кольцо 2 {ring2}");

        var amulet = _amulet != null ? $"{_amulet.Name}" : "отсутствует";
        Console.WriteLine($"8. Амулет {amulet}");

        var weapon1 = _weapon1 != null ? $"{_weapon1.Name}" : "отсутствует";
        Console.WriteLine($"9. Оружие 1 {weapon1}");

        var weapon2 = _weapon2 != null ? $"{_weapon2.Name}" : "отсутствует";
        Console.WriteLine($"0. Оружие 2 {weapon2}");
    }

    public void SetItem(Item item, Bag bag, int? slot = 1, Action<int>? callback = null)
    {
        switch (item.Type)
        {
            case ItemTypeEnum.Helmet:
                SetItem(item, _helmet, bag, callback);
                _helmet = item;
                break;
            case ItemTypeEnum.Gloves:
                SetItem(item, _gloves, bag, callback);
                _gloves = item;
                break;
            case ItemTypeEnum.Boots:
                SetItem(item, _boots, bag, callback);
                _boots = item;
                break;
            case ItemTypeEnum.Armor:
                SetItem(item, _armor, bag, callback);
                _armor = item;
                break;
            case ItemTypeEnum.Belt:
                SetItem(item, _belt, bag, callback);
                _belt = item;
                break;
            case ItemTypeEnum.Ring:
                if (slot == 1)
                {
                    SetItem(item, _ring1, bag, callback);
                    _ring1 = item;
                    break;
                }

                if (slot == 2)
                {
                    SetItem(item, _ring2, bag, callback);
                    _ring2 = item;
                }

                break;
            case ItemTypeEnum.Amulet:
                SetItem(item, _amulet, bag, callback);
                _amulet = item;
                break;
            case ItemTypeEnum.Weapon:
                if (item is Weapon weapon) SetWeapon(weapon, bag, slot);

                break;
        }
    }

    private void SetItem(Item newItem, Item? currentItem, Bag bag, Action<int>? callback = null)
    {
        if (currentItem != null)
        {
            callback?.Invoke(currentItem.Health);
            bag.SetItem(currentItem);
        }

        bag.DeleteItem(newItem);
    }

    private void SetWeapon(Weapon weapon, Bag bag, int? slot = 1)
    {
        if (weapon.WeaponType == WeaponItemTypeEnum.TwoHanded)
        {
            if (_weapon1 != null) bag.SetItem(_weapon1);
            if (_weapon2 != null) bag.SetItem(_weapon2);
            _weapon1 = weapon;
            _weapon2 = null;
            bag.DeleteItem(weapon);
        }
        else if (weapon.WeaponType == WeaponItemTypeEnum.Shield)
        {
            if (_weapon2 != null) bag.SetItem(_weapon2);
            _weapon2 = weapon;
            bag.DeleteItem(weapon);
        }
        else if (weapon.WeaponType == WeaponItemTypeEnum.OneHanded)
        {
            switch (slot)
            {
                case 1:
                {
                    if (_weapon1 != null) bag.SetItem(_weapon1);
                    _weapon1 = weapon;
                    bag.DeleteItem(weapon);
                    break;
                }
                case 2:
                {
                    if (_weapon2 != null) bag.SetItem(_weapon2);
                    _weapon2 = weapon;
                    bag.DeleteItem(weapon);
                    break;
                }
            }
        }
    }


    public Item[] GetArmorItemsLit()
    {
        var items = new List<Item>();
        if (_helmet != null) items.Add(_helmet);
        if (_gloves != null) items.Add(_gloves);
        if (_boots != null) items.Add(_boots);
        if (_armor != null) items.Add(_armor);
        if (_belt != null) items.Add(_belt);
        if (_ring1 != null) items.Add(_ring1);
        if (_ring2 != null) items.Add(_ring2);
        if (_amulet != null) items.Add(_amulet);

        return items.ToArray();
    }

    public Weapon[] GetWeaponItemsList()
    {
        var weapons = new List<Weapon>();
        if (_weapon1 != null) weapons.Add(_weapon1);
        if (_weapon2 != null) weapons.Add(_weapon2);

        return weapons.ToArray();
    }
}