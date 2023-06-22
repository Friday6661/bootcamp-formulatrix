namespace IPlayerLib;

public interface IPlayer
{
    string GetId();
    string GetName();
    void SetName(string name);
}