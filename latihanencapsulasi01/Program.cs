using KendaraanLib;
using MobilLib;
using MotorLib;

class Program {
    static void Main(string[] args){
        Kendaraan k0001 = new Kendaraan();
        k0001.kecepatan = 100;
        k0001.warna = "hitam";
        k0001.transmisi = true;
        k0001.tempatberoperasi = "Darat";
        //k0001.tahunproduksi = 2024;
        //k0001.tipekendaraan = "mobil";
        //k0001.statuspajak = true;

        Mobil m0001 = new Mobil();
        m0001.kecepatan = 100;
        m0001.warna = "hitam";
        m0001.transmisi = true;
        m0001.tempatberoperasi = "Darat";
        m0001.kapasitasmesin = 4;
        m0001.kapasitaspenumpang = 2;
        m0001.jaraktempuh = 0;
        m0001.bahanbakar = "Pertamax";

        m0001.statusKendaraan(2020, true);
        m0001.tipeKendaraan();

        Motor mr0001 = new Motor();
        mr0001.kecepatan = 100;
        mr0001.warna = "hitam";
        mr0001.transmisi = true;
        mr0001.tempatberoperasi = "Darat";
        mr0001.kapasitasmesin = 4;
        mr0001.jaraktempuh = 0;
        mr0001.bahanbakar = "Pertamax";

        mr0001.statusKendaraan(2000, false);
        mr0001.nyala();
        mr0001.mati();

        k0001.nyala();
        k0001.mati();
    }
}