using Blackjack;

namespace TestProject1;

public class ScoringTest
{
    [Fact]
    public void GivenDealerTurn_WhenDealerHasNotStay_ThenGameContinues()
    {
        //arrange
        var player = new Player();
        var dealer = new Player();
        var scoringSystem = new Scoring(player, dealer);
        
        //act
        Winner actualWinner = scoringSystem.WinLoseDraw();
        
        //assert
        Assert.Equal(Winner.None, actualWinner);
        Assert.False(scoringSystem.IsGameEnd);
    }

    [Fact]
    public void GivenDealerStayed_WhenWinLoseDrawIsCalled_ThenGameEnds()
    {
        //arrange
        var player = new Player();
        var dealer = new Player()
        {
            IsDealer = true,
            IsStay = true
        };
        var scoringSystem = new Scoring(player, dealer);
        
        //act
        scoringSystem.WinLoseDraw();
        
        //assert
        Assert.True(scoringSystem.IsGameEnd);
    }
    
    [Theory]
    [InlineData(21, 18)] //player blackjack
    [InlineData(17, 25)] //dealer bust
    public void GivenDealerHasNotStayed_WhenPlayerScoreIsBlackJackOrDealerBust_ThenPlayerWins(int playerScore, int dealerScore)
    {
        //arrange
        var player = new Player();
        var dealer = new Player();
        var scoringSystem = new Scoring(player, dealer);

        player.Scores.TotalPoints = playerScore;
        dealer.Scores.TotalPoints = dealerScore;
        
        //act
        Winner actualWinner = scoringSystem.WinLoseDraw();

        //assert
        Assert.Equal(Winner.Player, actualWinner);
        Assert.True(scoringSystem.IsGameEnd);
    }
    
    [Theory]
    [InlineData(18, 21)] //dealer blackjack
    [InlineData(24, 14)] //player bust
    public void GivenDealerHasNotStayed_WhenDealerScoreIsBlackJackOrPlayerBust_ThenDealerWins(int playerScore, int dealerScore)
    {
        //arrange
        var player = new Player();
        var dealer = new Player();
        var scoringSystem = new Scoring(player, dealer);

        player.Scores.TotalPoints = playerScore;
        dealer.Scores.TotalPoints = dealerScore;
        
        //act
        Winner actualWinner = scoringSystem.WinLoseDraw();

        //assert
        Assert.Equal(Winner.Dealer, actualWinner);
        Assert.True(scoringSystem.IsGameEnd);
    }
    
    [Fact]
    public void GivenPlayerHasAceCardOnHand_WhenPlayerTotalPointsIsNotOver21_ThenAceValueShouldRemainAsEleven()
    {
        //arrange
        var player = new Player();
        player.OnHand.Add(new Card(Suit.Club, Number.Ace));
        player.OnHand.Add(new Card(Suit.Club, Number.Nine));

        var scoringSystem = new Scoring(player, new Player());

        //act
        scoringSystem.DetermineAceValue(player.OnHand);

        //assert
        Assert.Equal(11, player.OnHand[0].Value);
    }

    [Fact]
    public void GivenPlayerHasAceCardOnHand_WhenPlayerTotalPointsIsOver21_ThenAceValueIsOne()
    {
        //arrange
        var player = new Player();
        player.OnHand.Add(new Card(Suit.Club, Number.Ace));
        player.OnHand.Add(new Card(Suit.Club, Number.King));
        player.OnHand.Add(new Card(Suit.Heart, Number.Jack));

        var scoringSystem = new Scoring(player, new Player());

        //act
        scoringSystem.DetermineAceValue(player.OnHand);

        //assert
        Assert.Equal(1, player.OnHand[0].Value);
    }
}