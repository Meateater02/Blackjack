namespace Blackjack;

//deals the card to both the player and the dealer
public class CardDealer
{
    private Deck Deck { get; }
    //public Player Player { get; set; }
    //public Dealer Dealer { get; set; }

    public CardDealer()
    {
        Deck = new Deck();
    }

    public Card DealCard()
    {
        Random random = new Random();
        int index = random.Next(Deck.Cards.Count) - 1;

        return Deck.Cards[index];
    }

    // public List<Card> StartGame()
    // {
    //     List<Card> TwoCards = new List<Card>();
    //     TwoCards.Add(DealCard());
    //     TwoCards.Add(DealCard());
    //
    //     return TwoCards;
    // }
}