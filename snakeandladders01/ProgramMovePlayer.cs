using BoardLib;
using IBoardLib;
using DiceLib;
using IDiceLib;
using PlayerLib;
using IPlayerLib;
using CellTypeLib;
using GameControlLib;
using System.Threading;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace ProgramMovePlayerLib;

partial class MovePlayerSet
{
    public static void MovePlayer(GameControl gameControl, Player player)
    {
        int currentPosition = gameControl.GetPlayerPosition(player);
        int newPosition = currentPosition + gameControl.GetLastRollValue(player);
        if (newPosition < gameControl.GetBoardSize())
        {
            Console.WriteLine($"Player {gameControl.GetPlayerName(player)} moves to position {newPosition}");
            // Snake and Ladder encountered
        }
        else if (newPosition > gameControl.GetBoardSize())
        {
            newPosition = gameControl.GetBoardSize() - (newPosition - gameControl.GetBoardSize());
            Console.WriteLine($"Player {gameControl.GetPlayerName(player)} exceeded the target position. Moving back to position {newPosition}");
        }
        else if (newPosition == gameControl.GetBoardSize())
        {
            foreach (var p in gameControl.GetPlayersAtFinished())
            {
                Console.WriteLine($"Player Name {gameControl.GetPlayerName(p)} Player ID {gameControl.GetPlayerID(p)}"); 
            }
        }
        gameControl.SetPlayerPosition(player, newPosition);
        Console.WriteLine($"Player {gameControl.GetPlayerName(player)} at position {newPosition}");
    }
}