using System;
namespace DemoClassObject {
    class Program {
        static void Main(string[] args) {
                    
                    // Membuat Object
                    Calculator calObject = new Calculator();

                    // Akses Calculator class member menggunakan Calculator class object
                    int result = calObject.CalculateSum(10,20);
                    Console.WriteLine(result);
                    Console.ReadKey();
                }
    }

    // Define Class atau blueprint atau template
    public class Calculator {
        public int CalculateSum(int a, int b) {
            return a + b;
        }
    }
}