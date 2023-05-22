namespace battleLib;
using playerLib;
using heroLib;

public class Battle {
    public Player Player1 { get; }
    public Player Player2 { get; }

    // Constructors
    public Battle (Player Player1, Player Player2) {
        this.Player1 = Player1;
        this.Player2 = Player2;
    }

    public void StartBattle() {
        Console.WriteLine("Battle started");
        while (Player1.Heroes.Count > 0 && Player2.Heroes.Count > 0) {
            ResolveTurn();
        }

        Console.WriteLine("Battle ended");
    }

    private void ResolveTurn() {

        // Simulate the turn Logic
        Console.WriteLine("Resolving Turn...");

        // Let Player 1 choose the attacking hero
        Hero attacker = ChooseHero(Player1);

        // Let Player 2 choose the defending hero
        Hero defender = ChooseHero(Player2);

        // Perform the attack
        attacker.Attack(defender);

        //Check if the defender is defeated
        if (defender.IsDefeated()) {
            Console.WriteLine($"{defender.Name} has been defeated");

        // Remove the defeated hero from the player's roster
            if (Player1.Heroes.Contains(defender)) {
                Player1.RemoveHero(defender);
            }
            else if (Player2.Heroes.Contains(defender)) {
                Player2.RemoveHero(defender);
            }
        }
        
        if (defender.Health == 0) {
            Console.WriteLine($"{defender.Name} is dead");
        }
    }

    private Hero ChooseHero(Player Player) {
        Console.WriteLine($"Player {Player.PlayerId}, choose a hero to a attack:");

        // Display the available heroes
        for (int i = 0; i < Player.Heroes.Count; i++) {
            Console.WriteLine($"{i + 1}. {Player.Heroes[i].Name}");
        }

        // Logic the player for selecting a\
        int selectHeroIndex;
        do {
            Console.Write("Enter the number of the hero: ");
            string input = Console.ReadLine();
            if (int.TryParse(input, out selectHeroIndex) && selectHeroIndex >= 1 && selectHeroIndex <= Player.Heroes.Count) {
                break;
            }
            Console.WriteLine("Invalid input. Please try again.");
        }
        while (true);

        // Return the selected hero
        return Player.Heroes[selectHeroIndex - 1];
    }


}