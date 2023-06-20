using IBoardLib;
using IDiceLib;
using IPlayerLib;
using DiceLib;
using BoardLib;
using PlayerLib;
using GameControlLib;
using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        // Membuat objek GameControl
        GameControl gameControl = new GameControl();

        // Menambahkan pemain ke GameControl
        List<IPlayer> players = new List<IPlayer>()
        {
            new Player("Player 1"),
            new Player("Player 2")
        };
        bool isSetPlayersSuccess = gameControl.SetPlayers(players);
        if (isSetPlayersSuccess)
        {
            Console.WriteLine("Players added successfully!");
        }
        else
        {
            Console.WriteLine("Failed to set players. Invalid number of players.");
        }

        // Mengatur dadu
        Dice dice = new Dice(6);
        bool isSetDiceSuccess = gameControl.SetDice(dice);
        if (isSetDiceSuccess)
        {
            Console.WriteLine("Dice set successfully!");
        }
        else
        {
            Console.WriteLine("Failed to set dice. Dice object is null.");
        }

        // Mengatur papan
        Board board = new Board(100);
        bool isSetBoardSuccess = gameControl.SetBoard(board);
        if (isSetBoardSuccess)
        {
            Console.WriteLine("Board set successfully!");
        }
        else
        {
            Console.WriteLine("Failed to set board. Board object is null.");
        }

        // Mengakses pemain dan dadu
        List<IPlayer> retrievedPlayers = gameControl.GetPlayers();
        Dice retrievedDice = gameControl.GetDice();

        Console.WriteLine($"Number of players: {retrievedPlayers.Count}");
        Console.WriteLine($"Number of sides on the dice: {retrievedDice.GetNumberOfSides()}");
    }
}
