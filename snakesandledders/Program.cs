using System;
using System.Collections.Generic;
using BoardLib;
using IBoardLib;
using PlayerLib;
using IPlayerLib;
using DiceLib;
using IDiceLib;
using DisplayLib;
using NewGameRunnerLib;

namespace SnakesandLadders
{
    static class Program
    {
        static void Main()
        {
            Board board = new(100);
            board.AddSnake(41, 40);
            board.AddSnake(42, 39);
            board.AddSnake(43, 38);
            board.AddSnake(44, 37);
            board.AddSnake(45, 36);
            board.AddSnake(46, 35);
            board.AddSnake(47, 34);
            board.AddLadder(1, 20);
            board.AddLadder(2, 19);
            board.AddLadder(3, 18);
            board.AddLadder(4, 17);
            board.AddLadder(5, 16);
            board.AddLadder(6, 15);
            board.AddLadder(7, 14);
            board.AddLadder(8, 13);
            board.AddLadder(40,99);

            NewGameRunner gameRunner = new(board);

            // Memulai permainan
            Display display = new(gameRunner);
            display.Start();

            Console.ReadLine();
        }
    }
}