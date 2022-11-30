using Blackjack;
using Moq;

namespace TestProject1;

public class PrinterTest
{
    [Fact]
    public void GivenPlayerTurn_WhenPromptedForTurn_ThenShouldDisplayOptions()
    {
        //arrange
        var writerMock = new Mock<IWriter>();
        var printer = new Printer(writerMock.Object);
        var expectedMessage = "Hit or stay? (Hit = 1, Stay = 0)";

        //act
        printer.PrintOption();

        //assert
        writerMock.Verify(writer => writer.WriteLine(expectedMessage));
    }

    [Fact]
    public void GivenPlayerHasCards_WhenPromptedToShowCardsOnHand_ThenShouldDisplayAllCards()
    {
        //arrange
        var writerMock = new Mock<IWriter>();
        var printer = new Printer(writerMock.Object);
        
        //act
        
        //assert
        
    }
}