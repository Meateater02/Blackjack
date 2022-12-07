using Blackjack;

namespace TestProject1.Fake;

public class WriterFake : IWriter
{
    public List<string> Buffer { get; }

    public WriterFake()
    {
        Buffer = new List<string>();
    }
    
    public void WriteLine(string message)
    {
        Buffer.Add(message + "\n");
    }

    public void Write(string message)
    {
        Buffer.Add(message);
    }
}