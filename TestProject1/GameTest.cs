using Blackjack;
using Xunit.Abstractions;

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
        game.HumanAction(game._human, userValidation.PromptUserInputForOneOrZero());
        
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
        game.HumanAction(game._human, userValidation.PromptUserInputForOneOrZero());
        
        //assert
        Assert.Equal(expectedOnHand, game._human.OnHand.Count);
        Assert.True(game._human.IsStay);
    }

    // [Theory]
    // [InlineData("hello")]
    // [InlineData("1ne")]
    // [InlineData("[.;lk,l")]
    // [InlineData("one")]
    // public void GivenUserChooseAction_WhenInputIsInvalid_ThenErrorMessageIsDisplayed(string userInput)
    // {
    //     //arrange
    //     var game = new Game();
    //     game._deck.ShuffleDeck();
    //     game._human.AddCard(game._deck.DealCard());
    //     game._human.AddCard(game._deck.DealCard());
    //     
    //     var stringReader = new StringReader("userInput");
    //     Console.SetIn(stringReader);
    //
    //     var stringWriter = new StringWriter();
    //     Console.SetOut(stringWriter);
    //
    //     var actualMessage = stringWriter.ToString();
    //     var expectedMessage = "Invalid input! Please try again: ";
    //     
    //     //act
    //     game.HumanAction(game._human, game.GetValidPlayerInput());
    //     
    //     //assert
    //     Assert.Matches(expectedMessage, actualMessage);
    // }
}