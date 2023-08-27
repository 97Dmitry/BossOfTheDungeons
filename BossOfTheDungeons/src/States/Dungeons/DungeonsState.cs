using System;
using System.Collections.Generic;
using BossOfTheDungeons.Dungeons.Base;
using BossOfTheDungeons.GUI;
using BossOfTheDungeons.Shopping.Base;
using BossOfTheDungeons.States.Base;
using BossOfTheDungeons.Units.Characters.Base;

namespace BossOfTheDungeons.States.Dungeons;

public class DungeonsState : State
{
    private readonly Dungeon _dungeon;
    private readonly Character _character;
    private readonly Shop _shop;

    public DungeonsState(Stack<State> states, Dungeon dungeon, Character character, Shop shop) : base(states)
    {
        _dungeon = dungeon;
        _character = character;
        _shop = shop;
    }

    public override void Update()
    {
        while (_dungeon.Enemies.Count > 0)
        {
            base.Update();
            Console.WriteLine($"Подземелье уровня {Dungeon.Level}\n");
            RenderUnitState();


            Console.Write("\nВыберите врага, которого хотите атаковать: ");
            var input = Console.ReadLine();

            if (int.TryParse(input, out var selectedEnemy))
            {
                Console.Write("\n");
                if (selectedEnemy > 0 && selectedEnemy <= _dungeon.Enemies.Count)
                {
                    selectedEnemy -= 1;
                    var receivedDamage = 0f;
                    var blockedDamage = 0f;

                    var characterDamageInfo = _character.Attack(_dungeon.Enemies[selectedEnemy]);
                    Console.WriteLine(
                        $"Вы нанесли {characterDamageInfo.FinalDamage} врагу {_dungeon.Enemies[selectedEnemy].Name}." +
                        $" Им было заблокировано {characterDamageInfo.PotentialDamage - characterDamageInfo.FinalDamage}\n");

                    var deadEnemies = _dungeon.CheckAndRemoveDeadEnemies();

                    if (_dungeon.Enemies.Count == 0)
                    {
                        Console.WriteLine(
                            $"Последний враг пал! Вы нанесли сокрушительный удар по {deadEnemies[0].Name}");
                        var loot = _dungeon.Win();
                        _character.TakeDungeonLoot(loot);
                        Console.WriteLine($"Ваша награда: {loot.Money} золота");
                        Console.ReadKey();
                        _shop.UpdateProducts();
                        break;
                    }

                    if (deadEnemies.Count > 0)
                        for (var i = 0; i < deadEnemies.Count; i++)
                            Console.WriteLine($"После вашей атаки погиб враг {deadEnemies[i].Name}\n");

                    for (var i = 0; i < _dungeon.Enemies.Count; i++)
                    {
                        var damageInfo = _dungeon.Enemies[i].Attack(_character);
                        receivedDamage += damageInfo.FinalDamage;
                        blockedDamage += damageInfo.PotentialDamage - damageInfo.FinalDamage;
                        Console.WriteLine(
                            $"Вы получили урона от врага {_dungeon.Enemies[i].Name}: {damageInfo.FinalDamage}." +
                            $" Заблокировано: {damageInfo.PotentialDamage - damageInfo.FinalDamage}");
                    }

                    Console.WriteLine($"Всего урона получено: {receivedDamage}. Заблокировано: {blockedDamage}");

                    Console.ReadKey();
                }
                else
                {
                    Console.WriteLine("Вы выбрали врага, которого нет\nНажмите кнопку, что бы продолжить");
                    Console.ReadKey();
                }
            }
            else
            {
                Console.WriteLine("Вы ввели неверные данные\nНажмите кнопку, что бы продолжить");
                Console.ReadKey();
            }
        }

        End = true;
    }

    private void RenderUnitState()
    {
        var enemies = new string[_dungeon.Enemies.Count];
        string[] character =
        {
            $"{_character.Name} Здоровье: {_character.Health}/{_character.FullHealth}"
        };

        for (var i = 0; i < _dungeon.Enemies.Count; i++)
            enemies[i] =
                $"{_dungeon.Enemies[i].Name} Здоровье: {_dungeon.Enemies[i].Health}/{_dungeon.Enemies[i].FullHealth}";

        Gui.RenderColumnsWithSpacing(enemies, character, 4);
    }
}