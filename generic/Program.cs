using System;
using System.Collections.Generic;
using ItemLib;
using InventoryLib;

class Program
{
    static void Main()
    {
        Inventory<Item> inventory = new Inventory<Item>();

        Item sword = new Item("Sword");
        Item potion = new Item("Potion");
        Item shield = new Item("Shield");

        Console.WriteLine(inventory.AddItem(sword));
        Console.WriteLine(inventory.AddItem(potion));
        Console.WriteLine(inventory.AddItem(shield));
        Console.WriteLine(inventory.DisplayItems());

        Console.WriteLine(inventory.RemoveItem(potion));
    }
}