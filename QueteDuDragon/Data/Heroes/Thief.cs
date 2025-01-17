namespace QueteDuDragon.Data.Heroes;

public class Thief : Hero
    {
        public Thief() : base("Voleur","thief.png")
        {
            
            pointsVie = 5;
            Level = 1;
            Skills = new List<string> {"Flèche empoisonnée" ,"Piège","Disparition"  };
        }
        public override void InitializeSkills()
        {
            Skills.Add("Flèche empoisonnée");
            Skills.Add("Piège");
            Skills.Add("Disparition");
        }
    }
