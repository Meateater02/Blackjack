using Blackjack;

namespace TestProject1;

public class PlayerTest
{
    [Fact]
    public void GivenGameJustStarted_WhenPlayerStarts_ThenPlayerOnHandShouldHaveTwoCards()
    {
        //arrange
        Player player = new Player(new CardDealer());
        
        //act
        player.Start();
        
        //assert
        Assert.Equal(2, player.OnHand.Count);
    }

    [Fact]
    public void GivenPlayerTurn_WhenPlayerHits_ThenPlayerGetsNextCardOnDeck()
    {
        //arrange
        CardDealer cardDealer = new CardDealer();
        Player player = new Player(cardDealer);
        cardDealer.Deck.ShuffleDeck();
        var expectedCard = cardDealer.Deck.Cards[0];
        
        //act
        player.Hit();

        //assert
        Assert.Contains(expectedCard, player.OnHand);
    }
}