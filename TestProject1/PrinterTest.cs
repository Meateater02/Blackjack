using System.CodeDom.Compiler;
using Blackjack;
using Moq;

namespace TestProject1;

public class PrinterTest
{
    [Fact]
    public void GivenPlayerHasBlackJack_WhenPlayerScoreIsPrinted_ThenShouldAnnounceBlackJack()
    {
        //arrange
        var player = new Player();
        var writerMock = new Mock<IWriter>();
        var printer = new Printer(writerMock.Object);
        player.Scores.TotalPoints = 21;
        var expectedMessage = "You have hit Blackjack!";

        //act
        printer.PrintPointsStatus(player);

        //assert
        writerMock.Verify(writer => writer.WriteLine(expectedMessage));
    }

    [Fact]
    public void GivenPlayerHit_WhenPrintCardDrawnIsCalled_ThenShouldDisplayCorrectPronoun()
    {
        var player = new Player();
        var dealer = new Player()
        {
            IsDealer = true
        };
        player.AddCard(new Card(Suit.Club, Number.King));
        dealer.AddCard(new Card(Suit.Spade, Number.Seven));
        var expectedDealerMessage = "Dealer draws " + dealer.OnHand.Last() + "\n";
        var expectedPlayerMessage = "You draw " + player.OnHand.Last() + "\n";
        var mockWriter = new Mock<IWriter>();
        var printer = new Printer(mockWriter.Object);
        
        printer.PrintCardDrawn(player);
        printer.PrintCardDrawn(dealer);
    
        mockWriter.Verify(writer => writer.Write(expectedDealerMessage));
        mockWriter.Verify(writer => writer.Write(expectedPlayerMessage));
    }
    
    [Fact]
    public void GivenThereAreTwoCards_WhenPrintOnHandIsCalled_ThenShouldDisplayAllCards()
    {
        //arrange
        var writerMock = new Mock<IWriter>();
        var printer = new Printer(writerMock.Object);
        var cards = new List<Card>()
        {
            new Card(Suit.Club, Number.Ace),
            new Card(Suit.Heart, Number.Four)
        };
        var expectedDisplayCards = "with the hand [['ACE', 'CLUB'][4, 'HEART']]\n\n";

        //act
        printer.PrintOnHand(cards);
        
        //assert
        writerMock.Verify(writer => writer.Write(expectedDisplayCards));
    }

    [Theory]
    [InlineData(16)]
    [InlineData(17)]
    [InlineData(19)]
    [InlineData(14)]
    [InlineData(20)]
    public void GivenPlayerHasCardsOnHand_WhenPrintPointsStatusIsCalled_ThenCardPointsAreDisplayedCorrectly(int scores)
    {
        var player = new Player();
        player.Scores.TotalPoints = scores;
        var writerMock = new Mock<IWriter>();
        var printer = new Printer(writerMock.Object);
        var expectedMessage = "You are currently at " + scores;

        printer.PrintPointsStatus(player);
        
        writerMock.Verify(writer => writer.WriteLine(expectedMessage));
    }
}