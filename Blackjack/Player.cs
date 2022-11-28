namespace Blackjack;

//reads player's action and execute them
public class Player
{
    public Scores Scores { get; set; }
    public List<Card>OnHand { get; set; }
    public CardDealer CardDealer { get; }
    public bool Dealer { get; set; }
    public bool Stay { get; set; }

    public Player(CardDealer cardDealer)
    {
        Scores = new Scores();
        OnHand = new List<Card>();
        CardDealer = cardDealer;
        Dealer = false;
        Stay = false;
    }
    
    public void Start()
    {
        Hit();
        Hit();
    }
    
    //actions
    public void Hit()
    {
        var card = CardDealer.DealCard();
        OnHand.Add(card);
        Scores.AddScore(card);
    }

    // public void Stay()
    // {
    //     
    // }
}