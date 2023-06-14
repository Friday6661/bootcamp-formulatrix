namespace FooBarLib;
using IKontrakLib;
using System;
using System.Collections.Generic;

public class FooBar : IKontrak
{
    public bool IsTrue(int number)
    {
        return number % 3 == 0 && number % 5 == 0;
    }
    public string GetResult()
    {
        return "foobar";
    }
}