// See https://aka.ms/new-console-template for more information

using Blackjack;

//Variables
var cardDealer = new CardDealer();
var player = new Player(cardDealer);
var dealer = new Player(cardDealer)
{
    Dealer = true
};
var scoringSystem = new Scoring(player, dealer);
var printer = new Printer();

//shuffles deck to start
cardDealer.Deck.ShuffleDeck();

//start with player
player.Start();

while (!scoringSystem.GameEnd)
{
    scoringSystem.DetermineAceValue(player);
    printer.PrintPointsStatus(player);

    if (player.Scores.TotalPoints > 21)
        printer.PrintGameEnd(scoringSystem);

    if (!scoringSystem.GameEnd)
    {
        printer.PrintOption();
        var userInput = Convert.ToInt32(Console.ReadLine());

        if (userInput == 1)
        {
            player.Hit();
            printer.PrintCardDrawn(player);
        }
        else if (userInput == 0)
        {
            player.Stay = true;
            break;
        }
    }
}

//dealer's turn
dealer.Start();

while (!scoringSystem.GameEnd)
{
    scoringSystem.DetermineAceValue(dealer);
    printer.PrintPointsStatus(dealer);

    if (dealer.Scores.TotalPoints > 21)
        printer.PrintGameEnd(scoringSystem);

    if (!scoringSystem.GameEnd)
    {
        if (dealer.Scores.TotalPoints < 17)
        {
            dealer.Hit();
            printer.PrintCardDrawn(dealer);
        }
        else
        {
            dealer.Stay = true;
            break;
        }
    }
}

printer.PrintGameEnd(scoringSystem);