using BossOfTheDungeons.Items.Base;
using BossOfTheDungeons.Items.Enums;
using BossOfTheDungeons.Units.Characters.Structs;
using System;

namespace BossOfTheDungeons.Items.Generator;

public static class GenerateItem
{
    public static Item Generate()
    {
        var itemTypes = Enum.GetValues(typeof(ItemTypeEnum));
        var itemType = (ItemTypeEnum)itemTypes.GetValue(new Random().Next(itemTypes.Length));

        var itemPropertyTypes = Enum.GetValues(typeof(ItemPropertyType));
        var itemPropertyType =
            (ItemPropertyType)itemPropertyTypes.GetValue(new Random().Next(itemPropertyTypes.Length));

        var itemRare = GenerateItemRare.GetRandomItemRate();

        var itemPrice = itemRare switch
        {
            ItemRate.Common => new Random().Next(1, 26),
            ItemRate.Magical => new Random().Next(25, 76),
            ItemRate.Rare => new Random().Next(75, 181),
            ItemRate.Legendary => new Random().Next(300, 751),
            _ => 1
        };

        if (itemType == ItemTypeEnum.Weapon)
        {
            var weaponTypes = Enum.GetValues(typeof(WeaponItemTypeEnum));
            var weaponType = (WeaponItemTypeEnum)weaponTypes.GetValue(new Random().Next(weaponTypes.Length));

            int physicalDamage;
            int magicalDamage;
            int chaosDamage;
            int attackSpeed;
            int castSpeed;
            int accuracy;

            switch (itemPropertyType)
            {
                case ItemPropertyType.Strength:
                    physicalDamage = new Random().Next(1, 9);
                    magicalDamage = new Random().Next(1, 3);
                    chaosDamage = new Random().Next(1, 3);
                    attackSpeed = new Random().Next(1, 6);
                    castSpeed = new Random().Next(1, 3);
                    accuracy = new Random().Next(1, 5);
                    break;
                case ItemPropertyType.Dexterity:
                    physicalDamage = new Random().Next(1, 7);
                    magicalDamage = new Random().Next(1, 3);
                    chaosDamage = new Random().Next(1, 11);
                    attackSpeed = new Random().Next(1, 9);
                    castSpeed = new Random().Next(1, 3);
                    accuracy = new Random().Next(1, 11);
                    break;
                case ItemPropertyType.Intelligence:
                    physicalDamage = new Random().Next(1, 3);
                    magicalDamage = new Random().Next(1, 16);
                    chaosDamage = new Random().Next(1, 7);
                    attackSpeed = new Random().Next(1, 5);
                    castSpeed = new Random().Next(1, 11);
                    accuracy = new Random().Next(1, 4);
                    break;
                default:
                    throw new InvalidOperationException("Invalid ItemPropertyType enum value");
            }

            var weapon = new Weapon(
                GenerateItemName(itemType),
                itemType, weaponType,
                itemRare,
                itemPrice,
                physicalDamage,
                magicalDamage,
                chaosDamage,
                attackSpeed,
                castSpeed,
                accuracy
            );
            return weapon;
        }
        else
        {
            int armor;
            Strength strength;
            Dexterity dexterity;
            Intelligence intelligence;
            int health;
            int elementalResistance;
            int chaosResistance;

            switch (itemPropertyType)
            {
                case ItemPropertyType.Strength:
                    armor = new Random().Next(1, 11);
                    strength = new Strength(new Random().Next(1, 19));
                    dexterity = new Dexterity(new Random().Next(1, 5));
                    intelligence = new Intelligence(new Random().Next(1, 3));
                    health = new Random().Next(1, 23);
                    elementalResistance = new Random().Next(1, 9);
                    chaosResistance = new Random().Next(1, 5);
                    break;
                case ItemPropertyType.Dexterity:
                    armor = new Random().Next(1, 7);
                    strength = new Strength(new Random().Next(1, 9));
                    dexterity = new Dexterity(new Random().Next(1, 19));
                    intelligence = new Intelligence(new Random().Next(1, 5));
                    health = new Random().Next(1, 16);
                    elementalResistance = new Random().Next(1, 13);
                    chaosResistance = new Random().Next(1, 9);
                    break;
                case ItemPropertyType.Intelligence:
                    armor = new Random().Next(1, 5);
                    strength = new Strength(new Random().Next(1, 7));
                    dexterity = new Dexterity(new Random().Next(1, 5));
                    intelligence = new Intelligence(new Random().Next(1, 23));
                    health = new Random().Next(1, 11);
                    elementalResistance = new Random().Next(1, 21);
                    chaosResistance = new Random().Next(1, 13);
                    break;
                default:
                    throw new InvalidOperationException("Invalid ItemPropertyType enum value");
            }

            var item = new Item(
                GenerateItemName(itemType),
                itemType,
                itemPrice,
                itemRare,
                armor,
                strength,
                dexterity,
                intelligence,
                health,
                elementalResistance,
                chaosResistance,
                itemPropertyType
            );
            return item;
        }

        static string GenerateItemName(ItemTypeEnum itemType)
        {
            string[][] adjectives =
            {
                new[] { "Огненный", "Огненная", "Огненное" },
                new[] { "Ледяной", "Ледяная", "Ледяное" },
                new[] { "Магический", "Магическая", "Магическое" },
                new[] { "Священный", "Священная", "Священное" },
                new[] { "Темный", "Темная", "Темное" }
            };
            string noun;
            int gender; // 0 - masculine, 1 - feminine, 2 - neuter

            switch (itemType)
            {
                case ItemTypeEnum.Helmet:
                    noun = "Шлем";
                    gender = 0;
                    break;
                case ItemTypeEnum.Gloves:
                    noun = "Перчатки";
                    gender = 1;
                    break;
                case ItemTypeEnum.Boots:
                    noun = "Ботинки";
                    gender = 1;
                    break;
                case ItemTypeEnum.Armor:
                    noun = "Броня";
                    gender = 1;
                    break;
                case ItemTypeEnum.Belt:
                    noun = "Пояс";
                    gender = 0;
                    break;
                case ItemTypeEnum.Ring:
                    noun = "Кольцо";
                    gender = 2;
                    break;
                case ItemTypeEnum.Amulet:
                    noun = "Ожерелье";
                    gender = 2;
                    break;
                case ItemTypeEnum.Weapon:
                    string[][] weaponNouns =
                    {
                        new[] { "Меч", "0" },
                        new[] { "Топор", "0" },
                        new[] { "Копье", "2" },
                        new[] { "Посох", "0" },
                        new[] { "Лук", "0" }
                    };
                    var index = new Random().Next(weaponNouns.Length);
                    noun = weaponNouns[index][0];
                    gender = int.Parse(weaponNouns[index][1]);
                    break;
                default:
                    throw new InvalidOperationException("Invalid ItemTypeEnum enum value");
            }

            var adjective = adjectives[new Random().Next(adjectives.Length)][gender];

            return $"{adjective} {noun}";
        }
    }
}