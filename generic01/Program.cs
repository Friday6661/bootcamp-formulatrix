using DataStoreLib;
using System;
using System.Collections.Generic;

public class Program
{
    public static void Main(string[] args)
    {
        DataStore<string> newData = new DataStore<string>();
        newData.AddItem("Data 1");

        Console.WriteLine("DataStore Items:");
        for (int i = 0; i < newData.Count; i++)
        {
            Console.WriteLine(newData[i]);
        }
    }
}