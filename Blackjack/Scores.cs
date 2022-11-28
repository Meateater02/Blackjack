namespace Blackjack;

public class Scores
{
    public int TotalPoints { get; set; }

    public Scores()
    {
        TotalPoints = 0;
    }
    
    public void AddScore(Card card)
    {
        TotalPoints += card.Value;
    }
}