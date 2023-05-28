using IOutputLib;
using LogicLib;
using ConsoleOutputLib;
using FooBarLib;
using BazzLib;
using BarLib;
using FooLib;
using System;
using System.Collections.Generic;
using NewLogicLib;
public class Program {
    public static void Main(string[] args) 
    {
        // Instance yang menggunakan List pada class Logic.cs
        IOutput output = new ConsoleOutput();
        Logic logic = new Logic(output);

        logic.AddLogic(new Foo());
        logic.AddLogic(new Bar());
        //logic.AddLogic(new FooBar());
        //muncul bug ketika penambahan logic FooBar karena pada kelas logic pada saat
        //kondisi k.IsTrue(i) maka akan mereturn k.GetResult() dari variabel _kontrak yang berisi anggota List<IKontrak> yang terdaftar
        logic.AddLogic(new Bazz());
        logic.DisplayLogic();
        logic.HasilLogic(1,21);
        output.WriteLine("");

        output.WriteLine("================================================================");
        // Instance yang menggunakan Dictionary pada class NewLogic.cs
        IOutput output01 = new ConsoleOutput();
        NewLogic logic01 = new NewLogic(output01);

        logic01.AddLogic(5, new Bar());
        logic01.AddLogic(3, new Foo());
        logic01.AddLogic(7, new Bazz());
        logic01.DisplayLogic();
        logic.HasilLogic(1,21);
    }
}