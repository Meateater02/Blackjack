using Blackjack;
using Moq;
using TestProject1.Fake;
using TestProject1.TestData;

namespace TestProject1;

public class GameTest
{
    private Mock<IWriter> writerMock;
    private Mock<IReader> readerMock;

    public GameTest()
    {
        writerMock = new Mock<IWriter>();
        readerMock = new Mock<IReader>();
    }

    [Theory]
    [ClassData(typeof(PlayerBlackjackAndBustData))]
    public void GivenPlayerHits_WhenPlayerGetsBlackJack_ThenGameEndsWithRespectedWinner(List<Card> cards, string userInput, List<string> messages)
    {
        //arrange
        var fakeDeck = new DeckFake();
        fakeDeck.Cards.AddRange(cards);
        var game = new Game(writerMock.Object, readerMock.Object, fakeDeck);
        readerMock.Setup(reader => reader.ReadLine()).Returns(userInput);
        
        //act
        game.Play();

        //assert
        foreach (var message in messages)
        {
            writerMock.Verify(writer => writer.WriteLine(message));
        }
    }

    [Theory]
    [MemberData(nameof(gameEndScoreData))]
    public void GivenDealerStayed_WhenGameEnds_ThenWinnerIsDecided(List<Card> cards, string userInput, string message)
    {
        //arrange
        var fakeDeck = new DeckFake();
        fakeDeck.Cards.AddRange(cards);
        var game = new Game(writerMock.Object, readerMock.Object, fakeDeck);
        readerMock.Setup(reader => reader.ReadLine()).Returns(userInput);
        
        //act
        game.Play();
        
        //assert
        writerMock.Verify(writer => writer.WriteLine(message));
    }

    public static IEnumerable<object[]> gameEndScoreData => new List<object[]>
    {
        new object[] 
        {
            new List<Card>()
            {
                new (Suit.Diamond, Number.Ace),
                new (Suit.Diamond, Number.Nine),
                new (Suit.Diamond, Number.King),
                new (Suit.Diamond, Number.Four),
                new (Suit.Diamond, Number.Three),
            },
            "0",
            "You beat the dealer!"
        },
        new object[]
        {
            new List<Card>()
            {
                new (Suit.Diamond, Number.Eight),
                new (Suit.Club, Number.Nine),
                new (Suit.Diamond, Number.Two),
                new (Suit.Heart, Number.Nine),
                new (Suit.Spade, Number.King)
            },
            "0",
            "Dealer wins!"
        },
        new object[]
        {
            new List<Card>()
            {
                new (Suit.Heart, Number.Queen),
                new (Suit.Spade, Number.Jack),
                new (Suit.Diamond, Number.King),
                new (Suit.Club, Number.Ten)
            },
            "0",
            "Draw!"
        }
    };
}