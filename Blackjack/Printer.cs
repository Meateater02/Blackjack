namespace Blackjack;

//prints the results
public class Printer
{
    private IWriter _writer;

    public Printer(IWriter writer)
    {
        _writer = writer;
    }

    public void PrintOnHand(List<Card> cards)
    {
        var onHandToString = "";
        
        foreach (var card in cards)
        {
            onHandToString += card;
        }

        _writer.Write("with the hand [" + onHandToString + "]\n\n");
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
    }

    public void PrintCardDrawn(Player player)
    {
        _writer.Write((player.IsDealer ? "Dealer draws " : "You draw ") + player.OnHand.Last() + "\n");
    }

    public void PrintGameEnd(Scoring scoringSystem)
    {
        switch (scoringSystem.WinLoseDraw())
        {
            case Winner.Player:
                _writer.WriteLine("You beat the dealer!");
                break;
            case Winner.Dealer:
                _writer.WriteLine("Dealer wins!");
                break;
            case Winner.Draw:
                _writer.WriteLine("Draw!");
                break;
        }
    }
}