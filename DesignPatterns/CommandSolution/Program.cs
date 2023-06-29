//Command
public interface ICommand
{
    void Execute();
}

//Concrete Command start 
public class TurnOnLightCommand : ICommand
{
    private Light _light;
    public TurnOnLightCommand(Light light)
    {
        _light = light;
    }
    public void Execute()
    {
        _light.TurnOn();
    }
}
public class TurnOnTVCommand : ICommand
{
    private Television _television;
    public TurnOnTVCommand(Television television)
    {
        _television = television;
    }
    public void Execute()
    {
        _television.TurnOn();
    }
}
public class TurnOnFanCommand : ICommand
{
    private Fan _fan;
    public TurnOnFanCommand(Fan fan)
    {
        _fan = fan;
    }
    public void Execute()
    {
        _fan.TurnOn();
    }
}
// Concrete Command End
public class Light
{
    public void TurnOn()
    {
        Console.WriteLine("Light turned on");
    }
}

// Receiver class start
public class Television
{
    public void TurnOn()
    {
        Console.WriteLine("Television turned on");
    }
}
public class Fan
{
    public void TurnOn()
    {
        Console.WriteLine("Fan turned on");
    }
}
// Receiver class end

// Sender/Invoker
public class RemoteControlButton
{
    private ICommand _command;
    public void SetCommand(ICommand command)
    {
        _command = command;
    }
    public void PressButton()
    {
        _command.Execute();
    }
}
public class Program
{
    public static void Main(string[] args)
    {
        Light light = new Light();
        RemoteControlButton lightButton = new RemoteControlButton();
        lightButton.SetCommand(new TurnOnLightCommand(light));
        lightButton.PressButton();

        Television television = new Television();
        RemoteControlButton tvButton = new RemoteControlButton();
        tvButton.SetCommand(new TurnOnTVCommand(television));
        tvButton.PressButton();

        Fan fan = new Fan();
        RemoteControlButton fanButton = new RemoteControlButton();
        fanButton.SetCommand(new TurnOnFanCommand(fan));
        fanButton.PressButton();
    }
}