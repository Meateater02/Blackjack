namespace Blackjack;

public class Deck
{
    public List<Card> Cards { get; private set; }

    public Deck()
    {
        Cards = new List<Card>();
        InitialiseDeck();
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
        Random rand = new Random();
        Cards = Cards.OrderBy(_ => rand.Next()).ToList();
    }
}