namespace Blackjack;

public class ConsoleReader : IReader
{
    public string? ReadLine()
    {
        return Console.ReadLine();
    }
}