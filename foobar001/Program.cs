using LogicLib;

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
        Console.WriteLine(foobarbaz.AddCondition(3, "FoO"));

        Console.WriteLine(foobarbaz.AddCondition(5, "Bar"));
        Console.WriteLine(foobarbaz.ResultCondition(StartNumber, StopNumber));
        Console.WriteLine(foobarbaz.RemoveCondition(3));
        Console.WriteLine(foobarbaz.ResultCondition(StartNumber, StopNumber));
        Console.WriteLine(foobarbaz.AddCondition(7, "FIZ"));
        Console.WriteLine(foobarbaz.CheckCondition(7));
        Console.WriteLine(foobarbaz.ResultCondition(StartNumber, StopNumber));
        Console.WriteLine(foobarbaz.CheckNumber("fIz"));
        Console.WriteLine(foobarbaz.ListAllCondition());
        Console.WriteLine(foobarbaz.ChangeValue(7, "bAZ"));
        Console.WriteLine(foobarbaz.AddCondition(10, "FiZz"));
        Console.WriteLine(foobarbaz.AddCondition(10, "dom"));
        Console.WriteLine(foobarbaz.ListAllCondition());
        Console.WriteLine(foobarbaz.ResultCondition(StartNumber, StopNumber));
        Console.WriteLine(foobarbaz.ClearAllCondition());
        Console.WriteLine(foobarbaz.ListAllCondition());
        Console.WriteLine(foobarbaz.ResultCondition(StartNumber, StopNumber));
    }
}