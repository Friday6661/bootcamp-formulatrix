using kendaraan;
namespace mobil;


public class Mobil : Kendaraan {
    private string _merk;
    public string Warna;
    public int jumlahRoda;

    public string Merk {
        get { return _merk; }
        set { _merk = value; }
    }

    public void BukaKaca() {
        Console.WriteLine("Buka Kaca Sekarang");
    }

    public void TutupKaca() {
        Console.WriteLine("Tutup Kaca");
    }
}