using LogicLib;
using System;
using System.Collections.Generic;

public class Program
{
    public static void Main(string[] args)
    {
         // fungsi input user untuk bilangan awal (bilangan terkecil)
        Console.Write("Masukkan nilai bilangan Minimum: ");
        int StartNumber = Convert.ToInt32(Console.ReadLine());
        // fungsi input user untuk bilangan akhir (bilangan terbesar)
        Console.Write("Masukkan nilai bilangan Maximum: ");
        int StopNumber = Convert.ToInt32(Console.ReadLine());
        Logic foobarbaz = new Logic();
        foobarbaz.AddCondition(3, "FoO");
        foobarbaz.AddCondition(5, "Bar");


        foobarbaz.ResultCondition(StartNumber, StopNumber);

        //foobarbaz.RemoveCondition(3);
        foobarbaz.ResultCondition(StartNumber, StopNumber);
        foobarbaz.AddCondition(7, "FIZ");
        Console.WriteLine(foobarbaz.CheckCondition(7));
        foobarbaz.ResultCondition(StartNumber, StopNumber);
        //foobarbaz.ListAllCondition();
        //foobarbaz.ClearAllCondition();
        Console.WriteLine(foobarbaz.CheckNumber("fIz"));
        Console.WriteLine(foobarbaz.ListAllCondition());
        foobarbaz.ChangeValue(7, "bAZ");
        foobarbaz.AddCondition(10, "FiZz");
        Console.WriteLine(foobarbaz.ListAllCondition());
        foobarbaz.ResultCondition(StartNumber, StopNumber);
    }
}