namespace Blackjack;

//keeps track of the score
public class Scoring
{
    private readonly Player _player;
    private readonly Dealer _dealer;
    public bool IsGameEnd { get; private set; }
    
    public Scoring(Player player, Dealer dealer)
    {
        _player = player;
        _dealer = dealer;
        IsGameEnd = false;
    }

    public int WinLoseDraw()
    {
        var gameEnd = -1; 
        //where gameEnd:
        //-1 = game continues
        //0 = draw
        //1 = player wins
        //2 = dealer wins

        if ((_player.Scores.TotalPoints > _dealer.Scores.TotalPoints && _player.Scores.TotalPoints <= 21) || _dealer.Scores.TotalPoints > 21)
            gameEnd = 1;
        else if ((_dealer.Scores.TotalPoints > _player.Scores.TotalPoints && _dealer.Scores.TotalPoints <= 21) || _player.Scores.TotalPoints > 21)
            gameEnd = 2;
        else if ((_dealer.Scores.TotalPoints == _player.Scores.TotalPoints) && _dealer.Scores.TotalPoints <= 21)
            gameEnd = 0;

        if (gameEnd != -1)
            IsGameEnd = true;

        return gameEnd;
    }

    public int DetermineAceValue(List<Card> onHand)
    {
        if (onHand.Sum(card => card.Value) > 21)
        {
            var index = onHand.FindIndex(card => card.Value == 11);

            if (index != -1)
            { 
                onHand[index].Value = 1;
            }
        }
        
        return onHand.Sum(card => card.Value);
    }
}