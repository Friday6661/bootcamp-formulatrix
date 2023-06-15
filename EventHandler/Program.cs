using System;
using System.Collections.Generic;

class Program {
    static void Main() {
        // Using Func to calculate the square of a number
        Func<int, int> square = x => x * x;
        Console.WriteLine(square(5)); // Output: 25

        // Using Action to print a message to the console
        Action<string> printMessage = message => Console.WriteLine(message);
        printMessage("Hello, world!"); // Output: Hello, world!

        // Using Predicate to filter a list of numbers
        Predicate<int> isEven = x => x % 2 == 0;
        List<int> numbers = new List<int> { 1, 2, 3, 4, 5, 6 };
        List<int> evenNumbers = numbers.FindAll(isEven);
        Console.WriteLine(string.Join(", ", evenNumbers)); // Output: 2, 4, 6

        // Using Comparison to sort a list of strings
        Comparison<string> lengthComparison = (s1, s2) => s1.Length.CompareTo(s2.Length);
        List<string> strings = new List<string> { "foo", "bar", "baz" };
        strings.Sort(lengthComparison);
        Console.WriteLine(string.Join(", ", strings)); // Output: foo, bar, baz

        // Using Converter to convert a list of strings to a list of integers
        Converter<string, int> stringToInt = s => int.Parse(s);
        List<string> stringList = new List<string> { "1", "2", "3" };
        List<int> intList = stringList.ConvertAll(stringToInt);
        Console.WriteLine(string.Join(", ", intList)); // Output: 1, 2, 3

        // Using EventHandler to handle an event
        Button button = new Button();
        button.Clicked += (sender, e) => Console.WriteLine("Button clicked!");
        button.PerformClick(); // Output: Button clicked!
    }
}

class Button {
    public event EventHandler Clicked;

    public void PerformClick() {
        Clicked?.Invoke(this, EventArgs.Empty);
    }
}