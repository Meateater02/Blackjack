using Blackjack;

namespace TestProject1;

public class PlayerTest
{
    [Fact]
    public void GivenPlayerTurn_WhenPlayerHits_ThenPlayerGetsNextCardOnDeck()
    {
        //arrange
        Player player = new Player();
        Deck deck = new Deck();
        deck.ShuffleDeck();
        var expectedCard = deck.Cards[0];
        
        //act
        player.AddCard(deck.DealCard());

        //assert
        Assert.Contains(expectedCard, player.OnHand);
        Assert.Single(player.OnHand);
    }
}