// See https://aka.ms/new-console-template for more information

using Blackjack;

//Variables
var cardDealer = new CardDealer();
var player = new Player(cardDealer);
var dealer = new Player(cardDealer)
{
    IsDealer = true
};
var scoringSystem = new Scoring(player, dealer);
var printer = new Printer();

//shuffles deck to start
cardDealer.Deck.ShuffleDeck();

//start with player
player.Start();

while (!scoringSystem.IsGameEnd)
{
    scoringSystem.DetermineAceValue(player);
    printer.PrintPointsStatus(player);

    if (player.Scores.TotalPoints >= 21)
        printer.PrintGameEnd(scoringSystem);

    if (!scoringSystem.IsGameEnd)
    {
        printer.PrintOption(); 
        var readUserInput = Console.ReadLine();
        int userInput;
        while (!int.TryParse(readUserInput, out userInput))
        {
            Console.WriteLine("Invalid input! ");
            readUserInput = Console.ReadLine();
        }

        if (userInput == 1)
        {
            player.Hit();
            printer.PrintCardDrawn(player);
        }
        else if (userInput == 0)
        {
            player.IsStay = true;
            break;
        }
    }
}

//dealer's turn
dealer.Start();

while (!scoringSystem.IsGameEnd)
{
    scoringSystem.DetermineAceValue(dealer);
    printer.PrintPointsStatus(dealer);

    if (dealer.Scores.TotalPoints >= 21)
        printer.PrintGameEnd(scoringSystem);

    if (!scoringSystem.IsGameEnd)
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
            break;
        }
    }
}