using Blackjack;

namespace TestProject1;

public class CardTest
{
    [Fact]
    public void GivenASpecificCard_WhenCardIsCreated_CardValueIsCorrect()
    {
        var card1 = new Card(Suit.Club, Number.Ace);
        var card2 = new Card(Suit.Heart, Number.King);
        var card3 = new Card(Suit.Diamond, Number.Queen);
        var card4 = new Card(Suit.Heart, Number.Eight);
        var card5 = new Card(Suit.Heart, Number.Two);

        Assert.Equal(11, card1.Value);
        Assert.Equal(10, card2.Value);
        Assert.Equal(10, card3.Value);
        Assert.Equal(8, card4.Value);
        Assert.Equal(2, card5.Value);
    }
}