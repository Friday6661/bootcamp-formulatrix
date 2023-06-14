using mathOperationLib;
using System;
public class Program
{
    static void Main()
    {
        Calculator calculator = new Calculator();

        // Membuat instance delegate dengan menghubungkan ke method yang ada
        MathOperation operation = calculator.Add;
        operation += calculator.Substract;
        operation += calculator.Multiply;
        operation += calculator.devide;

        Delegate[] operations = operation.GetInvocationList();
        foreach (Delegate op in operations)
        {
            MathOperation mathop = (MathOperation)op;
            string result = mathop(x, y);
            return result;
        }
    }
}