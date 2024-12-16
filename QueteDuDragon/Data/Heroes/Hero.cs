namespace QueteDuDragon.Data.Heroes
{
    public abstract class Hero
    {
        public string Name { get; set; }
        public int pointsVie { get; set; } = 5;
        public List<string> Skills { get; set; } = new List<string>();
        public List<string> objetsCollectes { get; set; } = new List<string>();
        public int niveauExperience { get; set; } = 1;

        public Hero(string name)
        {
            Name = name;
            
        }

        public void AjouterObjet(string objets)
        {
            objetsCollectes.Add(objets);
            UpdateniveauExperience();
        }

        private void UpdateniveauExperience()
        {
            int objetsCount = objetsCollectes.Count;
            if (objetsCount >= 7) niveauExperience = 3;
            else if (objetsCount >= 4) niveauExperience = 2;
        }
        
        public virtual void InitializeSkills()
        {
            // Vide par défaut
        }
        
    }

}

