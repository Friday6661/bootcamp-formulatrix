namespace IPlayerLib;

public interface IPlayer
{
    string GetId();
    string GetName();
    bool SetName(string name);
}