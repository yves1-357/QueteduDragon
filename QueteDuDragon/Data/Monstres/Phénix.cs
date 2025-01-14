namespace QueteDuDragon.Data.Monstres
{
    public class Phenix : Monstre
    {
        public Phenix() : base("Phénix", 100, "phenix.png")
        {
            InitializeSkills();
        }

        public override void InitializeSkills()
        {
            Skills.Add("Flammes destructrices");
            Skills.Add("Renaissance des cendres");
        }
    }
}