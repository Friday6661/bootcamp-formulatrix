using BoardLib;
using IBoardLib;
using DiceLib;
using IDiceLib;
using PlayerLib;
using IPlayerLib;
using GameControlLib;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using ProgramSetupPlayerLib;
using ProgramSetupBoardLib;
using ProgramSetupDiceLib;

namespace SnakesAndLadders
{
    partial class Program
    {
        static GameControl gameControl = new GameControl();
        static void Main(string[] args)
        {
            int playerCount = PlayerSetup.GetInputNumberPlayers();
            List<string> playerNames = PlayerSetup.GetInputPlayerName(playerCount);
            int boardSetup = BoardSetup.GetBoardFromUser();
            int diceSetup = DiceSetup.GetDiceFromUserInput();
            Console.WriteLine("===========[Main Program]===========");
            Console.WriteLine("Number of players: " + playerCount);
            foreach (string playerName in playerNames)
            {
                Console.WriteLine("Player Name: " + playerName);
            }
            Console.WriteLine("Sum of Cell on Board: " + boardSetup);
            Console.WriteLine("Number of sides: " + diceSetup);
            Console.ReadLine();
            Console.Clear();
            Console.WriteLine("================================[ Start Game ]================================");
            while (!gameControl.SetGameFinished())
            {
                foreach(Player player in gameControl.GetPlayers())
                {
                    Console.WriteLine(gameControl.GetPlayerName(player), gameControl.GetPlayerPosition(player));
                    Console.ReadLine();
                    bool rollAgain = true;
                    int totalRolls = 0;
                    while (rollAgain && totalRolls < 2)
                    {
                        gameControl.RollDice(player);
                        gameControl.MovePlayer(player);
                        totalRolls++;
                        if (gameControl.SetRollAgain(player, rollAgain) == true)
                        {
                            Console.WriteLine($"Player {player.GetName()} rolled a dice and got a {gameControl.GetNumberOfSides()}! Roll the dice again");
                            Console.ReadLine();
                        }
                        else
                        {
                            rollAgain = false;
                            gameControl.SetRollAgain(player, rollAgain);
                        }
                    }
                }
            }
            Console.ReadLine();
        }
    }
}
// class Program
// {
//     static void Main(string[] args)
//     {
//         GameControl _gameControl = new GameControl();
//         _gameControl.AddPlayer("John");
//         _gameControl.AddPlayer("Benjamin");
//         foreach (Player player in _gameControl.GetPlayers())
//         {
//             Console.WriteLine($"Player {player.GetName()}");
//         }
//         Console.Clear();
//         int numberOfPlayer = _gameControl.GetPlayersCount();
//         while(true)
//         {
//             Console.Write("Enter the number of players (2-4): ");
//             string input = Console.ReadLine();
//             if (int.TryParse(input, out numberOfPlayer))
//             {
//                 if (_gameControl.SetInputNumberOfPlayers(numberOfPlayer) == true)
//                 {
//                     break;
//                 }
//                 else
//                 {
//                     Console.WriteLine("Input Player Out of Range. Please Input Again: ");
//                 }
//             }
//             else
//             {
//                 Console.WriteLine("Invalid input. Please enter a valid number of players.");
//             }
//         }
//         for (int i = 1; i <= numberOfPlayer; i++)
//         {
//             while (true)
//             {
//                 Console.Write($"Enter the Name of Player {i}: (at least 2 characters): ");
//                 string name = Console.ReadLine();
//                 if (name.Length >= 2)
//                 {
//                     _gameControl.AddPlayer(name.ToUpper());
//                     //gameControl.SetPlayerName(gameControl.name);
//                     break;
//                 }
//                 else
//                 {
//                     Console.WriteLine("Invalid input for player name. Try Again!");
//                 }
//             }
//         }
//             Console.Clear();
//             Console.WriteLine("===========[Main Program]===========");
//             Console.WriteLine("Number of players: " + numberOfPlayer);
//             Console.WriteLine("List of Player: ");
//             foreach(Player player in _gameControl.GetPlayers())
//             {
//                 Console.WriteLine("Player Name: " + _gameControl.GetPlayerName(player));
//             }
//     }
// }