namespace BossOfTheDungeons.Units.Characters.Structs;

public struct Intelligence
{
    private int _value;

    public Intelligence(int value)
    {
        _value = value;
    }

    public static implicit operator Intelligence(int value)
    {
        return new Intelligence(value);
    }

    public static implicit operator int(Intelligence intelligence)
    {
        return intelligence._value;
    }
}