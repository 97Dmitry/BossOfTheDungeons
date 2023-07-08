using BossOfTheDungeons.Items.Enums;

namespace BossOfTheDungeons.Items.Base;

public class Weapon : Item
{
    public WeaponItemTypeEnum WeaponType { get; }
    public int PhysicalDamage { get; }
    public int MagicalDamage { get; }
    public int ChaosDamage { get; }
    public int AttackSpeed { get; }
    public int CastSpeed { get; }
    public int Accuracy { get; }

    public Weapon(
        string name,
        ItemTypeEnum type,
        WeaponItemTypeEnum weaponType,
        ItemRate itemRate,
        int price,
        int physicalDamage,
        int magicalDamage,
        int chaosDamage,
        int attackSpeed,
        int castSpeed,
        int accuracy
    ) : base(name, type, price, itemRate)
    {
        WeaponType = weaponType;
        PhysicalDamage = physicalDamage;
        MagicalDamage = magicalDamage;
        ChaosDamage = chaosDamage;
        AttackSpeed = attackSpeed;
        CastSpeed = castSpeed;
        Accuracy = accuracy;
    }
}