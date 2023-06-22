namespace DiceLib;
using IDiceLib;

public class Dice : IDice
{
    private int _numberOfSides;
    private Random _random;

    public Dice(int numberOfSides)
    {
        _numberOfSides = numberOfSides;
        _random = new Random();
    }
    public int numberOfSides
    {
        get { return _numberOfSides; }
        set { _numberOfSides = value; }
    }
    public int GetRoll()
    {
        return _random.Next(1, _numberOfSides + 1);
    }
}