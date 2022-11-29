namespace Blackjack;

//prints the results
public class Printer
{
    private IWriter writer;

    public Printer(IWriter writer)
    {
        this.writer = writer;
    }

    public void PrintInvalidUserInput()
    {
        writer.WriteLine("Invalid input! Please try again: ");
    }

    private void PrintOnHand(List<Card> onHand)
    {
        var onHandToString = "";
        //var cardToString = "";
        
        foreach (var card in onHand)
        {
            // switch (card.Number)
            // {
            //     case Number.Ace:
            //     case Number.Jack:
            //     case Number.Queen:
            //     case Number.King:
            //         cardToString = "[\'" + card.Number.ToString().ToUpper() + "\', " + "\'" + card.Suit.ToString().ToUpper() + "\']";
            //         break;
            //     default:
            //         cardToString = "[" + card.Value + ", " + "\'" + card.Suit.ToString().ToUpper() + "\']";
            //         break;
            // }
            onHandToString += card.ToString();
        }

        writer.WriteLine("with the hand [" + onHandToString + "]");
        writer.WriteLine("");
    }

    public void PrintOption()
    {
        writer.WriteLine("Hit or stay? (Hit = 1, Stay = 0)");
    }

    public void PrintPointsStatus(Player player)
    {
        if (player.Scores.TotalPoints < 21)
        {
            writer.WriteLine((player.IsDealer ? "Dealer is" : "You are") + " currently at " + player.Scores.TotalPoints);
        }
        else if (player.Scores.TotalPoints == 21)
        {
            writer.WriteLine((player.IsDealer ? "Dealer has" : "You have") + " hit Blackjack!");
        }
        else
        {
            writer.WriteLine((player.IsDealer ? "Dealer is" : "You are") + " currently at Bust!");
        }
        
        PrintOnHand(player.OnHand);
    }

    public void PrintCardDrawn(Player player)
    {
        writer.WriteLine((player.IsDealer ? "Dealer" : "You") + " draw " + player.OnHand.Last());
    }

    public void PrintGameEnd(Scoring scoringSystem)
    {
        switch (scoringSystem.WinLoseDraw())
        {
            case 1:
                writer.WriteLine("You beat the dealer!");
                break;
            case 2:
                writer.WriteLine("Dealer wins!");
                break;
            case 0:
                writer.WriteLine("Draw!");
                break;
        }
    }
}