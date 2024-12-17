namespace QueteDuDragon.Data;

using QueteDuDragon.Data.Heroes;

public class EtatJeu
{
    public Hero? SelectedHero { get; set; }

    public void SelectHero(Hero hero)
    {
        SelectedHero = hero; 
    }
}