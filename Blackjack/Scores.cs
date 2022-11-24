namespace Blackjack;

public class Scores
{
    public int Points { get; set; }

    public Scores()
    {
        Points = 0;
    }
    
    public void AddScore(Card card)
    {
        Points += card.Value;
    }

    
}