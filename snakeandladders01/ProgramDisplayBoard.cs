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

namespace ProgramDisplayBoard;

partial class DisplayBoard
{
    static GameControl GameControl;
    public static void DrawBoard(GameControl gameControl)
    {
        int numRows = (int)Math.Ceiling((double)gameControl.GetBoardSize() / 10);
        for (int i = numRows; i >= 1; i--)
        {
            for (int j = 1; j <= 10; j++)
            {
                Console.Write(" ________");
            }
            Console.WriteLine();

            for (int k = 0; k <= 2; k++)
            {
                for (int j = 1; j <= 10; j++)
                {
                    int index;
                    if (i % 2 == 1)
                    {
                        index = ((i - 1) * 10) + j;
                    }
                    else
                    {
                        index = (i * 10) - j + 1;
                    }

                    if (index <= gameControl.GetBoardSize() && k == 0)
                    {
                        Console.Write($"|{index.ToString().PadLeft(2).PadRight(8)}");
                    }
                    else if (k == 1 && gameControl.GetBoard().GetSnake().ContainsKey(index))
                    {
                        if (gameControl.GetSnakeTail(index) < 10)
                        {
                            Console.Write("|");
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.Write($" [S-0{gameControl.GetSnakeTail(index)}] ");
                            Console.ResetColor();
                        }
                        else
                        {
                            Console.Write("|");
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.Write($" [S-{gameControl.GetSnakeTail(index)}] ");
                            Console.ResetColor();
                        }
                    }
                    else if (k == 1 && gameControl.GetBoard().GetSnake().ContainsValue(index))
                    {
                        Console.Write("|");
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.Write($" [S-{gameControl.GetSnakeHead(index)}] ");
                        Console.ResetColor();
                    }
                    else if (k == 1 && gameControl.GetBoard().GetLadder().ContainsKey(index))
                    {
                        Console.Write("|");
                        Console.ForegroundColor = ConsoleColor.Blue;
                        Console.Write($" [L-{gameControl.GetLadderTop(index)}] ");
                        Console.ResetColor();
                    }
                    else if (k == 1 && gameControl.GetBoard().GetLadder().ContainsValue(index))
                    {
                        if (gameControl.GetLadderBottom(index) < 10)
                        {
                            Console.Write("|");
                            Console.ForegroundColor = ConsoleColor.Blue;
                            Console.Write($" [L-0{gameControl.GetLadderBottom(index)}] ");
                            Console.ResetColor();
                        }
                        else
                        {
                            Console.Write("|");
                            Console.ForegroundColor = ConsoleColor.Blue;
                            Console.Write($" [L-{gameControl.GetLadderBottom(index)}] ");
                            Console.ResetColor();
                        }
                    }
                    else if (k == 2 && gameControl.GetPlayerPositions().ContainsValue(index))
                    {
                        List<Player> playersInPosition = gameControl.GetPlayersInPosition(index);
                        if (playersInPosition.Count > 0)
                        {
                            string playerInitials = "";
                            foreach (Player p in playersInPosition)
                            {
                                playerInitials += p.GetName()[0] + " ";
                            }
                            Console.Write("|");
                            Console.ForegroundColor = ConsoleColor.Yellow;
                            Console.Write($"{playerInitials.PadRight(8)}");
                            Console.ResetColor();
                        }
                        else
                        {
                            Console.Write("|        ");
                        }
                        // Player player = GetPlayerAtPosition(index);
                        // Console.Write($"|{player.GetName().Substring(0, 1)}     ");
                    }
                    else
                    {
                        Console.Write("|        ");
                    }
                }
                Console.WriteLine("|");
            }
            for (int j = 1; j <= 10; j++)
            {
                Console.Write("|________");
            }
            Console.WriteLine("|");
        }
    }
    public static void ConsoleOutputHandler(string message)
    {
        Console.WriteLine(message); // Menampilkan pesan ke konsol
    }

}

// partial class MovePlayerSet
// {
//     public static void MovePlayer(GameControl gameControl, Player player)
//     {
//         int currentPosition = gameControl.GetPlayerPosition(player);
//         int newPosition = currentPosition + gameControl.GetLastRollValue(player);
//         Console.WriteLine("newPosition: " + newPosition);

//         if (newPosition < gameControl.GetBoardSize())
//         {
//             Console.WriteLine($"Player {gameControl.GetPlayerName(player)} moves to position {newPosition}");
//             // Snake and Ladder encountered
//             if (gameControl.GetBoard().GetSnake().ContainsKey(newPosition))
//             {
//                 newPosition = gameControl.HandleSnakeEncounter(player, newPosition);
//                 Console.WriteLine("Snake");
//             }
//             else if (gameControl.GetBoard().GetLadder().ContainsKey(newPosition))
//             {
//                 newPosition = gameControl.HandleLadderEncounter(player, newPosition);
//                 Console.WriteLine("Ladder");
//             }
//         }
//         else if (newPosition > gameControl.GetBoardSize())
//         {
//             newPosition = gameControl.GetBoardSize() - (newPosition - gameControl.GetBoardSize());
//             Console.WriteLine($"Player {gameControl.GetPlayerName(player)} exceeded the target position. Moving back to position {newPosition}");
//         }
//         else if (newPosition == gameControl.GetBoardSize())
//         {
//             foreach (var p in gameControl.GetPlayersAtFinished())
//             {
//                 Console.WriteLine($"Player Name {gameControl.GetPlayerName(p)} Player ID {gameControl.GetPlayerID(p)}"); 
//             }
//         }
//         gameControl.SetPlayerPosition(player, newPosition);
//         Console.WriteLine($"Player {gameControl.GetPlayerName(player)} at position {newPosition}");
//     }
// }