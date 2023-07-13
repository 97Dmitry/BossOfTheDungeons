using System;
using BossOfTheDungeons.Items.Base;
using BossOfTheDungeons.Items.Enums;
using BossOfTheDungeons.Units.Characters.Structs;

namespace BossOfTheDungeons.Items.Utils.Generator;

public static class ItemGenerator
{
    private static readonly Random Random = new();

    public static Item Generate()
    {
        var itemTypes = Enum.GetValues(typeof(ItemTypeEnum));
        var itemType = (ItemTypeEnum)itemTypes.GetValue(Random.Next(itemTypes.Length));

        var itemPropertyTypes = Enum.GetValues(typeof(ItemPropertyType));
        var itemPropertyType =
            (ItemPropertyType)itemPropertyTypes.GetValue(Random.Next(itemPropertyTypes.Length));

        var itemRare = ItemRareGenerator.GetRandomItemRate();

        var itemPrice = itemRare switch
        {
            ItemRate.Common => Random.Next(1, 26),
            ItemRate.Magical => Random.Next(25, 76),
            ItemRate.Rare => Random.Next(75, 181),
            ItemRate.Legendary => Random.Next(300, 751),
            _ => 1
        };

        if (itemType == ItemTypeEnum.Weapon)
        {
            var weaponTypes = Enum.GetValues(typeof(WeaponItemTypeEnum));
            var weaponType = (WeaponItemTypeEnum)weaponTypes.GetValue(Random.Next(weaponTypes.Length));

            int physicalDamage;
            int magicalDamage;
            int chaosDamage;
            int attackSpeed;
            int castSpeed;
            int accuracy;

            switch (itemPropertyType)
            {
                case ItemPropertyType.Strength:
                    physicalDamage = Random.Next(1, 9);
                    magicalDamage = Random.Next(1, 3);
                    chaosDamage = Random.Next(1, 3);
                    attackSpeed = Random.Next(1, 6);
                    castSpeed = Random.Next(1, 3);
                    accuracy = Random.Next(1, 5);
                    break;
                case ItemPropertyType.Dexterity:
                    physicalDamage = Random.Next(1, 7);
                    magicalDamage = Random.Next(1, 3);
                    chaosDamage = Random.Next(1, 11);
                    attackSpeed = Random.Next(1, 9);
                    castSpeed = Random.Next(1, 3);
                    accuracy = Random.Next(1, 11);
                    break;
                case ItemPropertyType.Intelligence:
                    physicalDamage = Random.Next(1, 3);
                    magicalDamage = Random.Next(1, 16);
                    chaosDamage = Random.Next(1, 7);
                    attackSpeed = Random.Next(1, 5);
                    castSpeed = Random.Next(1, 11);
                    accuracy = Random.Next(1, 4);
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
                armor = Random.Next(1, 11);
                strength = new Strength(Random.Next(1, 19));
                dexterity = new Dexterity(Random.Next(1, 5));
                intelligence = new Intelligence(Random.Next(1, 3));
                health = Random.Next(1, 23);
                elementalResistance = Random.Next(1, 9);
                chaosResistance = Random.Next(1, 5);
                break;
            case ItemPropertyType.Dexterity:
                armor = Random.Next(1, 7);
                strength = new Strength(Random.Next(1, 9));
                dexterity = new Dexterity(Random.Next(1, 19));
                intelligence = new Intelligence(Random.Next(1, 5));
                health = Random.Next(1, 16);
                elementalResistance = Random.Next(1, 13);
                chaosResistance = Random.Next(1, 9);
                break;
            case ItemPropertyType.Intelligence:
                armor = Random.Next(1, 5);
                strength = new Strength(Random.Next(1, 7));
                dexterity = new Dexterity(Random.Next(1, 5));
                intelligence = new Intelligence(Random.Next(1, 23));
                health = Random.Next(1, 11);
                elementalResistance = Random.Next(1, 21);
                chaosResistance = Random.Next(1, 13);
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

        static string GenerateItemName(ItemTypeEnum itemType)
        {
            string[][] adjectives =
            {
                new[] { "Огненный", "Огненная", "Огненное", "Огненные" },
                new[] { "Ледяной", "Ледяная", "Ледяное", "Ледяные" },
                new[] { "Магический", "Магическая", "Магическое", "Магические" },
                new[] { "Священный", "Священная", "Священное", "Священные" },
                new[] { "Темный", "Темная", "Темное", "Темные" }
            };
            string noun;
            int gender; // 0 - masculine, 1 - feminine, 2 - neuter, 3 - plural

            switch (itemType)
            {
                case ItemTypeEnum.Helmet:
                    noun = "Шлем";
                    gender = 0;
                    break;
                case ItemTypeEnum.Gloves:
                    noun = "Перчатки";
                    gender = 3;
                    break;
                case ItemTypeEnum.Boots:
                    noun = "Ботинки";
                    gender = 3;
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
                    var index = Random.Next(weaponNouns.Length);
                    noun = weaponNouns[index][0];
                    gender = int.Parse(weaponNouns[index][1]);
                    break;
                default:
                    throw new InvalidOperationException("Invalid ItemTypeEnum enum value");
            }

            var adjective = adjectives[Random.Next(adjectives.Length)][gender];

            return $"{adjective} {noun}";
        }
    }
}