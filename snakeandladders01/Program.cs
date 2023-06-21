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

namespace SnakesAndLadders
{
    partial class Program
    {
        static GameControl gameControl = new GameControl();
        static void Main(string[] args)
        {
            int playerCount = PlayerSetup.GetPlayersFromUser();
            PlayerSetup.GetPlayerNames(playerCount);
            int boardSetup = BoardSetup.GetBoardFromUser();
            Console.Clear();
            Console.WriteLine("===========[Main Program]===========");
            Console.WriteLine("Number of players: " + playerCount);
            Console.WriteLine("Player names:");
            // foreach (var player in gameControl.GetPlayer(gameControl.))
            // {
            //     Console.WriteLine(gameControl.GetPlayerName(player));
            // }
            // Console.WriteLine("Sum of Cell on Board: " + boardSetup);

            // Console.ReadLine();
        }
    }
}