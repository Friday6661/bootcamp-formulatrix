namespace heroLib;
using playerLib;

public class Hero {
    public int HeroID { get; set; }
    public string Name { get; set; }
    public int Health { get; set; }
    public int AttackPower { get; set; }
    public int DefensePower { get; set; }
    public string Ability { get; set; }

    public Hero(int HeroID, string Name, int Health, int AttackPower, int DefensePower, string Ability = "") {
        this.HeroID = HeroID;
        this.Name = Name;
        this.Health = Health;
        this.AttackPower = AttackPower;
        this.DefensePower = DefensePower;
        this.Ability = Ability;
    }

    public void Attack(Hero target) {
        int damage = CalculateDamage(target);
        target.TakeDamage(damage);
    }

    public void Defend(int incomingDamage) {
        int damageTaken = incomingDamage - DefensePower;
        if (damageTaken > 0) {
            Health -= damageTaken;
        }
    }

    public void UseAbility() {
        // Implement the logic for using the unit's special ability
        if (Ability == "Heal") {
            
            // Implementasi logika untuk kemampuan heal
            Health += 20;
        }
        else if (Ability == "shield") {

            // Implementasi logika untuk kemampuan shield
            DefensePower += 5;
        }
        else if (Ability == "fire") {

            // Implementasi logika untuk kemampuan fire
            AttackPower += 10;
        }
        else {
            throw new System.Exception("Invalid ability");
        }
    }

    private int CalculateDamage(Hero target) {
        // Implement the logic for calculating the damage inflicted on the target unit
        int damage = AttackPower - target.DefensePower;
        return damage > 0 ? damage : 0;
    }

    private void TakeDamage(int damage) {
        Health -= damage;
    }
}