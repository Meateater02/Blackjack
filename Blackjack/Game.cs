namespace Blackjack;

public class Game
{
    private Player _human { get; set; }
    private Player _dealer { get; set; }
    private Deck _deck { get; }
    private readonly Scoring _scoringSystem;
    private readonly Printer _printer;
    private readonly UserValidation _userValidation;

    public Game(IWriter writer, IReader reader, IRandomiser randomiser)
    {
        _dealer = new Player()
        {
            IsDealer = true
        };
        _human = new Player();
        _deck = new Deck(randomiser);
        _scoringSystem = new Scoring(_human, _dealer);
        _printer = new Printer(writer);
        _userValidation = new UserValidation(reader, writer);
    }

    public void Play()
    {
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
            player.DetermineAceValue();
            //player.Scores.TotalPoints = _scoringSystem.DetermineAceValue(player.OnHand);
            _printer.PrintPointsStatus(player);
            _printer.PrintOnHand(player.OnHand);
            _printer.PrintGameEnd(_scoringSystem);

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