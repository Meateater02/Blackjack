namespace Blackjack;

public class Game
{
    public Player _human { get; set; }
    public Player _dealer { get; set; }
    public Deck _deck { get; }
    private readonly Scoring _scoringSystem;
    private readonly Printer _printer;
    private readonly UserValidation _userValidation;

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
        _userValidation = new UserValidation(new ConsoleReader(), new ConsoleWriter());
    }

    public void Play()
    {
        _deck.ShuffleDeck();
        StartHand(_human);
        PlayGame(_human);
        StartHand(_dealer);
        PlayGame(_dealer);
    }

    private void StartHand(Player player)
    {
        player.AddCard(_deck.DealCard());
        player.AddCard(_deck.DealCard());
    }

    private void PlayGame(Player player)
    {
        while (!_scoringSystem.IsGameEnd && !player.IsStay)
        {
            player.Scores.TotalPoints = _scoringSystem.DetermineAceValue(player.OnHand);
            _printer.PrintPointsStatus(player);
            _printer.PrintOnHand(player.OnHand);
            
            if (player.Scores.TotalPoints >= 21)
            {
                _printer.PrintGameEnd(_scoringSystem);
                break;
            }

            if (!_scoringSystem.IsGameEnd && !player.IsDealer)
            {
                HumanAction(player, _userValidation.GetPlayerMove());
            }
            else if (!_scoringSystem.IsGameEnd && player.IsDealer)
            {
                DealerAction(player);
            }
        }
    }

    public void HumanAction(Player player, int userInput)
    {
        switch (userInput)
        {
            case 1:
                player.AddCard(_deck.DealCard());
                _printer.PrintCardDrawn(player);
                break;
            case 0:
                player.IsStay = true;
                break;
        }

        _human = player;
    }

    public void DealerAction(Player player)
    {
        Thread.Sleep(1000);
        
        if (player.Scores.TotalPoints < 17)
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