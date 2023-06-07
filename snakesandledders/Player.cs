namespace playerLib;
using IPlayerLib;

public class Player : IPlayer
{
    private int _id;
    private string _name;
    private int _level;

    public int GetId()
    {
        return _id;
    }

    public void SetId(int id)
    {
        _id = id;
    }

    public string GetName()
    {
        return _name;
    }

    public void SetName(string name)
    {
        _name = name;
    }

    public int GetLevel()
    {
        return _level;
    }

    public void SetLevel(int level)
    {
        _level = level;
    }
}