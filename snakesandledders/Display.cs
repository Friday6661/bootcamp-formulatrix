namespace DisplayLib;
using GameRunnerLib;
using PlayerLib;

class Display
{
    private GameRunner _gameRunner;

    public Display(GameRunner gameRunner)
    {
        _gameRunner = gameRunner;
        _gameRunner.DisplayMessage += DisplayMessageHandler;
    }

    public void Start()
    {
        Console.WriteLine("Enter the Number of players: ");
        int playerCount = GetPlayerCountFromInput();
        Console.Clear();

        GetPlayerNames(playerCount);
        Console.Clear();

        ShowPlayerList();
        Console.WriteLine("Press Enter to Start the Game");
        Console.ReadLine();
        _gameRunner.StartGame();
    }
    private int GetPlayerCountFromInput()
    {
        int playerCount;
        while (!int.TryParse(Console.ReadLine(), out playerCount))
        {
            Console.WriteLine("Invalid input. Please enter a valid number.");
        }
        return playerCount;
    }
    private void GetPlayerNames(int playerCount)
    {
        for (int i = 1; i <= playerCount; i++)
        {
            Console.WriteLine($"Enter the Name of players {i} : ");
            string name = Console.ReadLine();
            _gameRunner.AddPlayer(name);
            Console.Clear();
        }
    }
    private void ShowPlayerList()
    {
        Console.WriteLine("List of Players: ");
        foreach (Player player in _gameRunner.GetPlayers())
        {
            Console.WriteLine($"Player Name: {player.GetName()}");
        }
    }
    private void DisplayMessageHandler(string message)
    {
        Console.WriteLine(message);
    }
}