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
        int playerCount = 0;
        bool isValidInput = false;
        while (!isValidInput)
        {
            Console.Write("Enter the number of players (2-4): ");
            string input = Console.ReadLine();
            if (int.TryParse(input, out playerCount) && playerCount >= 2 && playerCount <= 4)
            {
                isValidInput = true;
            }
            else
            {
                Console.WriteLine("Invalid input. Please enter a valid number of players.");
            }
        }
        return playerCount;
    }

    public static void GetPlayerNames(int playerCount)
    {
        for (int i = 1; i <= playerCount; i++)
        {
            while (true)
            {
                Console.Write($"Enter the Name of Player {i}: (at least 2 characters): ");
                string name = Console.ReadLine();
                if (name.Length >= 2)
                {
                    IPlayer player = new Player(name);
                    gameControl.SetPlayerName(player, name);
                    gameControl.AddPlayer(player.GetName());
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

