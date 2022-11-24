namespace Blackjack;

public class Card
{
    public Suit Suit { get; set; }
    public Number Number { get; set; }
    
    public int Value { get; set; }

    //constructor
    public Card(Suit suit, Number number)
    {
        Suit = suit;
        Number = number;
        InitialiseValue();
    }

    public override string ToString()
    {
        switch (Number)
        {
            case Blackjack.Number.Ace:
            case Blackjack.Number.Jack:
            case Blackjack.Number.Queen:
            case Blackjack.Number.King:
                return "[\'" + Number.ToString().ToUpper() + "\', " + "\'" + Suit.ToString().ToUpper() + "\']";
                break;
            default:
                return "[" + Value + ", " + "\'" + Suit.ToString().ToUpper() + "\']";
                break;
        }
    }
    
    //initialise card value number
    private void InitialiseValue()
    {
        switch (Number)
        {
            case Number.Ace:
                Value = 11; //default as 11
                break;
            case Number.Jack:
            case Number.Queen:
            case Number.King:
                Value = 10;
                break;
            default:
                Value = (int)Number;
                break;
        }
    }

}