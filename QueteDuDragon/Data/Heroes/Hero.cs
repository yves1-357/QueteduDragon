namespace QueteDuDragon.Data.Heroes
{
    public abstract class Hero
    {
        public string Name { get; set; }
        public int pointsVie { get; set; } = 5;
        public List<string> Skills { get; set; } = new List<string>();

        public List<string> Tools { get; set; } = new List<string>(); // outils achete au magasin 
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

        public int UseSkill(string skill)
        {
            Random random = new Random();
            return random.Next(10, 31);
        }

        public int UseTool(string tool)
        {
            Random random = new Random();
            return random.Next(5, 21);
        }

        public void TakeDamage(int damage)
        {
            pointsVie -= damage;
            if (pointsVie < 0) pointsVie = 0;
        }
        
    }

}

