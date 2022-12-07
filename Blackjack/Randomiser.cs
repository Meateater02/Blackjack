namespace Blackjack;

public class Randomiser : IRandomiser
{
    public int Next()
    {
        Random rand = new Random();
        
        return rand.Next();
    }
}