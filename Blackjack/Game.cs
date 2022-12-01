namespace Blackjack;

public class Game
{
    public Player _human { get; set; }
    public Player _dealer { get; set; }
    public Deck _deck { get; }
    private readonly Scoring _scoringSystem;
    private readonly Printer _printer;
    private readonly Reader _reader;

    public Game()
    {
        _dealer = new Player()
        {
            IsDealer = true
        };
        _human = new Player();
        _deck = new Deck();
        _scoringSystem = new Scoring(_human, _dealer);
        _printer = new Printer(new ConsoleWriter());
        _reader = new Reader(new ConsoleReader());
    }

    public void Play()
    {
        StartGame();
        PlayGame();
    }

    private void StartGame()
    {
        _deck.ShuffleDeck();
        _human.AddCard(_deck.DealCard());
        _human.AddCard(_deck.DealCard());
    }

    private void PlayGame()
    {
        var player = _human;
        
        while (!_scoringSystem.IsGameEnd)
        {
            player.Scores.TotalPoints = _scoringSystem.DetermineAceValue(player.OnHand);
            _printer.PrintPointsStatus(player);
            _printer.PrintOnHand(player.OnHand);

            //_printer.PrintGameEnd(_scoringSystem);
            
            if (player.Scores.TotalPoints >= 21)
            {
                _printer.PrintGameEnd(_scoringSystem);
                break;
            }

            if (!_scoringSystem.IsGameEnd && !player.IsDealer)
            {
                _printer.PrintOption();
                player = HumanAction(player, GetValidPlayerInput());
            }
            else if (!_scoringSystem.IsGameEnd && player.IsDealer)
            {
                DealerAction(player);
            }
            
        }
    }

    public int GetValidPlayerInput()
    {
        var userInput = _reader.ReadValidInt();

         while (!(userInput is >= 0 and <= 1))
         {
             _printer.PrintInvalidUserInput();
             userInput = _reader.ReadValidInt();
         }

        return userInput;
    }

    public Player HumanAction(Player player, int userInput)
    {
        switch (userInput)
        {
            case 1:
                player.AddCard(_deck.DealCard());
                _printer.PrintCardDrawn(player);
                _human = player;
                break;
            case 0:
                player.IsStay = true;
                _human = player;
                player = _dealer;
                player.AddCard(_deck.DealCard());
                player.AddCard(_deck.DealCard());
                break;
        }

        return player;
    }

    public void DealerAction(Player player)
    {
        Thread.Sleep(1000);
        
        if (_dealer.Scores.TotalPoints < 17)
        {
            player.AddCard(_deck.DealCard());
            _printer.PrintCardDrawn(player);
        }
        else
        {
            player.IsStay = true;
            _printer.PrintGameEnd(_scoringSystem);
        }

        _dealer = player;
    }
}