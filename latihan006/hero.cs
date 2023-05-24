namespace heroLib;
class Hero {
    public Assasins? totalAssasins;
    // Constructor
    public void SetAssasins(Assasins x) {
        totalAssasins = x;
    }
    public Assasins GetTotalAssasins() {
        return totalAssasins;
    }
}

class Assasins {
    public int AssasinsId;
    public string AssasinsName;
    public Skill totalSkill;
    public Assasins(Skill x) {
        totalSkill = x;
        AssasinsId = 0;
        AssasinsName = "Friday";
    }
}

class Skill {
    public int SkillCooldown;

    public Skill() {
        SkillCooldown = 10;
    }
}