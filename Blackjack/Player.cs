namespace Blackjack;

public class Player
{
    public Scores Scores { get; }
    public List<Card>OnHand { get; }
    public bool IsStay { get; set; }
    public bool IsDealer { get; set; }

    public Player()
    {
        Scores = new Scores();
        OnHand = new List<Card>();
        IsStay = false;
        IsDealer = false;
    }

    public void AddCard(Card card)
    {
        OnHand.Add(card);
        Scores.AddScore(card);
    }

    public void UpdateHandValue()
    {
        Scores.AdjustAceValue(OnHand);
    }
}