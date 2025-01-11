namespace QueteDuDragon.Data.Heroes;

public class Mage : Hero
    {
        public Mage(): base("Mage"){}
        public override void InitializeSkills()
        {
            Skills.Add("Boule de feu");
            Skills.Add("Soigné les blessés");
            Skills.Add("Bouclier magique");
        }
    }
