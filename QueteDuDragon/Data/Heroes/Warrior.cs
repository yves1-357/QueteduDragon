namespace QueteDuDragon.Data.Heroes;

public class Warrior : Hero
    {
        public Warrior(): base("Guerrier")
        {
            pointsVie = 5;
            Level = 1;
            Skills = new List<string> { "Attaque de base","Coup de bouclier", "Cri de guerre" };
        }
        public override void InitializeSkills()
        {
            Skills.Add("Attaque de base");
            Skills.Add("Coup de bouclier");
            Skills.Add("Cri de guerre");
        }
    }
