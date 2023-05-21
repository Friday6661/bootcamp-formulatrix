namespace gameLib;
using playerLib;
using heroLib;
using battleLib;

public class Game {
    private Player player1;
    private Player player2;
    private Battle battle;

    public Game() {
        battle = new Battle();
    }

    public void SetupGame() {
        player1 = new Player(1);
        player2 = new Player(2);

        // Membuat hero-hero di awal untuk setiap pemain

        Hero hero1 = new Hero(1, "Hero 1", 100, 10, 5);
        Hero hero2 = new Hero(2, "Hero 2", 120, 8, 5);
        Hero hero3 = new Hero(3, "Hero 3", 150, 10, 5);

        player1.AddHero(hero1);
        player1.AddHero(hero2);
        player2.AddHero(hero3);
    }

    public void StartGame() {
        Console.WriteLine("Game Started!");

        // Memulai pertempuran antara dua pemain
        battle.StartBattle(player1, player2);
        Console.WriteLine("Game Finished!");
    }

    public void EndGame() {
        // Menampilkan hasil akhir permainan
        Console.WriteLine("Final Result: ");
        Console.WriteLine("Player 1 Heros: ");
        foreach (Hero hero in player1.GetHeros()) {
            Console.WriteLine(hero.Name);
        }

        Console.WriteLine("Player 2 Heros: ");
        foreach (Hero hero in player2.GetHeros()) {
            Console.WriteLine(hero.Name);
        }
    }

}