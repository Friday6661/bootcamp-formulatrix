using kendaraan;
namespace sepedamotor;

public class SepedaMotor : Kendaraan{
    private int _kapasitasTangki;

    public int KapasitasTangki
    {
        get { return _kapasitasTangki; }
        set { _kapasitasTangki = value; }
    }
}