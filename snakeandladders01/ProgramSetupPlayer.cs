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
    static GameControl gameControl = new GameControl();

    public static int GetPlayersFromUser()
    {
        Console.Clear();
        Console.WriteLine("==============[Setup Player]==============");
        int numberOfPlayer = gameControl.GetPlayersCount();
        //bool isValidInput = false;
        while (!gameControl.SetInputNumberOfPlayers(numberOfPlayer))
        {
            Console.Write("Enter the number of players (2-4): ");
            string input = Console.ReadLine();
            if (int.TryParse(input, out numberOfPlayer) && gameControl.SetInputNumberOfPlayers(numberOfPlayer) == true)
            {
                Console.Clear();
                Console.WriteLine("Input number of players is successfully");
            }
            else
            {
                Console.WriteLine("Invalid input. Please enter a valid number of players.");
            }
        }
        return numberOfPlayer;
    }

    public static void GetPlayerNames(int numberOfPlayer)
    {
        for (int i = 1; i <= numberOfPlayer; i++)
        {
            while (true)
            {
                Console.Write($"Enter the Name of Player {i}: (at least 2 characters): ");
                string name = Console.ReadLine();
                if (name.Length >= 2)
                {
                    gameControl.AddPlayer(name);
                    //gameControl.SetPlayerName(gameControl.name);
                    break;
                }
                else
                {
                    Console.WriteLine("Invalid input for player name. Try Again!");
                }
            }
        }
    }
}

