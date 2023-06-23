using BoardLib;
using IBoardLib;
using DiceLib;
using IDiceLib;
using PlayerLib;
using IPlayerLib;
using GameControlLib;
using System.Threading;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace ProgramSetupPlayerLib;
partial class PlayerSetup
{
    //static GameControl gameControl = new GameControl();
    public static int GetInputNumberPlayers(GameControl gameControl)
    {
        Console.Clear();
        Console.WriteLine("==============[Setup Player]==============");
        int numberOfPlayers = 0;
        while (gameControl.SetNumberOfPlayers(numberOfPlayers) == false)
        {
            Console.Write("Enter the number of players (2-4): ");
            string input = Console.ReadLine();
            if (int.TryParse(input, out numberOfPlayers) && gameControl.SetNumberOfPlayers(numberOfPlayers))
            {
                Console.WriteLine("Input number of player success");
                Console.WriteLine($"Number of players {numberOfPlayers}");
                Console.ReadLine();
                break;
            }
            Console.WriteLine("Invalid input number. Try again!");
        }
        return numberOfPlayers;
    }
    public static void GetInputPlayerName(GameControl gameControl, int numberOfPlayers)
    {
        Console.Clear();
        Console.WriteLine("==============[Setup Player]==============");
        // List <string> playersNames = new List<string>();
        // List<Player> players;
        for (int i = 1; i <= numberOfPlayers; i++)
        {
            while (true)
            {
                Console.Write($"Enter the Name of Player {i}: ");
                string name = Console.ReadLine();
                // if (gameControl.SetPlayerName(name.ToUpper()))
                if (name.Length > 2)
                {
                    gameControl.AddPlayer(name.ToUpper());
                    Console.WriteLine($"Input player {i} Success");
                    break;
                }
                else
                {
                    Console.WriteLine("Invalid input name. Try Again!");
                }
            }
        }
    }
    public static void GetPlayerInfo(GameControl gameControl)
    {
        foreach (var player in gameControl.GetPlayers())
        {
            string playerName = gameControl.GetPlayerName(player);
            string playerID = gameControl.GetPlayerID(player);
            Console.WriteLine($"Player Name: {playerName}, Player ID: {playerID}");
        }
    }
}
