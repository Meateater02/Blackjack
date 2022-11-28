namespace Blackjack;

//keeps track of the score
public class Scoring
{
    public Player Player { get; set; }
    public Player Dealer { get; set; }
    public bool GameEnd { get; set; }
    
    public Scoring(Player player, Player dealer)
    {
        Player = player;
        Dealer = dealer;
        GameEnd = false;
    }

    public int WinLoseDraw()
    {
        var gameEnd = -1; 
        //-1 = game continues
        //0 = draw
        //1 = player wins
        //2 = dealer wins

        if ((Player.Scores.TotalPoints > Dealer.Scores.TotalPoints && Player.Scores.TotalPoints <= 21) || Dealer.Scores.TotalPoints > 21)
            gameEnd = 1;
        else if ((Dealer.Scores.TotalPoints > Player.Scores.TotalPoints && Dealer.Scores.TotalPoints <= 21) || Player.Scores.TotalPoints > 21)
            gameEnd = 2;
        else if ((Dealer.Scores.TotalPoints == Player.Scores.TotalPoints) && Dealer.Scores.TotalPoints <= 21)
            gameEnd = 0;

        // if (gameEnd != -1)
        //     GameEnd = true;

        return gameEnd;
    }

    public void DetermineAceValue(Player player)
    {
        if (player.OnHand.Sum(card => card.Value) > 21)
        {
            var index = player.OnHand.FindIndex(card => card.Value == 11);

            if (index != -1)
            {
                player.OnHand[index].Value = 1;
                player.Scores.TotalPoints = player.OnHand.Sum(card => card.Value);
            }
        }
    }
}