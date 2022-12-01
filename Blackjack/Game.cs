namespace Blackjack;

public class Game
{
    public Player _player { get; }
    public Dealer _dealer { get; }
    private readonly Scoring _scoringSystem;
    private readonly Printer _printer;
    private readonly Reader _reader;

    public Game()
    {
        _dealer = new Dealer();
        _player = new Player();
        _scoringSystem = new Scoring(_player, _dealer);
        _printer = new Printer(new ConsoleWriter());
        _reader = new Reader(new ConsoleReader());
    }

    public void Play()
    {
        StartGame();
        PlayerTurn();
        DealerTurn();
        
    }

    private void StartGame()
    {
        _dealer.Deck.ShuffleDeck();
        _player.AddCard(_dealer.DealCard());
        _player.AddCard(_dealer.DealCard());
    }

    private void PlayerTurn()
    {
        while (!_scoringSystem.IsGameEnd && !_player.IsStay)
        {
            _player.Scores.TotalPoints = _scoringSystem.DetermineAceValue(_player.OnHand);
            _printer.PrintPointsStatus(_player.Scores.TotalPoints, false);
            _printer.PrintOnHand(_player.OnHand);

            if (_player.Scores.TotalPoints >= 21)
            {
                _printer.PrintGameEnd(_scoringSystem);
                break;
            }

            _printer.PrintOption();
            PlayerAction(GetPlayerInput());
        }
    }
    
    private void DealerTurn()
    {
        _dealer.Hit();
        _dealer.Hit();
        
        while (!_scoringSystem.IsGameEnd)
        {
            _dealer.Scores.TotalPoints = _scoringSystem.DetermineAceValue(_dealer.OnHand);
            _printer.PrintPointsStatus(_dealer.Scores.TotalPoints, true);
            _printer.PrintOnHand(_dealer.OnHand);

            if (_dealer.Scores.TotalPoints >= 21)
            {
                _printer.PrintGameEnd(_scoringSystem);
                break;
            }
            
            DealerAction();
        }
    }

    public int GetPlayerInput()
    {
        var userInput = _reader.ReadValidInt();

         while (!(userInput is >= 0 and <= 1))
         {
             _printer.PrintInvalidUserInput();
             userInput = _reader.ReadValidInt();
         }

        return userInput;
    }

    public void PlayerAction(int userInput)
    {
        switch (userInput)
        {
            case 1:
                _player.AddCard(_dealer.DealCard());
                _printer.PrintCardDrawn(_player.OnHand, false);
                break;
            case 0:
                _player.IsStay = true;
                break;
        }
    }

    public void DealerAction()
    {
        Thread.Sleep(1000);
        
        if (_dealer.Scores.TotalPoints < 17)
        {
            _dealer.Hit();
            _printer.PrintCardDrawn(_dealer.OnHand, true);
        }
        else
        {
            _printer.PrintGameEnd(_scoringSystem);
        }
    }
}