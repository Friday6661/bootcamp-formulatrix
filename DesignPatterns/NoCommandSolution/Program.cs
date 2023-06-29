public class Light
{
    public void TurnOn()
    {
        Console.WriteLine("Light turned on");
    }
}

public class Television
{
    public void TurnOn()
    {
        Console.WriteLine("TV turned on");
    }
}

public class Fan
{
    public void TurnOn()
    {
        Console.WriteLine("Fan turned on");
    }
}

public class RemoteControl
{
    private Light _light;
    private Television _television;
    private Fan _fan;

    public RemoteControl()
    {
        _light = new Light();
        _television = new Television();
        _fan = new Fan();
    }

    public void PressLightButton()
    {
        _light.TurnOn();
    }
    public void PressTelevisionButton()
    {
        _television.TurnOn();
    }
    public void PressFanButton()
    {
        _fan.TurnOn();
    }
}

public class Program
{
    public static void Main(string[] args)
    {
        RemoteControl remoteControl = new RemoteControl();
        remoteControl.PressLightButton();
        remoteControl.PressTelevisionButton();
        remoteControl.PressFanButton();
    }
}