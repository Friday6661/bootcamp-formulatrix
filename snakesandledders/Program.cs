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
        // Membuat objek GameRunner
        GameRunner gameRunner = new GameRunner();
        gameRunner.SetBoardSize(100);

        // Membuat beberapa pemain
        Player player1 = new Player(1, "John");
        Player player2 = new Player(2, "Jane");
        Player player3 = new Player(3, "Mike");

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
