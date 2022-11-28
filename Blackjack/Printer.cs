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
            Console.WriteLine(player.Dealer ? "Dealer is currently at " + player.Scores.TotalPoints : "You are currently at " + player.Scores.TotalPoints);
        }
        else if (player.Scores.TotalPoints == 21)
        {
            Console.WriteLine(player.Dealer ? "Dealer has hit Blackjack!" : "You have hit Blackjack!");
        }
        else
        {
            Console.WriteLine(player.Dealer ? "Dealer is currently at Bust!" : "You are currently at Bust!");
        }
        
        PrintOnHand(player.OnHand);
    }

    public void PrintCardDrawn(Player player)
    {
        Console.WriteLine(player.Dealer ? "Dealer draw " + player.OnHand.Last() : "You draw " + player.OnHand.Last());
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
                Console.WriteLine("Draw! ");
                break;
        }
        
        if (scoringSystem.WinLoseDraw() != -1)
            scoringSystem.GameEnd = true;
    }
    
}