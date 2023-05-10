// Constructor adalah sebuah method khusus yang berfungsi untuk inisialisasi class tersebut

using System;
namespace ConstructorDemo {
    class Program {
        static void Main(string[] args) {
            ParameterizedConstructor obj01  = new ParameterizedConstructor(10);
            obj01.Display();
            ParameterizedConstructor obj02  = new ParameterizedConstructor(20);
            obj01.Display();
            Console.ReadKey();
        }
    }

    public class ParameterizedConstructor {
        int x = 20;
        public ParameterizedConstructor(int i) {
                    Console.WriteLine($"Parameterized Constructor is Called : {i}");
                }
        public void Display() {
            Console.WriteLine($"Value of X = {x}");
        }
    }
}