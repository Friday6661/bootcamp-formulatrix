namespace DiceLib;
using IDiceLib;
using NewGameRunnerLib;

public class Dice : IDice
{
    private int _numberOfSides;
    private Random _random;

    public int numberOfSides
    {
        get { return _numberOfSides; }
        set { _numberOfSides = value; }
    }
    public Dice(int numberOfSides)
    {
        _numberOfSides = numberOfSides;
        _random = new Random();
    }

    public int GetRoll()
    {
        return _random.Next(1, _numberOfSides + 1);
    }
}