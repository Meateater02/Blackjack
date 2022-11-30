namespace Blackjack;

public class Reader
{
    private readonly IReader _reader;

    public Reader(IReader reader)
    {
        _reader = reader;
    }

    public int ReadValidInt()
    {
        var printer = new Printer(new ConsoleWriter());
        var readUserInput = _reader.ReadLine();
        int userInput;
        
        while (!int.TryParse(readUserInput, out userInput))
        {
            printer.PrintInvalidUserInput();
            readUserInput = _reader.ReadLine();
        }
        
        return userInput;
    }
}