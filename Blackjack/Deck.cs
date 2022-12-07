namespace Blackjack;

public class Deck
{
    public List<Card> Cards { get; private set; }
    private int _index;
    private IRandomiser _randomiser;

    public Deck(IRandomiser randomiser)
    {
        Cards = new List<Card>();
        _index = -1;
        InitialiseDeck();
        _randomiser = randomiser;
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

    public void ShuffleDeck()
    {
        Cards = Cards.OrderBy(_ => _randomiser.Next()).ToList();
    }
    
    public Card DealCard()
    {
        _index++;
        return Cards[_index];
    }
}