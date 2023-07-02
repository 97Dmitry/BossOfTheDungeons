using BossOfTheDungeons.Items.Enums;

namespace BossOfTheDungeons.Items.Base;

public class Weapon : Item
{
    public WeaponItemTypeEnum WeaponType { get; }
    
    public Weapon(
        string name,
        ItemTypeEnum type,
        WeaponItemTypeEnum weaponType,
        int price
        ) :base(name, type, price)
    {
        WeaponType = weaponType;
    }
}