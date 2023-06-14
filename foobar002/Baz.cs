namespace BazzLib;
using IKontrakLib;
using System;
using System.Collections.Generic;

public class Bazz : IKontrak
{
    public bool IsTrue(int number)
    {
        return number % 7 == 0;
    }
    public string GetResult()
    {
        return "bazz";
    }
}