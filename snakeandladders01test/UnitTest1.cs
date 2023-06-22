namespace snakeandladders01test;
using GameControlLib;

public class UnitTest1
{
    [Fact]
    public void Test1()
    {
        GameControl gameControl = new GameControl();
        bool result = gameControl.SetPlayerName("d");
        Assert.False(result, "input can't set player name");

    }
}