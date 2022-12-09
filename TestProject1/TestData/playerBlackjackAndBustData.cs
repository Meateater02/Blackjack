using System.Collections;
using Blackjack;

namespace TestProject1.TestData;

public class PlayerBlackjackAndBustData: IEnumerable<object[]>
{
    private static string MockUserInputHit = "1";
    private static string MockUserInputStay = "0";
    private const string ExpectedPlayerWinMessage = "You beat the dealer!";
    private const string ExpectedDealerWinMessage = "Dealer wins!";
    public IEnumerator<object[]> GetEnumerator()
    {
        yield return new object[]
        {
            new List<Card>()
            {
                new(Suit.Diamond, Number.Ace),
                new(Suit.Diamond, Number.Nine),
                new(Suit.Diamond, Number.Ace)
            },
            MockUserInputHit,
            new List<string>()
            {
                "You have hit Blackjack!",
                ExpectedPlayerWinMessage
            }
        };
        
        yield return new object[]
        {
            new List<Card>()
            {
                new(Suit.Diamond, Number.Ace),
                new(Suit.Diamond, Number.Nine),
                new(Suit.Diamond, Number.Seven),
                new(Suit.Diamond, Number.Five),
                new(Suit.Diamond, Number.Nine)
            },
            MockUserInputStay,
            new List<string>()
            {
                "Dealer has hit Blackjack!",
                ExpectedDealerWinMessage
            }
        };

        yield return new object[]
        {
            new List<Card>()
            {
                new(Suit.Diamond, Number.Ace),
                new(Suit.Diamond, Number.Nine),
                new(Suit.Diamond, Number.King),
                new(Suit.Diamond, Number.Four),
                new(Suit.Diamond, Number.Jack),
            },
            "0",
            new List<string>()
            {
                "Dealer is currently at Bust!",
                ExpectedPlayerWinMessage
            }
        };

        yield return new object[]
        {
            new List<Card>()
            {
                new(Suit.Diamond, Number.Eight),
                new(Suit.Diamond, Number.Nine),
                new(Suit.Diamond, Number.King)
            },
            "1",
            new List<string>()
            {
                "You are currently at Bust!",
                ExpectedDealerWinMessage
            }
        };
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }
}