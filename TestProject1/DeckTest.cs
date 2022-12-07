using System.Runtime.InteropServices;
using Blackjack;
using Moq;

namespace TestProject1;

public class DeckTest
{
    [Fact]
    public void GivenThereIsADeck_WhenDeckIsShuffled_ThenCardsShouldBeRandomised()
    {
        //arrange
        var mockRandom = new Mock<IRandomiser>();
        mockRandom.Setup(rand => rand.Next()).Returns(0);
        var unshuffledDeck = new Deck(mockRandom.Object);
        var shuffledDeck = new Deck(new Randomiser());

        //assert
        Assert.NotEqual(shuffledDeck, unshuffledDeck);
    }

    [Fact]
    public void GivenThereIsADeck_WhenDeckIsCreated_ThenThereShouldBe52Cards()
    {
        var mockRandom = new Mock<IRandomiser>();
        var deck = new Deck(mockRandom.Object);
        
        Assert.Equal(52, deck.Cards.Count);
    }

    [Fact]
    public void GivenThereIsADeck_WhenCardIsDealt_ThenDeckSizeShouldReduce()
    {
        var mockRandom = new Mock<IRandomiser>();
        var deck = new Deck(mockRandom.Object);

        deck.DealCard();
        
        Assert.Equal(51, deck.Cards.Count);
    }

    [Fact]
    public void GivenThereIsADeck_WhenCardIsDealt_ThenCardShouldNotExistInDeck()
    {
        var mockRandom = new Mock<IRandomiser>();
        var deck = new Deck(mockRandom.Object);
        var cardDrawn = deck.Cards.First();

        deck.DealCard();
        
        Assert.DoesNotContain(cardDrawn, deck.Cards);
    }

    [Theory]
    [InlineData(Suit.Club)]
    [InlineData(Suit.Diamond)]
    [InlineData(Suit.Heart)]
    [InlineData(Suit.Spade)]
    public void GivenThereIsADeck_WhenDeckIsCreated_ThenEachSuitShouldHave13Cards(Suit suit)
    {
        var mockRandom = new Mock<IRandomiser>();
        var deck = new Deck(mockRandom.Object);

        var actualNumberOfCards = deck.Cards.Count(card => card.Suit == suit);
        
        Assert.Equal(13, actualNumberOfCards);
    }
}