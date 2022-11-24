namespace Blackjack;

//reads player's action and execute them
public class Player
{
    //public Action Action { get; set; }
    public Scores Points { get; set; }
    public List<Card>OnHand { get; set; }
    public CardDealer CardDealer { get; }

    public Player()
    {
        Points = new Scores();
        OnHand = new List<Card>();
        CardDealer = new CardDealer();
    }
    
    //actions
    public void Hit()
    {
        var newCard = CardDealer.DealCard();
        OnHand.Add(newCard);
    }

    public void Stay()
    {
        
    }
}