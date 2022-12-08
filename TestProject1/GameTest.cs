using Blackjack;
using Moq;
using TestProject1.Fake;

namespace TestProject1;

public class GameTest
{
    [Fact]
    public void GivenPlayerHit_WhenPlayerGotBlackjack_ThenGameEndsWithPlayerWin()
    {
        //arrange
        var mockWriter = new Mock<IWriter>();
        var mockReader = new Mock<IReader>();
        var fakeDeck = new DeckFake();
        fakeDeck.Cards.Add(new Card(Suit.Diamond, Number.Ace));
        fakeDeck.Cards.Add(new Card(Suit.Diamond, Number.Nine));
        fakeDeck.Cards.Add(new Card(Suit.Diamond, Number.Ace));
        var game = new Game(mockWriter.Object, mockReader.Object, fakeDeck);
        mockReader.Setup(reader => reader.ReadLine()).Returns("1");
        var expectedMessage1 = "You have hit Blackjack!";
        var expectedMessage2 = "You beat the dealer!";
        var notExpectedMessage = "Dealer wins!";
        
        //act
        game.Play();

        //assert
        mockWriter.Verify(writer => writer.WriteLine(expectedMessage1));
        mockWriter.Verify(writer => writer.WriteLine(expectedMessage2));
        mockWriter.Verify(writer => writer.WriteLine(notExpectedMessage), Times.Never);
    }
    
    [Fact]
    public void GivenDealerHit_WhenDealerGotBlackjack_ThenGameEndsWithDealerWin()
    {
        //arrange
        var mockWriter = new Mock<IWriter>();
        var mockReader = new Mock<IReader>();
        var fakeDeck = new DeckFake();
        fakeDeck.Cards.Add(new Card(Suit.Diamond, Number.Ace));
        fakeDeck.Cards.Add(new Card(Suit.Diamond, Number.Nine));
        fakeDeck.Cards.Add(new Card(Suit.Spade, Number.Seven));
        fakeDeck.Cards.Add(new Card(Suit.Heart, Number.Five));
        fakeDeck.Cards.Add(new Card(Suit.Club, Number.Nine));
        var game = new Game(mockWriter.Object, mockReader.Object, fakeDeck);
        mockReader.Setup(reader => reader.ReadLine()).Returns("0");
        var expectedMessage1 = "Dealer has hit Blackjack!";
        var expectedMessage2 = "Dealer wins!";
        var notExpectedMessage = "You beat the dealer!";
        
        //act
        game.Play();

        //assert
        mockWriter.Verify(writer => writer.WriteLine(expectedMessage1));
        mockWriter.Verify(writer => writer.WriteLine(expectedMessage2));
        mockWriter.Verify(writer => writer.WriteLine(notExpectedMessage), Times.Never);
    }
    
    [Fact]
    public void GivenPlayerHit_WhenPlayerBust_ThenGameEndsWithDealerWin()
    {
        //arrange
        var mockWriter = new Mock<IWriter>();
        var mockReader = new Mock<IReader>();
        var fakeDeck = new DeckFake();
        var game = new Game(mockWriter.Object, mockReader.Object, fakeDeck);
        fakeDeck.Cards.Add(new Card(Suit.Diamond, Number.Eight));
        fakeDeck.Cards.Add(new Card(Suit.Diamond, Number.Nine));
        fakeDeck.Cards.Add(new Card(Suit.Diamond, Number.King));
        fakeDeck.Cards.Add(new Card(Suit.Diamond, Number.Queen));
        fakeDeck.Cards.Add(new Card(Suit.Diamond, Number.Jack));
        mockReader.Setup(reader => reader.ReadLine()).Returns("1");
        var expectedMessage1 = "You are currently at Bust!";
        var expectedMessage2 = "Dealer wins!";
        var notExpectedMessage = "You beat the dealer!";
        
        //act
        game.Play();

        //assert
        mockWriter.Verify(writer => writer.WriteLine(expectedMessage1));
        mockWriter.Verify(writer => writer.WriteLine(expectedMessage2));
        mockWriter.Verify(writer => writer.WriteLine(notExpectedMessage), Times.Never);
    }

    [Fact]
    public void GivenDealerHit_WhenDealerBust_ThenGameEndsWithPlayerWin()
    {
        //arrange
        var mockWriter = new Mock<IWriter>();
        var mockReader = new Mock<IReader>();
        var fakeDeck = new DeckFake();
        var game = new Game(mockWriter.Object, mockReader.Object, fakeDeck);
        fakeDeck.Cards.Add(new Card(Suit.Diamond, Number.Ace));
        fakeDeck.Cards.Add(new Card(Suit.Diamond, Number.Nine));
        fakeDeck.Cards.Add(new Card(Suit.Diamond, Number.King));
        fakeDeck.Cards.Add(new Card(Suit.Diamond, Number.Four));
        fakeDeck.Cards.Add(new Card(Suit.Diamond, Number.Jack));
        mockReader.Setup(reader => reader.ReadLine()).Returns("0");
        var expectedMessage1 = "Dealer is currently at Bust!";
        var expectedMessage2 = "You beat the dealer!";
        var notExpectedMessage = "Dealer wins!";
        
        //act
        game.Play();

        //assert
        mockWriter.Verify(writer => writer.WriteLine(expectedMessage1));
        mockWriter.Verify(writer => writer.WriteLine(expectedMessage2));
        mockWriter.Verify(writer => writer.WriteLine(notExpectedMessage), Times.Never);
    }

    [Theory]
    [MemberData(nameof(playerBustData))]
    public void GivenPlayerHits_WhenAPlayerBust_ThenTheOtherWins()
    {
        
    }
        
    [Fact]
    public void GivenDealerStayed_WhenDealerPointsIsMoreThanPlayer_ThenGameEndsWithDealerWins()
    {
        
    }

    [Fact]
    public void GivenDealerStayed_WhenPlayerPointsIsMoreThanDealer_ThenGameEndsWithPlayerWins()
    {

    }
    
    [Fact]
    public void GivenDealerStayed_WhenBothPlayerHasSamePoints_ThenGameEndsInDraw()
    {

    }

    public static IEnumerable<object[]> playerBustData => new List<object[]>
    {
        new object[]
        {
            
        }
    }
}