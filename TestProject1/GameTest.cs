using Blackjack;

namespace TestProject1;

public class GameTest
{
    [Fact]
    public void GivenDealersPointsAreBelow17_WhenDealersTurn_ThenDealerHitAutomatically()
    {
        //arrange
        var cardDealer = new CardDealer();
        var game = new Game(cardDealer);
        var dealer = new Player(cardDealer);

        dealer.Scores.TotalPoints = 15;
        
        //act
        game.DealerAction(dealer);
        
        //assert
        Assert.Single(dealer.OnHand);
    }
    
    [Fact]
    public void GivenDealersPointsAreAbove17_WhenDealersTurn_ThenDealerAutomaticallyStay()
    {
        //arrange
        var cardDealer = new CardDealer();
        var game = new Game(cardDealer);
        var dealer = new Player(cardDealer)
        {
            Scores =
            {
                TotalPoints = 18
            }
        };

        //act
        game.DealerAction(dealer);
        
        //assert
        Assert.Empty(dealer.OnHand);
    }
}