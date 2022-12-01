using Blackjack;

namespace TestProject1;

public class PlayerTest
{
    [Fact]
    public void GivenPlayerTurn_WhenPlayerHits_ThenPlayerGetsNextCardOnDeck()
    {
        //arrange
        Dealer dealer = new Dealer();
        Player player = new Player();
        dealer.Deck.ShuffleDeck();
        var expectedCard = dealer.Deck.Cards[0];
        
        //act
        player.AddCard(dealer.DealCard());

        //assert
        Assert.Contains(expectedCard, player.OnHand);
        Assert.Single(player.OnHand);
    }
}