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

    public void PrintOnHand(List<Card> onHand)
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

    public void PrintPointsStatus(int totalPoints, bool isDealer)
    {
        _writer.WriteLine("");
        if (totalPoints < 21)
        {
            _writer.WriteLine((isDealer ? "Dealer is" : "You are") + " currently at " + totalPoints);
        }
        else if (totalPoints == 21)
        {
            _writer.WriteLine((isDealer ? "Dealer has" : "You have") + " hit Blackjack!");
        }
        else
        {
            _writer.WriteLine((isDealer ? "Dealer is" : "You are") + " currently at Bust!");
        }
    }

    public void PrintCardDrawn(List<Card> playerHand, bool isDealer)
    {
        _writer.Write((isDealer ? "Dealer draws " : "You draw ") + playerHand.Last() + "\n");
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