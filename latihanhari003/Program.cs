using kendaraan;
using mobil;
using sepedamotor;
static void Main(string[] args)
{
    Kendaraan kendaraan = new Kendaraan();
    kendaraan.Nama = "Kendaraan";
    kendaraan.tipe = "Umum";
    kendaraan.KapasitasMesin = 1000;
    kendaraan.MesinStart();
    kendaraan.HidupkanRadio();
    kendaraan.MatikanRadio();
    kendaraan.MesinStop();

    Mobil mobil = new Mobil();
    mobil.Nama = "Mobil";
    mobil.tipe = "Mobil Umum";
    mobil.KapasitasMesin = 2000;
    mobil.Warna = "Merah";
    mobil.JumlahRoda = 4;
    mobil.MesinStart();
    mobil.HidupkanRadio();
    mobil.MatikanRadio();
    mobil.NyalakanLampuMobil();
    mobil.MesinStop();

    SepedaMotor sepedaMotor = new SepedaMotor();
    sepedaMotor.Nama = "Sepeda Motor";
    sepedaMotor.tipe = "Sepeda Motor Umum";
    sepedaMotor.KapasitasMesin = 500;
    sepedaMotor.KapasitasTangki = 10;
    sepedaMotor.MesinStart();
    sepedaMotor.HidupkanRadio();
    sepedaMotor.MatikanRadio();
    sepedaMotor.NyalakanLampuSepedaMotor();
    sepedaMotor.MesinStop();

    Console.ReadLine();
}
