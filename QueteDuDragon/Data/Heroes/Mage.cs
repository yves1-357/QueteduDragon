namespace QueteDuDragon.Data.Heroes;

public class Mage : Hero
{
    public Mage() : base("Mage")
    {
        pointsVie = 5;
        Skills = new List<string> { "Boule de feu", "Soigné les blessés", "Bouclier magique" };
    }

    public override void InitializeSkills()
    {
        Skills.Add("Boule de feu");
        Skills.Add("Soigné les blessés");
        Skills.Add("Bouclier magique");
    }
}