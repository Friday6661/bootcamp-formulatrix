namespace privateaccess;

class Employee {
    private int  _age;
    private string  _address;
    private double _salary;

    public int Age {
        get { return _age; }
        set { _age = value; }
    }

    public string Address {
        get { return _address; }
        set { _address = value; }
    }

    public double Salary {
        get { return _salary; }
        set { _salary = value; }
    }

    private void PrivateMethode() {
        Console.WriteLine("Private Methode Called");
    }

    public void GetPrivateMethode() {
        PrivateMethode();
    }
}
