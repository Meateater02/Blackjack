namespace Blackjack;

public class Deck : IDeck
{
    public List<Card> Cards { get; private set; }
    private IRandomiser _randomiser;

    public Deck(IRandomiser randomiser)
    {
        Cards = new List<Card>();
        InitialiseDeck();
        _randomiser = randomiser;
        ShuffleDeck();
    }

    private void InitialiseDeck()
    {
        foreach (Suit suit in Enum.GetValues(typeof(Suit)))
        {
            foreach (Number number in Enum.GetValues(typeof(Number)))
            {
                Cards.Add(new Card(suit, number));
            }
        }
    }

    private void ShuffleDeck()
    {
        Cards = Cards.OrderBy(_ => _randomiser.Next()).ToList();
    }
    
    public Card DealCard()
    {
        var drawnCard = Cards.First();
        Cards.Remove(drawnCard);
        return drawnCard;
    }
}