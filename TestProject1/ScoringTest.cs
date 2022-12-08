using System.Runtime.InteropServices;
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
    [InlineData(Number.Jack, Number.Ace, Number.Five, Number.Ten, Number.Three)]
    [InlineData(Number.Queen, Number.Seven, Number.Six, Number.Ten, Number.Seven)]
    public void GivenDealerHasNotStayed_WhenPlayerScoreIsBlackJackOrDealerBust_ThenPlayerWins(Number playerNum1, Number playerNum2, Number dealerNum1, Number dealerNum2, Number dealerNum3)
    {
        //arrange
        var player = new Player();
        var dealer = new Player();
        var scoringSystem = new Scoring(player, dealer);

        player.AddCard(new Card(Suit.Club, playerNum1));
        player.AddCard(new Card(Suit.Diamond, playerNum2));
        dealer.AddCard(new Card(Suit.Heart, dealerNum1));
        dealer.AddCard(new Card(Suit.Spade, dealerNum2));
        dealer.AddCard(new Card(Suit.Spade, dealerNum3));
        
        //act
        Winner actualWinner = scoringSystem.WinLoseDraw();

        //assert
        Assert.Equal(Winner.Player, actualWinner);
        Assert.True(scoringSystem.IsGameEnd);
    }
    
    [Theory]
    [InlineData(Number.Eight, Number.Seven, Number.Three, Number.Ace, Number.King)]
    [InlineData(Number.King, Number.Queen, Number.Four, Number.Ten, Number.Four)]
    public void GivenDealerHasNotStayed_WhenDealerScoreIsBlackJackOrPlayerBust_ThenDealerWins(Number playerNum1, Number playerNum2, Number playerNum3, Number dealerNum1, Number dealerNum2)
    {
        //arrange
        var player = new Player();
        var dealer = new Player();
        var scoringSystem = new Scoring(player, dealer);

        player.AddCard(new Card(Suit.Club, playerNum1));
        player.AddCard(new Card(Suit.Diamond, playerNum2));
        player.AddCard(new Card(Suit.Diamond, playerNum3));
        dealer.AddCard(new Card(Suit.Heart, dealerNum1));
        dealer.AddCard(new Card(Suit.Spade, dealerNum2));
        
        //act
        Winner actualWinner = scoringSystem.WinLoseDraw();
    
        //assert
        Assert.Equal(Winner.Dealer, actualWinner);
        Assert.True(scoringSystem.IsGameEnd);
    }
}