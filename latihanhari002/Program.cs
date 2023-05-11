using System;
using EncapsulationExercise;

static class Program {
    static void Main(string[] args) {
        Employee a = new Employee();

        //set property values
        a.Id = 1001;
        a.Name = "Joni";
        a.Salary = 100;

        // Get property values and print to console
        Console.WriteLine($"Employee ID: {a.Id}");
        Console.WriteLine($"Employee Name: {a.Name}");
        Console.WriteLine($"Salary: {a.Salary}");
    }
}