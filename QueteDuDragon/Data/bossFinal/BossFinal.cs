namespace QueteDuDragon.Data.bossFinal;

public class BossFinal
{
  
    public int pointsVie { get; set; }

    public virtual void InitializeSkills()
    {
        // Implémentation par défaut pour les boss
    }

    public void TakeDamage(int damage)
    {
        pointsVie -= damage;
        if (pointsVie < 0) pointsVie = 0;
    }
}
