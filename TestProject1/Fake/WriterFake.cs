using Blackjack;

namespace TestProject1.Fake;

public class WriterFake : IWriter
{
    public List<string> buffer { get; }

    public WriterFake()
    {
        buffer = new List<string>();
    }
    
    public void WriteLine(string message)
    {
        buffer.Add(message + "\n");
    }

    public void Write(string message)
    {
        buffer.Add(message);
    }
}