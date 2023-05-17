namespace KendaraanLib;

class Kendaraan {
    public int kecepatan;
    public string warna;
    public bool transmisi;
    public string tempatberoperasi;
    protected int tahunproduksi;
    protected string tipekendaraan;
    protected bool statuspajak;

    public Kendaraan(){}
    public Kendaraan(int kecepatan, string warna, bool transmisi, string tempatberoperasi, int tahunproduksi, string tipekendaraan, bool statuspajak) {
        this.kecepatan = kecepatan;
        this.warna = warna;
        this.transmisi = transmisi;
        this.tempatberoperasi = tempatberoperasi;
        this.tahunproduksi = tahunproduksi;
        this.tipekendaraan = tipekendaraan;
        this.statuspajak = statuspajak;
    }

    public virtual void nyala() {
        Console.WriteLine("Nyalakan Kendaraan");
    }

    public virtual void mati() {
        Console.WriteLine("Matikan Kendaraan");
    }

}
