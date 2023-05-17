using System;
namespace ParentChildLib;

public class Parent {
    private int _privateField;
    public string publicField;
    protected int protectedField;
    internal int internalField;
    protected internal int protectedInternalField;

    private void PrivateMethod() {
        Console.WriteLine("Private Method");
    }

    public void PublicMethod() {
        Console.WriteLine("Ini Public Method");
    }

    protected void ProtectedMethod() {
        Console.WriteLine("Protected Method");
    }

    internal void InternalMethod() {
        Console.WriteLine("Internal Method");
    }

    protected internal void ProtectedInternalMethod() {
        Console.WriteLine("Protected Internal Method");
    }
}

public class Child : Parent {
    public void AccessParentFieldsAndMethods(){

        // Memiliki akses ke anggota dengan pengubah akses protected
        protectedField = 10;
        ProtectedMethod();

        // Memiliki akses ke anggota dengan pengubah akses internal
        internalField = 20;
        InternalMethod();

        // Memiliki akses ke anggota dengan pengubah akses protected internal
        protectedInternalField = 30;
        ProtectedInternalMethod();

    }
}

using System;
using ParentChildLib;

public class Program{
    public static void Main(string[] args){
        Parent parent = new Parent();

        // Memiliki akses ke child dengan pengubah akses public
        parent.publicField = "define program Public Field";
        parent.PublicMethod();
        Console.WriteLine(parent.publicField);

        // Tidak memiliki akses ke child dengan pengubah akses private, protected, internal, atau protected internal
        //parent._privateField;
        //parent._protectedField;
        //parent._internalField;
        //parent._protectedInternalField;

        Child child = new Child();

        child.publicField = "define program child Public Field";
        child.PublicMethod();
        Console.WriteLine(child.publicField);

        // Memiliki akses ke child dengan pengubah akses protected
        //child.protectedField = 40;
        //child.ProtectedMethod();

        // Memiliki akses ke child dengan pengubah akses internal
        //child.internalField = 50;
        //child.InternalMethod();

        // Memiliki akses ke child dengan pengubah akses protected internal
        //child.protectedInternalField;
        //child.ProtectedInternalMethod();

    }
}