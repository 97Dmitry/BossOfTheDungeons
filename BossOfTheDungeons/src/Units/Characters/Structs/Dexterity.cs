namespace BossOfTheDungeons.Units.Characters.Structs;

public struct Dexterity
{
    private int _value;

    public Dexterity(int value)
    {
        this._value = value;
    }

    public static implicit operator Dexterity(int value)
    {
        return new Dexterity(value);
    }

    public static implicit operator int(Dexterity dexterity)
    {
        return dexterity._value;
    }
}