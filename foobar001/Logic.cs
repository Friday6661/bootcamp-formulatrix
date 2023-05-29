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
        foreach(KeyValuePair<int, string> kvp in mapping)
        {
            Console.WriteLine($"Key: {kvp.Key}, Value: {kvp.Value}");
        }
    }

    // Method untuk Check kondisi berdasarkan value
    /*
    public void CheckCondition()
    {
        if (!mapping.ContainsValue(value.ToLower))
        {
            return mapping.Keys();
        }
    }
    */

    // Method untuk menghapus semua kondisi
    public void ClearAllCondition()
    {
        mapping.Clear();
    }

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