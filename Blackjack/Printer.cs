namespace Blackjack;

//prints the results
public class Printer
{
    private IWriter _writer;

    public Printer(IWriter writer)
    {
        this._writer = writer;
    }

    public void PrintInvalidUserInput()
    {
        _writer.Write("Invalid input! Please try again: ");
    }

    private void PrintOnHand(List<Card> onHand)
    {
        var onHandToString = "";
        
        foreach (var card in onHand)
        {
            onHandToString += card;
        }

        _writer.Write("with the hand [" + onHandToString + "]\n\n");
    }

    public void PrintOption()
    {
        _writer.Write("Hit or stay? (Hit = 1, Stay = 0)");
    }

    public void PrintPointsStatus(Player player)
    {
        _writer.WriteLine("");
        if (player.Scores.TotalPoints < 21)
        {
            _writer.WriteLine((player.IsDealer ? "Dealer is" : "You are") + " currently at " + player.Scores.TotalPoints);
        }
        else if (player.Scores.TotalPoints == 21)
        {
            _writer.WriteLine((player.IsDealer ? "Dealer has" : "You have") + " hit Blackjack!");
        }
        else
        {
            _writer.WriteLine((player.IsDealer ? "Dealer is" : "You are") + " currently at Bust!");
        }
        
        PrintOnHand(player.OnHand);
    }

    public void PrintCardDrawn(Player player)
    {
        _writer.Write((player.IsDealer ? "Dealer draws " : "You draw ") + player.OnHand.Last() + "\n\n");
    }

    public void PrintGameEnd(Scoring scoringSystem)
    {
        switch (scoringSystem.WinLoseDraw())
        {
            case 1:
                _writer.WriteLine("You beat the dealer!");
                break;
            case 2:
                _writer.WriteLine("Dealer wins!");
                break;
            case 0:
                _writer.WriteLine("Draw!");
                break;
        }
    }
}