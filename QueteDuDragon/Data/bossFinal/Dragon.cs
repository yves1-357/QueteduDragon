namespace QueteDuDragon.Data.bossFinal;
using QueteDuDragon.Data.Heroes;


public class Dragon
{ 
    public int pointsVie { get; set; } = 10;
        public int AttackPower { get; set; } = 1;

        public bool isDefeated => pointsVie <= 0;

        public void Attack(Hero hero)
        {
            hero.pointsVie -= AttackPower;
        }
    }
