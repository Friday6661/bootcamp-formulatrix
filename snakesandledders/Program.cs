using System;
using BoardLib;
using DiceLib;
using PlayerLib;
using TileTypesLib;

public class Program
{
    public static void Main(string[] args)
    {
        // Membuat objek board
        Board board = new Board(100);

        // Menambahkan snakes dan ladders secara otomatis
        for (int i = 0; i < 10; i++)
        {
            board.AddSnake();
            board.AddLadder();
        }

        // Membuat objek dadu dengan 6 sisi
        Dice dice = new Dice(6);

        // Membuat array pemain
        Player[] players = new Player[4];

        // Menginisialisasi pemain
        players[0] = new Player();
        players[1] = new Player();
        players[2] = new Player();
        players[3] = new Player();

        // Mengatur id, nama, dan level untuk setiap pemain
        players[0].SetId(1);
        players[0].SetName("Player 1");
        players[0].SetLevel(1);

        players[1].SetId(2);
        players[1].SetName("Player 2");
        players[1].SetLevel(1);

        players[2].SetId(3);
        players[2].SetName("Player 3");
        players[2].SetLevel(1);

        players[3].SetId(4);
        players[3].SetName("Player 4");
        players[3].SetLevel(1);

        // Melakukan giliran untuk setiap pemain
        foreach (Player player in players)
        {
            Console.WriteLine("Player {0} turn:", player.GetName());

            // Menggulir dadu dan memperbarui posisi pemain
            int roll = dice.GetRoll();
            int currentPosition = 0;
            int newPosition = currentPosition + roll;

            Console.WriteLine("Player {0} rolled {1}. Moving from position {2} to position {3}.",
                player.GetName(), roll, currentPosition, newPosition);

            // Memeriksa tile type di posisi baru
            TileType tileType = board.GetTileType(newPosition);
            Console.WriteLine("Tile type at position {0} is {1}.", newPosition, tileType);

            Console.WriteLine();
        }
    }
}
