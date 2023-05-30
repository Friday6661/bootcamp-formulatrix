namespace LogicLib;
using System.Text;
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
        if (!mapping.ContainsKey(key))
        {
            mapping.Add(key, value.ToLower());
        }
    }

    // Method agar user bisa menghapus logic yang terdaftar
    public void RemoveCondition(int key)
    {
        if (mapping.ContainsKey(key))
        {
            mapping.Remove(key);
        }
    }

    // Method untuk menampilkan seluruh kondisi terdaftar
    /*
    public string ListAllCondition()
    {
        foreach(KeyValuePair<int, string> kvp in mapping)
        {
            return $"\nKey: {kvp.Key}, Value: {kvp.Value}";
        }
    }*/
    public string ListAllCondition()
    {
        StringBuilder sb = new StringBuilder();

        foreach (KeyValuePair<int, string> kvp in mapping)
        {
            sb.AppendLine($"Key: {kvp.Key}, Value: {kvp.Value}");
        }

        return sb.ToString();
    }

    // Method untuk Check kondisi berdasarkan key
    public string CheckCondition(int key)
    {
        if (mapping.ContainsKey(key))
        {
            return $"\nValue dari Key {key} adalah: {mapping[key]}";
        }
        else
        {
            return "False";
        }
    }

    //Method untuk check number (key) by value

    public string CheckNumber(string value)
    {
        bool check = mapping.ContainsValue(value.ToLower());

        if (check)
        {
            foreach (var keyValuePair in mapping)
            {
                if (keyValuePair.Value.ToLower() == value.ToLower())
                {
                    return $"\nKey dari {value.ToLower()} adalah: {keyValuePair.Key}";
                }
            }
            return "\nKey tidak ditemukan";
        }
        else
        {
        return "\nValue tidak terdaftar";
        }
    }

    /*
    public void CheckNumber(string value)
    {        
        for (int i = 0; i < mapping.Count; i++)
        {
            int key = mapping.Keys.ElementAt(i);
            string values = mapping[key];
            if (values == value.ToLower())
            {
                return $"Key dari {value.ToLower()} adalah: {key}";
            }
        }
    }*/

    // Methode untuk mengubah suatu value berdasarkan key
    public void ChangeValue(int key, string newvalue)
    {
        if (mapping.ContainsKey(key))
        {
            mapping[key] = newvalue.ToLower();
        }
    }
    // Method untuk menghapus semua kondisi
    public void ClearAllCondition()
    {
        mapping.Clear();
    }

    //Method untuk menampilkan deret bilangan foo bar
    public string ResultCondition(int startNumber, int stopNumber)
    {
        StringBuilder sb = new StringBuilder();
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
                sb.Append($"{result}, ");
            }
            else
            {
                sb.Append($"{result}");
            }
        }

        return sb.ToString();
    }
}