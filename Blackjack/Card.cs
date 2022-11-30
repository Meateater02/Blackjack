namespace Blackjack;

public class Card
{
    private Suit Suit { get; set; }
    private Number Number { get; set; }
    
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
            case Number.Ace:
            case Number.Jack:
            case Number.Queen:
            case Number.King:
                return "[\'" + Number.ToString().ToUpper() + "\', " + "\'" + Suit.ToString().ToUpper() + "\']";
            default:
                return "[" + Value + ", " + "\'" + Suit.ToString().ToUpper() + "\']";
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