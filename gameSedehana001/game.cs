namespace gameLib;
using playerLib;
using battleLib;
using heroLib;

public class Game {
    public Player Player1 { get; }
    public Player Player2 { get; }

    public Game(Player Player1, Player Player2) {
        this.Player1 = Player1;
        this.Player2 = Player2;
    }

    public void StartGame() {
        Console.WriteLine("Game Started!");

        SetupGame();

        while (Player1.Heroes.Count > 0 && Player2.Heroes.Count > 0) {
            Battle battle = new Battle(Player1, Player2);
            battle.StartBattle();
        }

        EndGame();
    }

    private void SetupGame() {
        Console.WriteLine("Setting up the game...");

        // Perform the setup logic, such as creating initial heroes
        // Example: adding heroes to Player 1
        Player1.AddHero(new Hero(001, "Scarlet", 10, 20, 15, 5, 5, "Fireball", "firehole", HeroType.Mage));
        Player1.AddHero(new Hero(002, "Sun", 30, 5, 15, 10, 10, "Double Ganger", "Slash", HeroType.Fighter));

        // Example: adding heroes to Player 2
        Player2.AddHero(new Hero(003, "Friday", 20, 20, 10, 5, 15, "Shadow Strike", "Rain Dagger", HeroType.Assassins));
        Player2.AddHero(new Hero(004, "Dom", 10, 10, 20, 15, 15, "Shiled", "Shiled Area", HeroType.Tank));

        Console.WriteLine("Game setup complete!");
    }

    private void EndGame() {
        Console.WriteLine("Ending the game...");

        // Perform the end logic, such as determining the winner
        // Example: determining the winner
        if (Player1.Heroes.Count > 0) {
            Console.WriteLine($"Player {Player1.PlayerId} wins the game!");
        }
        else if (Player2.Heroes.Count > 0) {
            Console.WriteLine($"Player {Player2.PlayerId} wins the game!");
        }
        else {
            Console.WriteLine("Game Draw!!!");
        }
    }
}