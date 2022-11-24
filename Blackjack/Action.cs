namespace Blackjack;

public class Action
{
    public CardDealer CardDealer { get; }
    public Card Card { get; set;  }

    public Action()
    {
        CardDealer = new CardDealer();
    }
    public void Hit()
    {
        Card = CardDealer.DealCard();
        
    }

    public void Stay()
    {
        
    }
}