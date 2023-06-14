namespace mathOperationLib;
using System;

// Delegate untuk operasi matematika dua parameter
public delegate double MathOperation(double x, double y);

public class Calculator
{
    // Method to add calculation
    public double Add(double x, double y)
    {
        return x + y;
    }

    // methode to substract calculation
    public double Substract(double x, double y)
    {
        return x - y;
    }

    // methode to multiply calculation
    public double Multiply(double x, double y)
    {
        return x * y;
    }

    // methode to divide calculation
    public double devide(double x, double y)
    {
        if  (y != 0)
        {
            return x / y;
        }
        else
        {
            return "Error: Division by zero";
        }
    }
}