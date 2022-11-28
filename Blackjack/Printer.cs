namespace Blackjack;

//prints the results
public class Printer
{
    private void PrintOnHand(List<Card> onHand)
    {
        var onHandToString = "";
        
        foreach (var card in onHand)
        {
            onHandToString += card.ToString();
        }

        Console.WriteLine("with the hand [" + onHandToString + "]");
        Console.Write("\n");
    }

    public void PrintOption()
    {
        Console.Write("Hit or stay? (Hit = 1, Stay = 0)");
    }

    public void PrintPointsStatus(Player player)
    {
        if (player.Scores.TotalPoints < 21)
        {
            Console.WriteLine((player.IsDealer ? "Dealer is" : "You are") + " currently at " + player.Scores.TotalPoints);
        }
        else if (player.Scores.TotalPoints == 21)
        {
            Console.WriteLine((player.IsDealer ? "Dealer has" : "You have") + " hit Blackjack!");
        }
        else
        {
            Console.WriteLine((player.IsDealer ? "Dealer is" : "You are") + " currently at Bust!");
        }
        
        PrintOnHand(player.OnHand);
    }

    public void PrintCardDrawn(Player player)
    {
        Console.WriteLine((player.IsDealer ? "Dealer" : "You") + " draw " + player.OnHand.Last());
    }

    public void PrintGameEnd(Scoring scoringSystem)
    {
        switch (scoringSystem.WinLoseDraw())
        {
            case 1:
                Console.WriteLine("You beat the dealer!");
                break;
            case 2:
                Console.WriteLine("Dealer wins!");
                break;
            case 0:
                Console.WriteLine("Draw!");
                break;
        }
    }
}