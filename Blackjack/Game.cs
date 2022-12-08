namespace Blackjack;

public class Game
{
    private Player _human;
    private Player _dealer;
    private readonly IDeck _deck;
    private readonly Scoring _scoringSystem;
    private readonly Printer _printer;
    private readonly UserValidation _userValidation;

    public Game(IWriter writer, IReader reader, IDeck deck)
    {
        _dealer = new Player()
        {
            IsDealer = true
        };
        _human = new Player();
        _deck = deck;
        _scoringSystem = new Scoring(_human, _dealer);
        _printer = new Printer(writer);
        _userValidation = new UserValidation(reader, writer);
    }

    public void Play()
    {
        StartHand(_human);
        PlayGame(_human);

        if (!_scoringSystem.IsGameEnd)
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

    private void HumanAction(Player player, int userInput)
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

    private void DealerAction(Player player)
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