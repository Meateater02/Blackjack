namespace Blackjack;

//deals the card to both the player and themselves
public class Dealer : IPlayer
{
    public Scores Scores { get; }
    public List<Card> OnHand { get; }
    public Deck Deck { get; }
    private int _index;

    public Dealer()
    {
        Scores = new Scores();
        OnHand = new List<Card>();
        Deck = new Deck();
        _index = -1;
    }

    public Card DealCard()
    {
        _index++;
        return Deck.Cards[_index];
    }

    public void Hit()
    {
        AddCard(DealCard());
    }

    public void AddCard(Card card)
    {
        OnHand.Add(card);
        Scores.AddScore(card);
    }
}