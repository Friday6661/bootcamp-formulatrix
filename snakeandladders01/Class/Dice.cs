using IDiceLib;
namespace DiceLib;
public class Dice : IDice
{
    private int _numberOfSides;
    //private Random _random;

    public Dice(int numberOfSides)
    {
        _numberOfSides = numberOfSides;
    //    _random = new Random();
    }
    public int GetNumberOfSides()
    {
        return _numberOfSides;
    }
    public bool SetNumberOfSides(int numberOfSides)
    {
        if (numberOfSides > 0)
        {
            _numberOfSides = numberOfSides;
            return true;
        }
        return false;
    }
    public int GetRoll()
    {
        Random random = new Random();
        return random.Next(1, _numberOfSides + 1);
    }
}