namespace Blackjack;

//keeps track of the score
public class Scoring
{
    public Player Player { get; set; }
    public Dealer Dealer { get; set; }
    
    public Scoring(Player player, Dealer dealer)
    {
        Player = player;
        Dealer = dealer;
    }

    public void DetermineAceValue()
    {
        //if(Player.OnHand.Contains())
    }
}