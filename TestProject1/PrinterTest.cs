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
        player.AddCard(new Card(Suit.Club,Number.Ace));
        player.AddCard(new Card(Suit.Club,Number.Ten));
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
            new (Suit.Club, Number.Ace),
            new (Suit.Heart, Number.Four)
        };
        var expectedDisplayCards = "with the hand [['ACE', 'CLUB'][4, 'HEART']]\n\n";

        //act
        printer.PrintOnHand(cards);
        
        //assert
        writerMock.Verify(writer => writer.Write(expectedDisplayCards));
    }

    [Fact]
    public void GivenPlayerHasCardsOnHand_WhenPrintPointsStatusIsCalled_ThenCardPointsAreDisplayedCorrectly()
    {
        var player = new Player();
        var deck = new Deck(new Randomiser());
        player.AddCard(deck.DealCard());
        var writerMock = new Mock<IWriter>();
        var printer = new Printer(writerMock.Object);
        var expectedMessage = "You are currently at " + player.Scores.TotalPoints;

        printer.PrintPointsStatus(player);
        
        writerMock.Verify(writer => writer.WriteLine(expectedMessage));
    }
}