namespace heroLib;

using System;
using itemLib;

public class Hero {
    public int HeroID { get; }
    public string Name { get; }
    public int Level { get; private set; }
    public int AttackPower { get; set; }
    public int AttackSpeed { get; set; }
    public int Health { get; set; }
    public int PhysicalResistance { get; set; }
    public int MagicResistance { get; set; }
    public string Skill1 { get; }
    public string Skill2 { get; }
    public HeroType HeroType { get; }
    public List<Item> Inventory { get; }

    // Buat Constructor
    public Hero(
        int HeroID,
        string Name,
        int AttackPower,
        int AttackSpeed,
        int Health,
        int PhysicalResistance,
        int MagicResistance,
        string Skill1,
        string Skill2,
        HeroType HeroType
    ) {
        this.HeroID = HeroID;
        this.Name = Name;
        Level = 1;
        this.AttackPower = AttackPower;
        this.AttackSpeed = AttackSpeed;
        this.Health = Health;
        this.PhysicalResistance = PhysicalResistance;
        this.MagicResistance = MagicResistance;
        this.Skill1 = Skill1;
        this.Skill2 = Skill2;
        this.HeroType = HeroType;
        this.Inventory = new List<Item>();
    }

    public void LevelUp() {
        if (Level < 8) {
            Level++;
            Console.WriteLine($"Hero {Name} has leveled up to level {Level}.");

            // Implementasi penambahan attribut berdasarkan tipe hero
            switch (HeroType) {
                // Case hero tipe Mage
                case HeroType.Mage:
                    AttackPower += 3;
                    MagicResistance += 3;
                    AttackSpeed += 1;
                    Health += 1;
                    PhysicalResistance += 1;
                    break;
                
                // Case hero tipe Fighter
                case HeroType.Fighter:
                    AttackPower += 3;
                    PhysicalResistance += 3;
                    AttackSpeed += 1;
                    Health += 1;
                    MagicResistance += 1;
                    break;
                
                // Case hero tipe Marksman
                case HeroType.Marksman:
                    AttackPower += 3;
                    AttackSpeed += 3;
                    Health += 1;
                    PhysicalResistance += 1;
                    MagicResistance += 1;
                    break;
                
                // Case hero tipe Assassins
                case HeroType.Assassins:
                    AttackPower += 4;
                    AttackSpeed += 4;
                    Health += 1;
                    MagicResistance += 1;
                    PhysicalResistance += 1;
                    break;
                
                // Case hero tipe Tank
                case HeroType.Tank:
                    MagicResistance += 3;
                    PhysicalResistance += 3;
                    Health += 3;
                    AttackPower += 1;
                    AttackSpeed += 1;
                    break;
                default:
                    break;
            }

            Console.WriteLine($"Update attributes: Attack Power = {AttackPower}, Attack Speed = {AttackSpeed}, Health = {Health}, Physical Resistance = {PhysicalResistance}, Magic Resistance = {MagicResistance}");
        }

        else {
            Console.WriteLine($"Hero {Name} is already Maximum level {Level}.");
        }
    }

    public void AddItem(Item item) {
        Inventory.Add(item);
        Console.WriteLine($"Hero {Name} obtained item {item.Name}");
    }

    public void UseItem(Item item, Hero target) {
        if (Inventory.Contains(item)) {
            item.UseItem(target);
            Inventory.Remove(item);
        }
        else {
            Console.WriteLine($"Item {item.Name} is not in the inventory of hero {Name}.");
        }
    }
    public void Attack(Hero target) {
        // Perform the attack logic here
        Console.WriteLine($"{Name} is attacking {target.Name}!");

        // Calculate the damage inflicted on the target based on the attacker's attack power
        int damage = AttackPower;

        // Apply the damage to the target's health
        target.Health -= damage;

        // Check if the target is defeated
        if (target.Health <= 0) {
            Console.WriteLine($"{target.Name} has been defeated!");
        }
    }

    public bool IsDefeated(){
        return Health <= 0;
    }

}
public enum HeroType {
    Mage,
    Fighter,
    Marksman,
    Assassins,
    Tank
}