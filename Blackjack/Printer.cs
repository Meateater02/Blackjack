namespace Blackjack;

//prints the results
public class Printer
{
    public string PrintOnHand(List<Card> onHand)
    {
        var onHandToString = "";
        
        foreach (var card in onHand)
        {
            onHandToString += card.ToString();
        }

        return onHandToString;
    }
    
}