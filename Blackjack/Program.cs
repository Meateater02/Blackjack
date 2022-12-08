// See https://aka.ms/new-console-template for more information

using System.CodeDom.Compiler;
using Blackjack;

var writer = new ConsoleWriter();
var reader = new ConsoleReader();
var random = new Randomiser();
var deck = new Deck(random);
var game = new Game(writer, reader, deck);

game.Play();