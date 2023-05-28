namespace BarLib;
using IKontrakLib;
using System;
using System.Collections.Generic;

public class Bar : IKontrak
{
    public bool IsTrue(int number)
    {
        return number % 5 == 0;
    }
    public string GetResult()
    {
        return "bar";
    }
}