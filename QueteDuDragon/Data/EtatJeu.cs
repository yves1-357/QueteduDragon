namespace QueteDuDragon.Data;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using QueteDuDragon.Data.Heroes;
using QueteDuDragon.Data.bossFinal;


public class EtatJeu : INotifyPropertyChanged
{
    private Hero? selectedHero;
    public Hero? SelectedHero
    {
        get => selectedHero;
        set
        {
            selectedHero = value;
            OnPropertyChanged();
        }
    }

    private Dragon bossFinal = new Dragon();
    public Dragon BossFinal
    {
        get => bossFinal;
        set
        {
            bossFinal = value;
            OnPropertyChanged(nameof(BossFinal));
        }
    }

    public List<string> objetsCollectes = new List<string>(); // Liste modifiable privée
    public List<string> ObjetsCollectes // Propriété publique exposant la liste
    {
        get => objetsCollectes;
        set
        {
            objetsCollectes = value;
            OnPropertyChanged(nameof(ObjetsCollectes));
        }
    }

    private bool isCombatActive;
    public bool IsCombatActive
    {
        get => isCombatActive;
        set
        {
            isCombatActive = value;
            OnPropertyChanged(nameof(IsCombatActive));
        }
    }

    private int combatTurns;
    public int CombatTurns
    {
        get => combatTurns;
        set
        {
            combatTurns = value;
            OnPropertyChanged(nameof(CombatTurns));
        }
    }

    private string _selectedMode = "";
    public string SelectedMode
    {
        get => _selectedMode;
        set
        {
            _selectedMode = value;
            OnPropertyChanged();
        }
    }
    
    public event PropertyChangedEventHandler? PropertyChanged;

    protected void OnPropertyChanged([CallerMemberName] string propertyName = null)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }

    public const int MaxTurns = 10;

    public EtatJeu()
    {
        SelectedHero = new Warrior { Name = "Guerrier" }; //////**********
    }

    

    public void SelectHero(Hero hero)
    {
        SelectedHero = hero;
    }

    public void StartCombat()
    {
        if (SelectedHero == null)
        {
            throw new InvalidOperationException("Aucun héros sélectionné.");
        }

        IsCombatActive = true;
        BossFinal = new Dragon();
    }

    public void EndCombat()
    {
        IsCombatActive = false;
    }

    public void AjouterObjetCollecte(string collecte)
    {
        objetsCollectes.Add(collecte); // La liste privée est modifiable.
        OnPropertyChanged(nameof(ObjetsCollectes)); // Mise à jour de l'interface utilisateur
    }

    public void IncrementCombatTurns()
    {
        CombatTurns++;
        if (CombatTurns >= MaxTurns)
        {
            EndCombat();
            throw new InvalidOperationException("Vous avez dépassé la limite de tours. Le bossFinal vous a vaincu !");
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
