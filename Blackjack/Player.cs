namespace Blackjack;

//reads player's action and execute them
public class Player
{
    //public Action Action { get; set; }
    public Scores Points { get; set; }
    public List<Card>OnHand { get; set; }
    public CardDealer CardDealer { get; }

    public Player(CardDealer cardDealer)
    {
        Points = new Scores();
        OnHand = new List<Card>();
        CardDealer = cardDealer;
    }
    
    //actions
    public void Hit()
    {
        OnHand.Add(CardDealer.DealCard());
    }

    public void Stay()
    {
        
    }
}