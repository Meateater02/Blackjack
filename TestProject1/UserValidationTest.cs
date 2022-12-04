using System.Runtime.InteropServices;
using Blackjack;
using Moq;

namespace TestProject1;

public class UserValidationTest
{
    [Theory]
    [InlineData("1")]
    [InlineData("0")]
    public void GivenPlayerTurn_WhenValidUserInputs_ThenTurnIsValid(string userInput)
    {
        //arrange
        var writerMock = new Mock<IWriter>();
        var readerMock = new Mock<IReader>();
        var expectedMessage = "Hit or stay? (Hit = 1, Stay = 0) ";
        var userValidation = new UserValidation(readerMock.Object, writerMock.Object);
        readerMock.Setup(reader => reader.ReadLine()).Returns(userInput);
        var expectedUserMove = int.Parse(userInput);
        
        //act
        var actualUserMove = userValidation.GetPlayerMove();

        //assert
        writerMock.Verify(writer => writer.Write(expectedMessage));
        Assert.Equal(expectedUserMove, actualUserMove);
    }
    
    [Fact]
    public void GivenPlayerTurn_WhenInvalidUserInputs_ThenTurnIsInValid()
    {
        //arrange
        var writerMock = new Mock<IWriter>();
        var readerMock = new Mock<IReader>();
        var expectedPromptMessage = "Hit or stay? (Hit = 1, Stay = 0) ";
        var expectedErrorMessage = "Invalid input! Please try again: (Hit = 1, Stay = 0) ";
        var userValidation = new UserValidation(readerMock.Object, writerMock.Object);
        readerMock.SetupSequence(reader => reader.ReadLine())
            .Returns("se ag")
            .Returns("1");

        //act
        userValidation.GetPlayerMove();

        //assert
        writerMock.Verify(writer => writer.Write(expectedErrorMessage));
        writerMock.Verify(writer => writer.Write(expectedPromptMessage));
        
    }
}