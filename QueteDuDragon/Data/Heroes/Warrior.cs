namespace QueteDuDragon.Data.Heroes;

public class Warrior : Hero
    {
        public Warrior(): base("Guerrier"){}
        public override void InitializeSkills()
        {
            Skills.Add("Attaque puissante");
            Skills.Add("Coup de bouclier");
            Skills.Add("Cri de guerre");
        }
    }
