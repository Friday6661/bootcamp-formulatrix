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
        mapping[3] = "foo";
        mapping[5] = "bar";
        mapping[7] = "baz";
    }

    public void CetakLogic(int startNumber, int stopNumber)
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

            Console.Write($"{result}, ");
        }
    }

}