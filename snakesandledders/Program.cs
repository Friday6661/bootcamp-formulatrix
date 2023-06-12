using System;
using System.Collections.Generic;
using BoardLib;
using IBoardLib;
using PlayerLib;
using IPlayerLib;
using DiceLib;
using IDiceLib;

class Program
{
    static void Main()
    {
        Board board = new Board(100);
        board.AddSnake(41,40);
        board.AddSnake(42,39);
        board.AddSnake(43,38);
        board.AddSnake(44,37);
        board.AddSnake(45,36);
        board.AddSnake(46,35);
        board.AddSnake(47,34);
        board.AddLadder(1, 20);
        board.AddLadder(2, 19);
        board.AddLadder(3, 18);
        board.AddLadder(4, 17);
        board.AddLadder(5, 16);
        board.AddLadder(6, 15);
        board.AddLadder(7, 14);
        board.AddLadder(8, 13);

        // Membuat beberapa pemain
        Player player1 = new Player(1, "John");
        Player player2 = new Player(2, "Jane");
        Player player3 = new Player(3, "Mike");

        GameRunner gameRunner = new GameRunner(board);

        // Menambahkan pemain ke GameRunner
        gameRunner.AddPlayer(player1);
        gameRunner.AddPlayer(player2);
        gameRunner.AddPlayer(player3);
        
        // Memulai permainan
        Console.WriteLine("Press any key to start the game...");
        Console.ReadLine();

        gameRunner.StartGame();

        // Melakukan roll dice
        Console.WriteLine("Press any key to roll the dice...");
        Console.ReadLine();

        foreach (Player player in gameRunner.GetPlayers())
        {
            gameRunner.RollDice(player);
            gameRunner.MoveForward(player);
        }

        Console.ReadLine();
    }
}
