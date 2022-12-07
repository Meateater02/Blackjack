using Blackjack;
using Moq;

namespace TestProject1;

public class GameTest
{
    [Fact]
    public void GivenDealersPointsAreBelow17_WhenDealersTurn_ThenDealerHitAutomatically()
    {
        //arrange
        var game = new Game();

        game._dealer.Scores.TotalPoints = 15;
        
        //act
        game.DealerAction(game._dealer);
        
        //assert
        Assert.Single(game._dealer.OnHand);
    }
    
    [Fact]
    public void GivenDealersPointsAreAbove17_WhenDealersTurn_ThenDealerAutomaticallyStay()
    {
        //arrange
        var game = new Game();
        game._dealer.Scores.TotalPoints = 20;

        //act
        game.DealerAction(game._dealer);
        
        //assert
        Assert.Empty(game._dealer.OnHand);
    }

    [Fact]
    public void GivenUserChooseAction_WhenUserChooseHit_ThenNewCardIsAddedToThePlayer()
    {
        //arrange
        var game = new Game();
        game._deck.ShuffleDeck();
        game._human.AddCard(game._deck.DealCard());
        game._human.AddCard(game._deck.DealCard());

        var userValidation = new UserValidation(new ConsoleReader(), new ConsoleWriter());

        var userInput = "1";
        var stringReader = new StringReader(userInput);
        Console.SetIn(stringReader);

        //act
        game.HumanAction(game._human, userValidation.GetPlayerMove());
        
        //assert
        Assert.Equal(3, game._human.OnHand.Count);
        Assert.False(game._human.IsStay);
    }
    
    [Fact]
    public void GivenUserChooseAction_WhenUserChooseStay_ThenNoCardIsAddedToThePlayer()
    {
        //arrange
        var game = new Game();
        game._deck.ShuffleDeck();
        game._human.AddCard(game._deck.DealCard());
        game._human.AddCard(game._deck.DealCard());

        var userValidation = new UserValidation(new ConsoleReader(), new ConsoleWriter());
        
        var userInput = "0";
        var stringReader = new StringReader(userInput);
        Console.SetIn(stringReader);

        var expectedOnHand = game._human.OnHand.Count;

        //act
        game.HumanAction(game._human, userValidation.GetPlayerMove());
        
        //assert
        Assert.Equal(expectedOnHand, game._human.OnHand.Count);
        Assert.True(game._human.IsStay);
    }

    [Fact]
    public void GivenPlayerHit_WhenPlayerGotBlackjack_ThenGameEnds()
    {
        //arrange
        var mockWriter = new Mock<IWriter>();
        var mockReader = new Mock<IReader>();
        var mockRandom = new Mock<IRandomiser>();
        var game = new Game(mockWriter.Object, mockReader.Object, mockRandom.Object);
        var stringWriter = new StringWriter();
        Console.SetOut(stringWriter);

        //act


        //assert

    }
}