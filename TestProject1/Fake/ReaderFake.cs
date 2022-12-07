using Blackjack;

namespace TestProject1.Fake;

public class ReaderFake : IReader
{
    private List<string> _userInput;
    private int _index;

    public ReaderFake(List<string> input)
    {
        _userInput = input;
        _index = 0;
    }
    
    public string? ReadLine()
    {
        var currentInput = _userInput[_index];
        _index++;

        return currentInput;
    }
};