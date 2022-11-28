namespace Blackjack;

//deals the card to both the player and the dealer
public class CardDealer
{
    public Deck Deck { get; }
    private int _index;

    public CardDealer()
    {
        Deck = new Deck();
        _index = -1;
    }

    public Card DealCard()
    {
        _index++;
        return Deck.Cards[_index];
    }
}