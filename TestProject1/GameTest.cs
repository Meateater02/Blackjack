using Blackjack;

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
        game.DealerAction();
        
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
        game.DealerAction();
        
        //assert
        Assert.Empty(game._dealer.OnHand);
    }

    [Fact]
    public void GivenUserChooseAction_WhenUserChooseHit_ThenNewCardIsAddedToThePlayer()
    {
        //arrange
        var game = new Game();
        game._dealer.Deck.ShuffleDeck();
        game._player.AddCard(game._dealer.DealCard());
        game._player.AddCard(game._dealer.DealCard());

        var userInput = "1";
        var stringReader = new StringReader(userInput);
        Console.SetIn(stringReader);

        //act
        game.PlayerAction(game.GetPlayerInput());
        
        //assert
        Assert.Equal(3, game._player.OnHand.Count);
        Assert.False(game._player.IsStay);
    }
    
    [Fact]
    public void GivenUserChooseAction_WhenUserChooseStay_ThenNoCardIsAddedToThePlayer()
    {
        //arrange
        var game = new Game();
        game._dealer.Deck.ShuffleDeck();
        game._player.AddCard(game._dealer.DealCard());
        game._player.AddCard(game._dealer.DealCard());

        var userInput = "1";
        var stringReader = new StringReader(userInput);
        Console.SetIn(stringReader);

        var expectedOnHand = game._player.OnHand.Count;

        //act
        game.PlayerAction(game.GetPlayerInput());
        
        //assert
        Assert.Equal(expectedOnHand, game._player.OnHand.Count);
        Assert.True(game._player.IsStay);
    }

    [Theory]
    [InlineData("hello")]
    [InlineData("1ne")]
    [InlineData("[.;lk,l")]
    [InlineData("one")]
    public void GivenUserChooseAction_WhenInputIsInvalid_ThenErrorMessageIsDisplayed(string userInput)
    {
        //arrange
        var game = new Game();
        game._dealer.Deck.ShuffleDeck();
        game._player.AddCard(game._dealer.DealCard());
        game._player.AddCard(game._dealer.DealCard());
        
        var stringReader = new StringReader(userInput);
        Console.SetIn(stringReader);

        var stringWriter = new StringWriter();
        Console.SetOut(stringWriter);

        var actualMessage = stringWriter.ToString();
        var expectedMessage = "Invalid input! Please try again: ";
        
        //act
        game.PlayerAction(game.GetPlayerInput());
        
        //assert
    }
}