namespace Blackjack;

//controls the action of the dealer 
//keep hitting until the dealer reaches 17
//stop only when the dealer's score is above 17
public class Dealer
{
    public Action Action { get; set; }
    public Scores Points { get; set; }
    public List<Card>OnHand { get; set; }

    public Dealer()
    {
        Points = new Scores();
    }

    public void ChooseAction()
    {
        if (Points.Points >= 17)
        {
            Action.Hit();
        }
        else
        {
            Action.Stay();
        }
    }
}