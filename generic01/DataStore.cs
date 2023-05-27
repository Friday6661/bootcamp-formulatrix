namespace DataStoreLib;
using System;

public class DataStore<T>
{
    //Variable dengan tipe data List
    private List<T> _data;

    //Constructor
    public DataStore()
    {
        _data = new List<T>();
    }

    public void AddItem(T item)
    {
        _data.Add(item);
    }

    public void RemoveItem(T item)
    {
        _data.Remove(item);
    }

    public void Clear()
    {
        _data.Clear();
    }

    public int Count
    {
        get { return _data.Count; }
    }

    public T this[int index]
    {
        get { return _data[index]; }
        set { _data[index] = value; }
    }
}