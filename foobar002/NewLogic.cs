namespace NewLogicLib;
using IKontrakLib;
using IOutputLib;
using FooBarLib;
using BarLib;
using FooLib;
using ConsoleOutputLib;
using System;
using System.Collections.Generic;

public class NewLogic
{
    private Dictionary<int, IKontrak> _kontrak;
    private IOutput output;

    public NewLogic(IOutput writer)
    {
        _kontrak = new Dictionary<int, IKontrak>();
        output = writer;
    }

    public void AddLogic(int key, IKontrak value)
    {
        _kontrak.Add(key, value);
    }

    public void DisplayLogic()
    {
        foreach (KeyValuePair<int, IKontrak> kvp in _kontrak)
        {
            output.WriteLine(kvp.Value.ToString());
        }
    }

    public void RemoveLogic(int key)
    {
        _kontrak.Remove(key);
    }


    public void HasilLogic(int startNumber, int endNumber)
    {
        for (int i = startNumber; i <= endNumber; i++)
        {
            string result = string.Empty;
            foreach (KeyValuePair<int, IKontrak> kvp in _kontrak)
            {
                if (kvp.Value.IsTrue(i))
                {
                    result += kvp.Value.GetResult();
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