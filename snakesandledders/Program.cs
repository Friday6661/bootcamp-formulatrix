using IDiceLib;
using DiceLib;

public class Program
{
    public static void Main(string[] args)
    {
        IDice dice = new Dice(8);

        int rollResult = dice.Roll();
        Console.WriteLine("Roll Result: " + rollResult);
    }
}