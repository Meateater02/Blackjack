namespace Blackjack;

//reads player's action and execute them
public class Player
{
    public Scores Scores { get; }
    public List<Card>OnHand { get; }
    private CardDealer CardDealer { get; }
    public bool IsDealer { get; set; }
    public bool IsStay { get; set; }

    public Player(CardDealer cardDealer)
    {
        Scores = new Scores();
        OnHand = new List<Card>();
        CardDealer = cardDealer;
        IsDealer = false;
        IsStay = false;
    }
    
    public void Start()
    {
        Hit();
        Hit();
    }
    
    public void Hit()
    {
        var card = CardDealer.DealCard();
        OnHand.Add(card);
        Scores.AddScore(card);
    }
}