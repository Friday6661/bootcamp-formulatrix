namespace EncapsulationExercise;

class Employee {
    private int _id;
    private string _name;
    private decimal _salary;


    //Properties
    public int Id {
        get { return _id; }
        set { _id = value; }
    }

    public string Name {
        get { return _name; }
        set { _name = value; }
    }

    public decimal Salary {
        get { return _salary; }
        set { _salary = value; }
    }
}