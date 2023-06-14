namespace LogicLib;
using IKontrakLib;
using IOutputLib;
using FooBarLib;
using BarLib;
using FooLib;
using ConsoleOutputLib;
using System;
using System.Collections.Generic;

public class Logic
{
    private List<IKontrak> _kontrak;
    private IOutput output;

    public Logic(IOutput writer)
    {
        _kontrak = new List<IKontrak>();

        //Dibuat method sendiri agar user lebih flexsibel menambahakan foo/bar/baz atau kombinasi dari ketiganya
        //_kontrak.Add(new FooBar());
        //_kontrak.Add(new Bar());
        //_kontrak.Add(new Foo());

        output = writer;
    }

    //Method yang ditambahkan
    public void AddLogic(IKontrak item)
    {
        _kontrak.Add(item);
    }

    public void DisplayLogic()
    {
        foreach (IKontrak k in _kontrak)
        {
            output.WriteLine(k.ToString());
        }
    }

    public void HasilLogic(int startNumber, int endNumber)
    {
        for (int i = startNumber; i <= endNumber; i++)
        {
            string result = string.Empty;
            foreach (IKontrak k in _kontrak)
            {
                if (k.IsTrue(i))
                {
                    result += k.GetResult();
                }
            }
            output.Write(result == string.Empty ? i.ToString() : result);
            if (i != endNumber)
            {
                output.Write(", ");
            }
        }
    }
}