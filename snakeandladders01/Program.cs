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
using ProgramMovePlayerLib;

namespace SnakesAndLadders
{
    partial class Program
    {
        
        static void Main(string[] args)
        {
            Console.Clear();
            GameControl gameControl = new GameControl();
            int playerCount = PlayerSetup.GetInputNumberPlayers(gameControl);
            PlayerSetup.GetInputPlayerName(gameControl,playerCount);
            int boardSetup = BoardSetup.GetBoardFromUser(gameControl);
            int diceSetup = DiceSetup.GetDiceFromUserInput(gameControl);
            Console.Clear();
            Console.WriteLine("===========[Main Program]===========");
            Console.WriteLine("Number of players: " + playerCount);
            PlayerSetup.GetPlayerInfo(gameControl);
            Console.WriteLine("Sum of Cell on Board: " + boardSetup);
            Console.WriteLine("Number of sides: " + diceSetup);
            Console.ReadLine();
            Console.Clear();
            Console.WriteLine("================================[ Start Game ]================================");
            while (!gameControl.SetGameFinished())
            {
                foreach (Player player in gameControl.GetPlayers())
                {
                    bool roolAgain = true;
                    int totalRolls = 0;
                    while (roolAgain && totalRolls <2)
                    {
                        gameControl.RollDice(player);
                        Console.ReadLine();
                        Console.WriteLine($"Player {gameControl.GetPlayerName(player)} rolled the dice and got a {gameControl.GetLastRollValue(player)} ");
                        MovePlayerSet.MovePlayer(gameControl, player);
                        // Console.WriteLine($"Player {gameControl.GetPlayerName(player)} Positioned {gameControl.GetPlayerPosition(player)}");
                        // Display Board
                        if (gameControl.GetRollAgain(player))
                        {
                            Console.WriteLine("Player get roll again!");
                            Console.ReadLine();
                            break;
                        }
                        else
                        {
                            roolAgain = false;
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