namespace Blackjack;

public class Game
{
    private Player _human;
    private Player _dealer;
    private readonly CardDealer _cardDealer;
    private readonly Scoring _scoringSystem;
    private readonly Printer _printer;
    private readonly Reader _reader;

    public Game(CardDealer cardDealer)
    {
        _cardDealer = cardDealer;
        _human = new Player(cardDealer);
        _dealer = new Player(cardDealer)
        {
            IsDealer = true
        };
        _scoringSystem = new Scoring(_human, _dealer);
        _printer = new Printer(new ConsoleWriter());
        _reader = new Reader(new ConsoleReader());
    }

    public void Play()
    {
        StartGame();
        GamePlay();
    }

    public void GamePlay()
    {
        var player = _human;
        
        while (!_scoringSystem.IsGameEnd)
        {
            _scoringSystem.DetermineAceValue(player);
            _printer.PrintPointsStatus(player);
        
            if (player.Scores.TotalPoints >= 21)
            {
                _printer.PrintGameEnd(_scoringSystem);
                break;
            }
        
            if (!player.IsDealer) //human player
            {
                player = HumanAction(player);
                _human = player;
            }
            else //dealer
            {
                DealerAction(player);
                _dealer = player;
            }
        }
    }
    
    private void StartGame()
    {
        _cardDealer.Deck.ShuffleDeck();
        _human.Start();
    }

    public Player HumanAction(Player player)
    {
        _printer.PrintOption();

        var userInput = _reader.ReadValidInt();

        while (!(userInput is >= 0 and <= 1))
        {
            _printer.PrintInvalidUserInput();
            userInput = _reader.ReadValidInt();
        }

        switch (userInput)
        {
            case 1:
                player.Hit();
                _printer.PrintCardDrawn(player);
                break;
            case 0:
                player.IsStay = true;
                player = _dealer;
                player.Start();
                break;
        }

        return player;
    }

    public void DealerAction(Player dealer)
    {
        Thread.Sleep(1000);
        
        if (dealer.Scores.TotalPoints < 17)
        {
            dealer.Hit();
            _printer.PrintCardDrawn(dealer);
        }
        else
        {
            dealer.IsStay = true;
            _printer.PrintGameEnd(_scoringSystem);
        }
    }
}