namespace itemLib;
using heroLib;

public class Item {
    public string Name { get; }
    public ItemType ItemType { get; }
    public int Power { get; }

    public Item(string Name, ItemType ItemType, int Power) {
        this.Name = Name;
        this.ItemType = ItemType;
        this.Power = Power;
    }

    public void UseItem(Hero targetHero) {
        switch (ItemType) {
            // Item tipe Magic
            case ItemType.Magic:
                targetHero.MagicResistance += Power;
                Console.WriteLine($"{targetHero.Name} used {Name}. Magic Resistance increased by {Power}");
                break;
            // Item tipe Attack
            case ItemType.Attack:
                targetHero.AttackPower += Power;
                Console.WriteLine($"{targetHero.Name} used {Name}. Attack Power increased by {Power}");
                break;
            // Item tipe Defense
            case ItemType.Defense:
                targetHero.PhysicalResistance += Power;
                Console.WriteLine($"{targetHero.Name} used {Name}. Physical Resistance increased by {Power}");
                break;
            // Item tipe Heal
            case ItemType.Heal:
                targetHero.Health += Power;
                Console.WriteLine($"{targetHero.Name} used {Name}. Health increased by {Power}");
                break;
            default:
                break;
        }
    }
}

public enum ItemType {
    Magic,
    Attack,
    Defense,
    Heal
}