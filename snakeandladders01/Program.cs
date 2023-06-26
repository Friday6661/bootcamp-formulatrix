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
using ProgramDisplayBoard;

namespace SnakesAndLadders
{
    partial class Program
    {
        
        static void Main(string[] args)
        {
            Console.Clear();
            GameControl gameControl = new GameControl();
            int playerCount = PlayerSetup.GetInputNumberPlayers(gameControl);
            PlayerSetup.GetInputPlayerName(gameControl, playerCount);
            DisplayBoard.DrawBoard(gameControl);
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
            while (!gameControl.SetGameFinished())
            {
                foreach (Player player in gameControl.GetPlayers())
                {
                    Console.ReadLine();
                    Console.Clear();
                    Console.WriteLine("======================[Snakes and Ladders]=========================");
                    if (gameControl.GetPlayerPosition(player) != gameControl.GetBoardSize())
                    {
                        bool roolAgain = true;
                        int totalRolls = 0;
                        while (roolAgain && totalRolls <=2)
                        {
                            Console.WriteLine($"Player {gameControl.GetPlayerName(player)} rolling dice");
                            gameControl.RollDice(player);
                            Console.ReadLine();
                            Console.Write($"Player {gameControl.GetPlayerName(player)} rolled the dice and got a {gameControl.GetLastRollValue(player)} and move from {gameControl.GetPlayerPosition(player)}");
                            gameControl.MovePlayer(player);
                            Console.WriteLine($" to {gameControl.GetPlayerPosition(player)}");
                            DisplayBoard.DrawBoard(gameControl);
                            // Console.WriteLine($"Player {gameControl.GetPlayerName(player)} Positioned {gameControl.GetPlayerPosition(player)}");
                            // Display Board
                            if (gameControl.GetRollAgain(player))
                            {
                                Console.WriteLine($"Player {gameControl.GetPlayerName(player)} get roll again!");
                                // Console.Write($"Player {gameControl.GetPlayerName(player)} got a {gameControl.GetLastRollValue(player)} and move to {gameControl.GetPlayerPosition(player) + gameControl.GetLastRollValue(player)}");
                                Console.ReadLine();
                            }
                            else
                            {
                                roolAgain = false;
                            }
                        }
                    }
                }
            }
            foreach (Player player in gameControl.GetPlayersAtFinished())
            {
                for(int i = 1; i <= gameControl.GetPlayersAtFinished().Count(); i++)
                {
                    Console.WriteLine($"Player {gameControl.GetPlayerName(player)} Finished at position {i}");
                }
            }
            Console.ReadLine();
        }
    }
}