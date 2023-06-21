using BoardLib;
using IBoardLib;
using DiceLib;
using IDiceLib;
using PlayerLib;
using IPlayerLib;
using GameControlLib;
using System.Threading;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace ProgramSetupPlayerLib;

partial class BoardSetup
{
    static GameControl gameControl = new GameControl();
    static Dictionary<int, int> snakes = new Dictionary<int, int>()
    {
        {16, 6},
        {30, 15},
        {47, 26},
        {49, 11}
    };
    static Dictionary<int, int> ladders = new Dictionary<int, int>()
    {
        {2, 17},
        {12, 32},
        {25, 42},
        {13, 48},
    };

    public static int GetBoardFromUser()
    {
        gameControl.SetLadder(ladders);
        gameControl.SetSnake(snakes);
        //gameControl(ladders,snake);
        Console.Clear();
        Console.WriteLine("==============[Setup Board]==============");
        int boardSize = 0;
        while (gameControl.SetBoard(boardSize) == false)
        {
            Console.Write("Input the Number of cell on a Board: ");
            string input = Console.ReadLine();
            if (int.TryParse(input, out boardSize) && gameControl.SetBoard(boardSize) == true)
            {
                gameControl.SetBoard(boardSize);
                Console.WriteLine("Setup Board Succesfully");
            }
            else
            {
                Console.WriteLine("Invalid input. Pleas enter a valid number cell on a Board");
            }
        }
        return boardSize;
    }
}
