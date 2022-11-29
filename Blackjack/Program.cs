// See https://aka.ms/new-console-template for more information

using Blackjack;

//Variables
var cardDealer = new CardDealer();
var human = new Player(cardDealer);
var dealer = new Player(cardDealer)
{
    IsDealer = true
};
var writer = new ConsoleWriter();
var scoringSystem = new Scoring(human, dealer);
var printer = new Printer(writer);

//human starts first
var player = human;

//shuffles deck to start
cardDealer.Deck.ShuffleDeck();

//start with player
player.Start();

while (!scoringSystem.IsGameEnd)
{
    //update the scoringSystem
    if (!player.IsDealer)
        human = player;
    else
        dealer = player;
    
    scoringSystem.DetermineAceValue(player);
    printer.PrintPointsStatus(player);

    if (player.Scores.TotalPoints >= 21)
        printer.PrintGameEnd(scoringSystem);

    if (!scoringSystem.IsGameEnd && !player.IsDealer)
    {
        printer.PrintOption(); 
        var readUserInput = Console.ReadLine();
        int userInput;
        while (!int.TryParse(readUserInput, out userInput) || !(userInput is >= 0 and <= 1))
        {
            printer.PrintInvalidUserInput();
            readUserInput = Console.ReadLine();
        }

        if (userInput == 1)
        {
            player.Hit();
            printer.PrintCardDrawn(player);
        }
        else
        {
            player.IsStay = true;
            
            //dealer's turn to play
            player = dealer;
            player.Start();
        }
    }
    else if (!scoringSystem.IsGameEnd && player.IsDealer)
    {
        Thread.Sleep(1000);
        
        if (dealer.Scores.TotalPoints < 17)
        {
            dealer.Hit();
            printer.PrintCardDrawn(dealer);
        }
        else
        {
            dealer.IsStay = true;
            printer.PrintGameEnd(scoringSystem);
        }
    }
}