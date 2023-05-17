using System;  
namespace AccessModifiers  
{  
    class Program  
    {  
        class Base  
        {  
            protected int num1;  
        }  
        class Derived : Base  
        {  
            public int num2;  
            static void Main(string[] args)  
            {  
                Base ob1 = new Base();  
                Derived ob2 = new Derived();  
                ob2.num1 = 20;  
                // Access to protected member as it is inherited by the Derived class  
                ob2.num2 = 90;  
                Console.WriteLine("Number2 value {0}", ob2.num2);  
                Console.WriteLine("Number1 value which is protected {0}", ob2.num1);  
                Console.ReadLine();  
            }  
        }  
    }  
}  