namespace BossOfTheDungeons.Units.Characters.Structs;

public struct Strength
{
    private int _value;

    public Strength(int value)
    {
        this._value = value;
    }

    public static implicit operator Strength(int value)
    {
        return new Strength(value);
    }

    public static implicit operator int(Strength strength)
    {
        return strength._value;
    }
}