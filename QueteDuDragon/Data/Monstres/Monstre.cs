namespace QueteDuDragon.Data.Monstres
{
    public abstract class Monstre
    {
        public string Nom { get; set; }
        public int PointsVie { get; set; }
        public List<string> Skills { get; set; }
        public string Image { get; set; }

        public Monstre(string nom, int pointsVie, string image)
        {
            Nom = nom;
            PointsVie = pointsVie;
            Image = image;
            Skills = new List<string>();
        }

        public abstract void InitializeSkills();

        public void TakeDamage(int damage)
        {
            PointsVie -= damage;
            if (PointsVie < 0) PointsVie = 0;
        }
    }
}



