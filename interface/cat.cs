public class Cat {
    public Leg catLeg;
    public Cat(Leg at) {
        catLeg = at;
    }
    public void LegChecker() {
        Console.WriteLine("Cat leg is " + catLeg.GetLegSize());
    }
}

public class Leg {
    private int legsize;
    public Leg(int x) {
        legsize = x;
    }
    public int GetLegSize() {
        return legsize;
    }
}

/*
class Program {
    static void Main() {
        Leg leg = new Leg(4);
        Cat cotton = new Cat(leg);
        cotton.LegChecker();
    }
}
*/
