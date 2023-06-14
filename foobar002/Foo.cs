namespace FooLib;
using IKontrakLib;
using System;
using System.Collections.Generic;

public class Foo : IKontrak
{
    public bool IsTrue(int number)
    {
        return number % 3 == 0;
    }

    public string GetResult()
    {
        return "foo";
    }
}