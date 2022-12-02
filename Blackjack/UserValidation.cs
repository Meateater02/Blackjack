namespace Blackjack;

public class UserValidation
{
    private IReader _reader;
    private IWriter _writer;

    public UserValidation(IReader reader, IWriter writer)
    {
        _reader = reader;
        _writer = writer;
    }

    public int PromptUserInputForOneOrZero()
    {
        _writer.Write("Hit or stay? (Hit = 1, Stay = 0) ");
        
        var readUserInput = _reader.ReadLine();

        int.TryParse(readUserInput, out var validInput);
        
        while ((!int.TryParse(readUserInput, out validInput)) || !(validInput is >= 0 and <= 1))
        {
            _writer.Write("Invalid input! Please try again: (Hit = 1, Stay = 0) ");
            readUserInput = _reader.ReadLine();
        }
        
        return validInput;
    }
}