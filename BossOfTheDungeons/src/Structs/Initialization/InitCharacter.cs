using BossOfTheDungeons.Units.Characters.Enums;

namespace BossOfTheDungeons.Structs.Initialization;

public struct InitCharacter
{
    public string Name { get; }
    public CharacterClassEnum Class { get; }

    public InitCharacter(string name, CharacterClassEnum Class)
    {
        Name = name;
        this.Class = Class;
    }
}