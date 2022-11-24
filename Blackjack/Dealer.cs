namespace Blackjack;

//controls the action of the dealer 
//keep hitting until the dealer reaches 17
//stop only when the dealer's score is above 17
public class Dealer
{
    //public Action Action { get; set; }
    public Scores Points { get; set; }
    public List<Card>OnHand { get; set; }
    public CardDealer CardDealer { get; }

    public Dealer(CardDealer cardDealer)
    {
        Points = new Scores();
        OnHand = new List<Card>();
        CardDealer = cardDealer;
    }

    public void ChooseAction()
    {
        if (Points.Points >= 17)
        {
            //Action.Hit();
            OnHand.Add(CardDealer.DealCard());
        }
        else
        {
            //Action.Stay();
        }
    }
}