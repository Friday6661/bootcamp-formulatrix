using System;
using privateaccess;
//using publicaccess;

class Program {
    static void Main(string[] args) {

        // Inisialisasi employe baru
        Employee e = new Employee();
        //Division d = new Division();

        // Public variabel
        //d.name = "Engineer";
        //d.totalmembers = 20;

        // Private variabel
        e.Age = 25;
        e.Address = "City of Evil";
        e.Salary = 100;
        int age = e.Age;
        string address = e.Address;
        double salary = e.Salary;

        // Keluaran public
        //Console.WriteLine($"Nama Divisi adalah {d.name}");
        //Console.WriteLine($"Total Member: {d.totalmembers}");

        // Keluaran private
        Console.WriteLine($"Usia Karyawan adalah {age}");
        Console.WriteLine($"Alamat Karyawan adalah: {address}");
        Console.WriteLine($"Gaji Karyawan adalah: {salary}");

        // Keluaran private methode
        e.GetPrivateMethode();
    }
}