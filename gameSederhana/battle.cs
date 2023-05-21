namespace battleLib;
using playerLib;
using heroLib;
using gameLib;

public class Battle {
    public void StartBattle(Player player1, Player player2) {
        Console.WriteLine("Battle started");

        while (player1.GetHeros().Count > 0 && player2.GetHeros().Count > 0) {
            ResolveTurn(player1, player2);
            ResolveTurn(player2, player1);
        }

        Console.WriteLine("Battle ended");
        
        // Menentukan pemenang berdasarkan sisa unit
        if (player1.GetHeros().Count > 0) {
            Console.WriteLine("Player 1 wins");
        }
        else if (player2.GetHeros().Count > 0) {
            Console.WriteLine("Player 2 wins");
        }
        else {
            Console.WriteLine("It's a Draw!");
        }
    }

    private void ResolveTurn(Player attackingPlayer, Player defendingPlayer) {
        List<Hero> attackingHeros = attackingPlayer.GetHeros();
        List<Hero> defendingHeros = defendingPlayer.GetHeros();

        foreach (Hero attackingHero in attackingHeros) {
            if (defendingHeros.Count == 0) {
                break; // Berhenti jika tidak ada hero yang bertahan
            }

            Hero target = SelectTarget(defendingHeros);
            attackingHero.Attack(target);

            if (target.Health <= 0) {
                defendingPlayer.RemoveHero(target);
            }
        }
    }

    private Hero SelectTarget(List<Hero> heros) {
        // Implementasi logika pemilihan target unit yang ingin diserang
        return heros[0];
    }
}