public interface IPrint {
    void Print();
}

public interface IFax {
    void Fax();
}

public interface IScan {
    void Scan();
}

public class Epson300RibuRupiah : IPrint {
    public void Print() {
        Console.WriteLine("Printing");
    }
}

public class Brother3JutaRupiah : IPrint, IFax, IScan {
    public void Print() {
        Console.WriteLine("Printing");
    }
    public void Fax() {
        Console.WriteLine("Fax");
    }
    public void Scan() {
        Console.WriteLine("Scan");
    }
}

public class HP800Ribu : IPrint, IScan {
    public void Print() {
        Console.WriteLine("Printing");
    }
    public void Scan() {
        Console.WriteLine("Scan");
    }
}

static class Program {
    public static int x;
    public static string y;
    public static Leg epson;
    public static IPrint assetPrinter;
    static void Main() {
        Epson300RibuRupiah epson = new Epson300RibuRupiah();
        Brother3JutaRupiah brother = new Brother3JutaRupiah();
        HP800Ribu hp = new HP800Ribu();
        IPrint printerbaru = hp;
        AddPrinter(epson);
    }
    static void AddPrinter(IPrint printer) {
        assetPrinter = printer;
    }
}