namespace ConsoleOutputLib;
using IOutputLib;
using System;
using System.Collections.Generic;

public class ConsoleOutput : IOutput
{
    public void Write(string pesan)
    {
        Console.Write(pesan);
    }

    public void WriteLine(string pesan)
    {
        Console.WriteLine(pesan);
    }
}