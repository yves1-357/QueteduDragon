namespace QueteDuDragon.Data.Monstres
{
    public class Gobelins : Monstre
    {
        public Gobelins() : base("Gobelins", 30, "images/Monstres/gobelins.png")
        {
            InitializeSkills();
        }

        public override void InitializeSkills()
        {
            Skills.Add("Attaque en groupe");
            Skills.Add("Coup rapide");
        }
    }
}