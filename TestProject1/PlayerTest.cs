using Blackjack;

namespace TestProject1;

public class PlayerTest
{
    [Fact]
    public void GivenPlayerHasAceCardOnHand_WhenPlayerTotalPointsIsNotOver21_ThenAceValueShouldRemainAsEleven()
    {
        //arrange
        var player = new Player();
        player.OnHand.Add(new Card(Suit.Club, Number.Ace));
        player.OnHand.Add(new Card(Suit.Club, Number.Nine));
        
        //act
        player.DetermineAceValue();

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
        
        //act
        player.DetermineAceValue();

        //assert
        Assert.Equal(1, player.OnHand[0].Value);
    }

    [Fact]
    public void GivenPlayerHasNoCard_WhenPlayerHits_CardIsAddedToHand()
    {
        //arrange
        var player = new Player();
        var card = new Card(Suit.Club, Number.Ace);
        
        //act
        player.AddCard(card);
        
        //assert
        Assert.Single(player.OnHand);
        Assert.Contains(card, player.OnHand);
    }
}