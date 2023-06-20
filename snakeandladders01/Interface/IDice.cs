namespace IDiceLib;

public interface IDice
{
    int GetNumberOfSides();
    bool SetNumberOfSides(int numberOfSides);
    int GetRoll();
}