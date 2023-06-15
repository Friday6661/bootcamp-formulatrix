namespace DisplayLib;
using NewGameRunnerLib;
using PlayerLib;

class Display
{
    private NewGameRunner _gameRunner;

    public Display(NewGameRunner gameRunner)
    {
        _gameRunner = gameRunner;
        _gameRunner.DisplayMessage += DisplayMessageHandler;
    }

    public void DisplaySetup()
    {
        _gameRunner.SetupPlayer();
        Console.WriteLine("Press Enter! to Start the Game");
        Console.ReadLine();
        Console.Clear();
        _gameRunner.StartGame();
    }
    private void DisplayMessageHandler(string message)
    {
        Console.WriteLine(message);
    }
}