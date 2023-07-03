namespace BossOfTheDungeons;

internal class Program
{
    public static void Main(string[] args)
    {
        var game = new Game();
        game.Init();
        game.Run();
    }
}