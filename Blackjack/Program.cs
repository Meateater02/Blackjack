// See https://aka.ms/new-console-template for more information

using Blackjack;

var game = new Game();

game.Play();

//initialise variables
// var cardDealer = new CardDealer();
// var human = new Player(cardDealer);
// var dealer = new Player(cardDealer)
// {
//     IsDealer = true
// };
// var scoringSystem = new Scoring(human, dealer);
// var printer = new Printer(new ConsoleWriter());
// var reader = new Reader(new ConsoleReader());

//shuffle deck to start
// cardDealer.Deck.ShuffleDeck();

//human starts first
// var player = human;
// player.Start();

// while (!scoringSystem.IsGameEnd)
// {
//     //update the scoringSystem
//     if (!player.IsDealer)
//         human = player;
//     else
//         dealer = player;
//     
//     scoringSystem.DetermineAceValue(player);
//     printer.PrintPointsStatus(player);
//
//     if (player.Scores.TotalPoints >= 21)
//     {
//         printer.PrintGameEnd(scoringSystem);
//         break;
//     }
//
//     if (!player.IsDealer) //human player
//     {
//         printer.PrintOption();
//         
//         var userInput = reader.ReadValidInt();
//         
//         while (!(userInput is >= 0 and <= 1))
//         {
//             printer.PrintInvalidUserInput();
//             userInput = reader.ReadValidInt();
//         }
//         
//         switch (userInput)
//         {
//             case 1:
//                 player.Hit();
//                 printer.PrintCardDrawn(player);
//                 break;
//             case 0:
//                 player.IsStay = true;
//                 player = dealer;
//                 player.Start();
//                 break;
//         }
//     }
//     else //dealer
//     {
//         Thread.Sleep(1000);
//         
//         if (dealer.Scores.TotalPoints < 17)
//         {
//             dealer.Hit();
//             printer.PrintCardDrawn(dealer);
//         }
//         else
//         {
//             dealer.IsStay = true;
//             printer.PrintGameEnd(scoringSystem);
//         }
//     }
// }