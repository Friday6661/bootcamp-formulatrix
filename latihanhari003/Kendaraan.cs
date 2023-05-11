// Constructor adalah sebuah method khusus yang berfungsi untuk inisialisasi class tersebut

namespace kendaraan;

public class Kendaraan {
    private string _name;
    public string tipe;
    protected int _tahun;
    internal int KapasitasMesin {get; set; }


    public string Nama {
        get { return _name; }
        set { _name = value; }
    }

    private int Kecepatan { get; set; }

    protected void MesinStart() {
        Console.WriteLine("Kendaraan dalam mode start");
    }

    public void MesinStop() {
        Console.WriteLine("Kendaraan dalam mode stop");
    }

    public void NyalakanLampu() {
        Console.WriteLine("Lampu dinyalakan");
    }

    public void MatikanLampu() {
        Console.WriteLine("Lampu dimatikan");
    }
}