// See https://aka.ms/new-console-template for more information

using Blackjack;

Console.WriteLine("You are currently at ");
Console.WriteLine("with the hand ");

Console.WriteLine("Hit or stay? (Hit = 1, Stay = 0)");

//Test for card value
// Card card = new Card(Suit.Diamond, Number.Ace);
// Console.WriteLine(card.Value);

//Test for cards in the deck
// Deck deck = new Deck();
// Console.WriteLine("\nCheck deck cards:");
// foreach (Card deckCard in deck.Cards)
// {
//     Console.WriteLine(deckCard.ToString());
// }

//Test for player hit action
CardDealer cardDealer = new CardDealer();
Player player = new Player(cardDealer);
Printer printer = new Printer();
player.Hit();
Console.WriteLine(printer.PrintOnHand(player.OnHand));

