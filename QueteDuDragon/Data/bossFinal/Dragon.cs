namespace QueteDuDragon.Data.bossFinal;
using QueteDuDragon.Data.Heroes;

public class Dragon : BossFinal
{
    public  string Name { get; set; } = "Dragon de feu";
    public  int pointsVie { get; set; } =  100; // Nombre eleves de points pour le mode 'facile'

    public List<string> Skills { get; set; } = new List<string>
        { "Puissant crache feu", "Griffes tranchantes", "Rugissement terrifiant" };

    public int AttackPower()
    {
        Random random = new Random();
        int[] damages = { 50, 30, 20 }; // Dégâts correspondant aux compétences
        int index = random.Next(damages.Length);
        return damages[index];// Retourne les dégâts associés à l'index
    }

    public new void TakeDamage(int damage)  // Réduit les points de vie du dragon en fonction des dégâts reçus
    {
        pointsVie -= damage;
        if (pointsVie < 0) pointsVie = 0;
    }

        
    public bool isDefeated => pointsVie <= 0;  // Indique si le dragon est vaincu

        
    public void Attack(Hero hero)  // réduit points de vie du heros 
        {
            hero.pointsVie -= AttackPower();
        }

    public bool TryEvade() // chance d'esquiver en pourcentage
    {
        Random random = new Random();
        return random.Next(0, 100) < 20;  // 20% de chance d'esquiver
    }
   public override void InitializeSkills() 
   {
        // Initialise les compétences spécifiques au Dragon
    }

   public int UseSkill(string skill)
   {
       return skill switch
       {
           "Puissant crache feu" => 15,
           "Griffes tranchantes" => 20,
           "Rugissement terrifiant" => 10,
           _ => 5
       };
   }

   public string ChooseSkill()
   {
       Random random = new Random();
       return Skills[random.Next(Skills.Count)];
   }
   
}
