namespace LogicLib;
using System;
using System.Collections.Generic;

public class Logic
{
    Dictionary<int, string> mapping;
    public int startNumber { get; set; }
    public int stopNumber { get; set; }

    public Logic()
    {
        mapping = new Dictionary<int, string>();
        //mapping[3] = "foo";
        //mapping[5] = "bar";
        //mapping[7] = "baz";
    }

    // Method agar user bisa menambahkan logic baru
    public void AddCondition(int key, string value)
    {
        mapping.Add(key, value.ToLower());
    }

    // Method agar user bisa menghapus logic yang terdaftar
    public void RemoveCondition(int key)
    {
        mapping.Remove(key);
    }

    // Method untuk menampilkan seluruh kondisi terdaftar
    public void ListAllCondition()
    {
        Console.WriteLine("Ini adalah Semua Kondisi yang terdaftar: ");
        foreach(KeyValuePair<int, string> kvp in mapping)
        {
            Console.WriteLine($"Key: {kvp.Key}, Value: {kvp.Value}");
        }
    }

    // Method untuk Check kondisi berdasarkan key
    public void CheckCondition(int key)
    {
        if (mapping.ContainsKey(key))
        {
            Console.WriteLine($"value: {mapping[key]}");
        }
        else
        {
            Console.WriteLine("False");
        }
    }

    //Method untuk check number (key) by value
    public void CheckNumber(string value)
    {
        for (int i = 0; i < mapping.Count; i++)
        {
            int key = mapping.Keys.ElementAt(i);
            string values = mapping[key];
            if (values == value.ToLower())
            {
                Console.WriteLine($"Key dari {value.ToLower()} adalah: {key}");
            }
        }
    }

    

    // Method untuk menghapus semua kondisi
    public void ClearAllCondition()
    {
        mapping.Clear();
    }

    //Method untuk menampilkan deret bilangan foo bar
    public void ResultCondition(int startNumber, int stopNumber)
    {
        for (int i = startNumber; i <= stopNumber; i++)
        {
            string result = "";
            foreach (KeyValuePair<int, string> kvp in mapping)
            {
                if (i % kvp.Key == 0)
                {
                    result += kvp.Value;
                }
            }

            if (result == "")
            {
                result = i.ToString();
            }

            if (i != stopNumber)
            {
                Console.Write($"{result}, ");
            }
            else
            {
                Console.WriteLine($"{result}");
            }
        }
    }

}