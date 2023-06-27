using BossOfTheDungeons.Items.Enums;

namespace BossOfTheDungeons.Items.Base;

public class Weapon : Item
{
    public WeaponItemTypeEnum WeaponType { get; }
    
    public Weapon(string name, ItemTypeEnum type, WeaponItemTypeEnum weaponType) :base(name, type)
    {
        WeaponType = weaponType;
    }
}