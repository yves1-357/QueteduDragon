namespace QueteDuDragon.Data;

using QueteDuDragon.Data.Heroes;
using QueteDuDragon.Data.bossFinal;


public class EtatJeu
{
    public Hero SelectedHero { get; set; }
    public EtatJeu()
    {
        SelectedHero = new Warrior { Name = "Héros par défaut" }; // Exemple de valeur par défaut
    }

    public Dragon bossFinal { get; set; } = new Dragon(); // Initialisation du BossFinal

    public List<string> objetsCollectes { get; private set; } = new List<string>();  // Suivi des objets collectés

    public bool IscombatActive { get; set; } = false; // etat du combat
    
    public int CombatTurns { get; set; } = 0;
    public const int MaxTurns = 10;

    public string SelectedMode { get; set; } = ""; // mode de jeu (facile, difficile)

    public void SelectHero(Hero hero)
    {
        SelectedHero = hero; 
    }

    public void StartCombat() // methode (demarrer le combat)
    {
        if (SelectedHero == null)
        {
            throw new InvalidOperationException("Aucun héros sélectionné.");
        }

        IscombatActive = true;
        bossFinal = new Dragon(); // reinitialise le boss au debut du combat
        //bossFinal.InitializeSkills(); // Si nécessaire pour initialiser les compétences du boss
        

    }

    public void EndCombat()
    {
        IscombatActive = false;
    }

    public void objetsCollecte(string Collecte)
    {
        objetsCollectes.Add(Collecte);

        if (objetsCollectes.Count >= 4) // Possibilité de déclencher un combat si 4 objets sont collectés
        {
            StartCombat();
            // aller au magasin ( à rajouter)
        }
    }



    public void IncrementCombatTurns()
    {
        CombatTurns++;
        if (CombatTurns >= MaxTurns)
        {
            EndCombat();
            throw new InvalidOperationException("Vous avez dépassé la limite de tours. Le bossFinal vous a vaincu:!");
            
        }
    }
    public void SetMode(string mode)
    {
        if (mode != "Facile" && mode != "Difficile")
        {
            throw new ArgumentException("Mode invalide");
        }
        SelectedMode = mode;
    }
}