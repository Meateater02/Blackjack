namespace Blackjack;

public class Player : IPlayer
{
    public Scores Scores { get; }
    public List<Card>OnHand { get; }
    public bool IsStay { get; set; }

    public Player()
    {
        Scores = new Scores();
        OnHand = new List<Card>();
        IsStay = false;
    }

    public void AddCard(Card card)
    {
        OnHand.Add(card);
        Scores.AddScore(card);
    }
}