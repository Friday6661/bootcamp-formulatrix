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

// partial class PlayerSetup
// {
//     static GameControl gameControl = new GameControl();

//     public static int GetPlayersFromUser()
//     {
//         Console.Clear();
//         Console.WriteLine("==============[Setup Player]==============");
//         int numberOfPlayers;
//         while (true)
//         {
//             Console.WriteLine("Enter the number of players (2-4): ");
//             string input = Console.ReadLine();
//             if (int.TryParse(input, out numberOfPlayers) && gameControl.SetInputNumberOfPlayers(numberOfPlayers) == true)
//             {
//                 Console.WriteLine("Input number of players is succesfully");
//                 break;
//             }
//             else
//             {
//                 Console.WriteLine("Invalid input, Please enter a valid number of players");
//             }
//         }
//         for (int i = 1; i <= numberOfPlayers; i++)
//         {
//             while (gameControl.GetPlayersCount() < numberOfPlayers)
//             {
//                 Console.Write($"Enter the Name of Players {i}: ");
//                 string name = Console.ReadLine().ToUpper();
//                 if (name.Length > 2)
//                 {
//                     gameControl.AddPlayer(name.ToUpper());
//                     Console.Write($"Input Player {i} is Success ");
//                     Console.WriteLine($"Player Name: {name}");
//                 }
//                 else
//                 {
//                     Console.WriteLine("Invalid Input! Try again");
//                 }
//             }
//             foreach (var player in gameControl.GetPlayers())
//             {
//                 Console.WriteLine($"Player Name: {gameControl.GetPlayerName(player)}");
//                 Console.WriteLine($"Player ID: {gameControl.GetPlayerID(player)}");
//             }
//             break;
//         }
//         return numberOfPlayers;
//     }
// }
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
}
