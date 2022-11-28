using System.Transactions;

namespace Blackjack;

//controls the action of the dealer 
//keep hitting until the dealer reaches 17
//stop only when the dealer's score is above 17
public class Dealer 
{
    public Scores Scores { get; set; }
    public List<Card>OnHand { get; set; }
    public CardDealer CardDealer { get; }

    public Dealer(CardDealer cardDealer)
    {
        Scores = new Scores();
        OnHand = new List<Card>();
        CardDealer = cardDealer;
    }

    public void Start()
    {
        var card1 = CardDealer.DealCard();
        var card2 = CardDealer.DealCard();
        OnHand.Add(card1);
        OnHand.Add(card2);
        Scores.AddScore(card1);
        Scores.AddScore(card2);
    }

    public void ChooseAction()
    {
        if (Scores.TotalPoints < 17)
        {
            //choose hit
            var card = CardDealer.DealCard();
            OnHand.Add(card);
            Scores.AddScore(card);
        }
        else
        {
            //choose stay
        }
    }
}