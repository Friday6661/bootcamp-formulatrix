using System;

namespace SnakeAndLadders
{
    class Program
    {
        static void Main(string[] args)
        {
            int boardSize = 100;
            int playerPosition = 25; // contoh posisi pemain

            DrawBoard(boardSize, playerPosition);
            Console.ReadLine();
        }

        static void DrawBoard(int boardSize, int playerPosition)
        {
            int numRows = (int)Math.Ceiling((double)boardSize / 10);

            for (int i = numRows; i >= 1; i--)
            {
                // Baris atas petak
                for (int j = 1; j <= 10; j++)
                {
                    Console.Write(" _____");
                }
                Console.WriteLine();

                // Isi petak
                for (int k = 0; k < 3; k++)
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

                        if(index <= boardSize && k == 0)
                        {
                            // Ratakan teks di tengah petak dengan menggunakan PadLeft dan PadRight
                            Console.Write($"|{index.ToString().PadLeft(3).PadRight(5)}");
                        }
                        else if(index == playerPosition && k == 2)
                        {
                            // Jika ini adalah posisi pemain dan kita berada di baris kedua kotak
                            Console.Write("| oo  ");
                        }
                        else
                        {
                            Console.Write("|     "); // Petak kosong jika index melebihi boardSize atau baris kedua dan ini bukan posisi pemain
                        }
                    }
                    Console.WriteLine("|");
                }

                // Baris bawah petak
                for (int j = 1; j <= 10; j++)
                {
                    Console.Write("|_____");
                }
                Console.WriteLine("|");
            }
        }
    }
}
