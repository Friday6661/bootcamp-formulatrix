namespace playerLib;
using heroLib;

public class Player {
    public int PlayerID { get; set; }
    public string PlayerUssername { get; set; }
    public int PlayerLevel { get; set; }
    public List<Hero> Heros { get; set; }


    public Player(int PlayerID) {
        this.PlayerID = PlayerID;
        Heros = new List<Hero>();
    }

    public void AddHero(Hero hero) {
        Heros.Add(hero);
    }

    public void RemoveHero(Hero hero) {
        Heros.Remove(hero);
    }

    public List<Hero> GetHeros() {
        return Heros;
    }
}