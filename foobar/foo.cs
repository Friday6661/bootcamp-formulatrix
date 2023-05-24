namespace foobarLib;

public class Algorithm {
    public int n;
    public int a;

    public static void CheckNumber(int a, int n) {
        for (int i = a; i <= n; i++) {

            if (i % 3 == 0 && i % 5 == 0) {
                Console.Write($"foobar, ");
            }
            else if (i % 3 == 0) {
                Console.Write($"foo, ");
            }
            else if (i % 5 == 0) {
                Console.Write($"bar, ");
            }
            else {
                Console.Write($"{i}, ");
            }
        }
    }
}