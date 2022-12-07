namespace Blackjack;

public class Card: IEquatable<Card>
{
    public Suit Suit { get; }
    public Number Number { get; }
    
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

    public bool Equals(Card? other)
    {
        if (ReferenceEquals(null, other)) return false;
        if (ReferenceEquals(this, other)) return true;
        return Suit == other.Suit && Number == other.Number && Value == other.Value;
    }

    public override bool Equals(object? obj)
    {
        if (ReferenceEquals(null, obj)) return false;
        if (ReferenceEquals(this, obj)) return true;
        if (obj.GetType() != this.GetType()) return false;
        return Equals((Card)obj);
    }

    public override int GetHashCode()
    {
        return HashCode.Combine((int)Suit, (int)Number, Value);
    }
}