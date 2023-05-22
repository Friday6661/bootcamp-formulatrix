namespace playerLib;
using heroLib;

public class Player {
    public int PlayerId { get; }
    public List<Hero> Heroes { get; }
    public int MaxHeroes { get; }

    public Player(int PlayerId, int MaxHeroes) {
        this.PlayerId = PlayerId;
        Heroes = new List<Hero>();
        this.MaxHeroes = MaxHeroes;
    }

    public void AddHero(Hero hero) {
        if (Heroes.Count < MaxHeroes) {
            Heroes.Add(hero);
            Console.WriteLine($"Player {PlayerId}: Added hero {hero.Name} to the roster.");
        }
        else {
            Console.WriteLine($"Player {PlayerId}: Cannot add more heroes. Maxium hero limit reached.");
        }
    }

    public void RemoveHero(Hero hero) {
        Heroes.Remove(hero);
        Console.WriteLine($"Player {PlayerId}: Removed hero {hero.Name} from the roster.");
    }
}