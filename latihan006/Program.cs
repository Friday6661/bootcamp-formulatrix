using heroLib;
using System;

static class Program {
    static void Main(string[] args) {
        Hero h001 = new Hero();
        Skill heroSkill = new Skill();
        Assasins heroAssasins = new Assasins(heroSkill);

        h001.SetAssasins(heroAssasins);
        h001.totalAssasins = heroAssasins;

        Assasins assasinskosong = h001.GetTotalAssasins();

        int x = assasinskosong.AssasinsId;
        string y = assasinskosong.AssasinsName;

        Console.WriteLine(h001.totalAssasins.totalSkill.SkillCooldown);
    }
}