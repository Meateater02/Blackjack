using Blackjack;

namespace TestProject1;

public class ScoringTest
{
    [Theory]
    [InlineData(21, 18)] //player blackjack
    [InlineData(24, 14)] //player bust
    [InlineData(18, 21)] //dealer blackjack
    [InlineData(17, 25)] //dealer bust
    public void GivenGameHadProceeded_WhenEitherPlayerScoreIs21OrOver_ThenGameFinishes(int playerScore, int dealerScore)
    {
        //arrange
        var cardDealer = new CardDealer();
        var player = new Player(cardDealer);
        var dealer = new Player(cardDealer);
        var scoringSystem = new Scoring(player, dealer);

        player.Scores.TotalPoints = playerScore;
        dealer.Scores.TotalPoints = dealerScore;
        dealer.IsStay = true;

        //act
        if (player.Scores.TotalPoints >= 21 || dealer.Scores.TotalPoints >= 21)
        {
            scoringSystem.WinLoseDraw();
        }

        Assert.True(scoringSystem.IsGameEnd);
    }
    
    [Fact]
    public void GivenPlayerHasAceCardOnHand_WhenPlayerTotalPointsIsNotOver21_ThenAceValueShouldRemainAsEleven()
    {
        //arrange
        var player = new Player(new CardDealer());
        player.OnHand.Add(new Card(Suit.Club, Number.Ace));
        player.OnHand.Add(new Card(Suit.Club, Number.Nine));

        var scoringSystem = new Scoring(player, new Player(new CardDealer()));

        //act
        scoringSystem.DetermineAceValue(player);

        //assert
        Assert.Equal(11, player.OnHand[0].Value);
    }

    [Fact]
    public void GivenPlayerHasAceCardOnHand_WhenPlayerTotalPointsIsOver21_ThenAceValueIsOne()
    {
        //arrange
        var player = new Player(new CardDealer());
        player.OnHand.Add(new Card(Suit.Club, Number.Ace));
        player.OnHand.Add(new Card(Suit.Club, Number.King));
        player.OnHand.Add(new Card(Suit.Heart, Number.Jack));

        var scoringSystem = new Scoring(player, new Player(new CardDealer()));

        //act
        scoringSystem.DetermineAceValue(player);

        //assert
        Assert.Equal(1, player.OnHand[0].Value);
    }
}