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
    
    public void AdjustAceValue(List<Card> onHand)
    {
        if (onHand.Sum(card => card.Value) > 21)
        {
            var index = onHand.FindIndex(card => card.Value == 11);

            if (index != -1)
            { 
                onHand[index].Value = 1;
            }
        }
        
        TotalPoints = onHand.Sum(card => card.Value);
    }
}