namespace Blackjack;

//keeps track of the score
public class Scoring
{
    private readonly Player _player;
    private readonly Player _dealer;
    public bool IsGameEnd { get; private set; }
    
    public Scoring(Player player, Player dealer)
    {
        _player = player;
        _dealer = dealer;
        IsGameEnd = false;
    }

    public Winner WinLoseDraw()
    {
        var gameEnd = Winner.None;

        if ((_player.Scores.TotalPoints > _dealer.Scores.TotalPoints && _player.Scores.TotalPoints <= 21) || _dealer.Scores.TotalPoints > 21)
            gameEnd = Winner.Player;
        else if ((_dealer.Scores.TotalPoints > _player.Scores.TotalPoints && _dealer.Scores.TotalPoints <= 21) || _player.Scores.TotalPoints > 21)
            gameEnd = Winner.Dealer;
        else if ((_dealer.Scores.TotalPoints == _player.Scores.TotalPoints))
            gameEnd = Winner.Draw;
        
        if(gameEnd != Winner.None)
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