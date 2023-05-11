using System;
using EncapsulationExercise;

static class Program {
    static void Main(string[] args) {
        Employee a = new Employee(); // Penambahan employee baru pertama
        Employee b = new Employee(); // Penambahan employee baru kedua

        //set property values employee pertama
        a.Id = 1001;
        a.Name = "Joni";
        a.Salary = 100;

        //set property values employee kedua
        b.Id = 1002;
        b.Name = "Jari";
        b.Salary = 200;

        // Get property values and print to console
        Console.WriteLine($"Employee ID: {a.Id}");
        Console.WriteLine($"Employee Name: {a.Name}");
        Console.WriteLine($"Salary: {a.Salary}");

        // Get property values and print to console
        Console.WriteLine($"Employee ID: {b.Id}");
        Console.WriteLine($"Employee Name: {b.Name}");
        Console.WriteLine($"Salary: {b.Salary}");
    }
}