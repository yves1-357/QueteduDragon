using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using QueteDuDragon.Data.bossFinal;
using QueteDuDragon.Data.Heroes;

namespace QueteDuDragon.Data;

public class EtatJeu : INotifyPropertyChanged
{
    public const int MaxTurns = 10;

    private string _selectedMode = "";

    private Dragon bossFinal = new();

    private int combatTurns;

    private bool isCombatActive;
    private Hero? selectedHero;

    public EtatJeu()
    {
        // Par défaut, crée un Guerrier initial
        SelectedHero = new Warrior { Name = "Guerrier" };
    }

    public Hero? SelectedHero
    {
        get => selectedHero;
        set
        {
            if (selectedHero != value)
            {
                selectedHero = value;

                // Notifie que le héros a changé
                OnPropertyChanged();

                // Notifie que la liste "ObjetsCollectes" a changé avec le nouveau héros
                OnPropertyChanged(nameof(ObjetsCollectes));
            }
        }
    }

    public Dragon BossFinal
    {
        get => bossFinal;
        set
        {
            bossFinal = value;
            OnPropertyChanged();
        }
    }

    // Collection des objets collectés basée sur le héros sélectionné
    public ObservableCollection<string> ObjetsCollectes =>
        // Renvoie les objets collectés par le héros actif, sinon une liste vide
        SelectedHero?.objetsCollectes ?? new ObservableCollection<string>();

    public bool IsCombatActive
    {
        get => isCombatActive;
        set
        {
            isCombatActive = value;
            OnPropertyChanged();
        }
    }

    public int CombatTurns
    {
        get => combatTurns;
        set
        {
            combatTurns = value;
            OnPropertyChanged();
        }
    }

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

    public void SelectHero(Hero hero)
    {
        SelectedHero = hero;
    }

    public void StartCombat()
    {
        if (SelectedHero == null) throw new InvalidOperationException("Aucun héros sélectionné.");

        IsCombatActive = true;
        BossFinal = new Dragon();
    }

    public void EndCombat()
    {
        IsCombatActive = false;
    }

    public void AjouterObjetCollecte(string collecte)
    {
        if (SelectedHero != null)
        {
            SelectedHero.AjouterObjet(collecte); // Ajoute l'objet directement à la collection
            OnPropertyChanged(nameof(ObjetsCollectes));
            OnPropertyChanged(nameof(SelectedHero.Level));
        }
        else
        {
            throw new InvalidOperationException("Aucun héros sélectionné pour collecter l'objet.");
        }
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
        if (mode != "Facile" && mode != "Difficile") throw new ArgumentException("Mode invalide");

        SelectedMode = mode;
    }
}