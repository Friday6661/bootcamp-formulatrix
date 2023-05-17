using KendaraanLib;
namespace MotorLib;

class Motor : Kendaraan {
    public int kapasitasmesin;
    public int jaraktempuh;
    public string bahanbakar;
    protected string model;

    public Motor() {}
    public Motor(int kecepatan, string warna, bool transmisi, string tempatberoperasi, int tahunproduksi, string tipekendaraan, bool statuspajak, int kapasitasmesin, int jaraktempuh, string bahanbakar, string model) : base(kecepatan, warna, transmisi, tempatberoperasi, tahunproduksi, tipekendaraan, statuspajak) {
        this.kapasitasmesin = kapasitasmesin;
        this.jaraktempuh = jaraktempuh;
        this.bahanbakar = bahanbakar;
        this.model = model;
    }

    public void statusKendaraan(int tahunproduksi, bool statuspajak){
        Console.WriteLine($"Tahun Produksi Kendaraan anda adalah: {tahunproduksi}");
        if(tahunproduksi <= 2000 && statuspajak == false) {
            Console.WriteLine("Kendaraan anda tidak seharusnya beroperasi karena sudah tua dan pajak mati");
        }
        else if(tahunproduksi >= 2000 && statuspajak == false) {
            Console.WriteLine("Kendaraan seharusnya bisa beroperasi, Tolong bayarkan pajak anda!");
        }
        else if(tahunproduksi <= 2000 && statuspajak == true) {
            Console.WriteLine("Sepertinya anda terlalu mencintai kendaraan anda");
        }
        else if(tahunproduksi >= 2000 && statuspajak == true) {
            Console.WriteLine("Tetap konsisten rawat kendaraan anda dan bayar pajak");
        }
        else {
            Exception exception = new Exception();
            Console.WriteLine(exception.Message);
        }
    }

    public override void nyala() {
        Console.WriteLine("Motor Nyala");
    }

    public override void mati() {
        Console.WriteLine("Motor Mati");
    }
}