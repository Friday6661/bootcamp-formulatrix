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

namespace ProgramSetupDiceLib;

partial class DiceSetup
{
    static GameControl gameControl = new GameControl();
    public static int GetDiceFromUserInput()
    {
        Console.Clear();
        Console.WriteLine("==============[Setup Board]==============");
        int numberOfSides = 0;
        while (gameControl.SetDice(numberOfSides) == false)
        {
            Console.WriteLine("Enter the number of sides of the dice: ");
            string input = Console.ReadLine();
            if (int.TryParse(input, out numberOfSides) && gameControl.SetDice(numberOfSides) == true)
            {
                gameControl.SetDice(numberOfSides);
                Console.WriteLine("Setup Dice Successfully");
            }
            else
            {
                Console.WriteLine("Invalid input. Please enter a valid number of sides!");
            }
        }
        return numberOfSides;
    }
}
