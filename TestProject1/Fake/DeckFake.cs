using Blackjack;

namespace TestProject1.Fake;

public class DeckFake : IDeck
{
    public List<Card> Cards { get; set; }

    public DeckFake()
    {
        Cards = new List<Card>();
    }
    
    public Card DealCard()
    {
        var drawnCard = Cards.First();
        Cards.Remove(drawnCard);
        return drawnCard;
    }
}