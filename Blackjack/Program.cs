// See https://aka.ms/new-console-template for more information

using System.CodeDom.Compiler;
using Blackjack;

var writer = new ConsoleWriter();
var reader = new ConsoleReader();
var random = new Randomiser();
var game = new Game(writer, reader, random);

game.Play();