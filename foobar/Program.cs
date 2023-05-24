using foobarLib;
using System;

public class Program {
    public static void Main(string[] args) {
        // fungsi input user untuk bilangan awal (bilangan terkecil)
        Console.Write("Masukkan nilai bilangan Minimum: ");
        int i = Convert.ToInt32(Console.ReadLine());
        // fungsi input user untuk bilangan akhir (bilangan terbesar)
        Console.Write("Masukkan nilai bilangan Maximum: ");
        int n = Convert.ToInt32(Console.ReadLine());
        
        Algorithm.CheckNumber(i, n);
    }
        
}