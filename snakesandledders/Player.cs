namespace PlayerLib;
using IPlayerLib;

public class Player : IPlayer
{
    private int _id;
    private string _name;
    private int _position;
    private int _lastRoll;

    public Player(int id, string name)
    {
        _id = id;
        _name = name;
        _position = 1;
        _lastRoll = 0;
    }

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

    public int GetPosition()
    {
        return _position;
    }

    public void SetPosition(int position)
    {
        _position = position;
    }

    public int GetLastRoll()
    {
        return _lastRoll;
    }

    public void SetLastRoll(int roll)
    {
        _lastRoll = roll;
    }
}