using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace QueteDuDragon.Data.Heroes;

public abstract class Hero
{
    private ObservableCollection<string> _objetsCollectes = new();

    public Hero(string name)
    {
        Name = name;
        objetsCollectes.CollectionChanged += OnObjetsCollectesChanged;
    }

    public string Name { get; set; }
    public int pointsVie { get; set; } = 5;

    // Le niveau dépend directement du nombre d'objets collectés
    public int Level
    {
        get
        {
            var objetsCount = objetsCollectes.Count;
            if (objetsCount >= 7) return 3;
            if (objetsCount >= 3) return 2;
            return 1;
        }
    }

    public List<string> Skills { get; set; } = new();
    public List<string> Tools { get; set; } = new(); // outils achetés au magasin 

    public ObservableCollection<string> objetsCollectes
    {
        get => _objetsCollectes;
        set
        {
            if (_objetsCollectes != value)
            {
                if (_objetsCollectes != null) _objetsCollectes.CollectionChanged -= OnObjetsCollectesChanged;

                _objetsCollectes = value;

                if (_objetsCollectes != null) _objetsCollectes.CollectionChanged += OnObjetsCollectesChanged;

                OnPropertyChanged();
                OnPropertyChanged(nameof(Level)); // Met à jour le niveau automatiquement
            }
        }
    }

    public int Row { get; set; } = 6;
    public int Col { get; set; } = 9;

    public int AllowedPurchases => Level switch
    {
        1 => 3,
        2 => 4,
        3 => 7,
        _ => 0
    };

    public void AjouterObjet(string objets)
    {
        if (!objetsCollectes.Contains(objets)) // Empêche les doublons
            objetsCollectes.Add(objets);
    }

    private void OnObjetsCollectesChanged(object sender,
        NotifyCollectionChangedEventArgs e)
    {
        OnPropertyChanged(nameof(Level)); // Notifie que le niveau a changé
    }

    public virtual void InitializeSkills()
    {
        // Vide par défaut
    }

    public int UseSkill(string skill)
    {
        var random = new Random();
        return random.Next(10, 31);
    }

    public int UseTool(string tool)
    {
        var random = new Random();
        return random.Next(5, 21);
    }

    public void TakeDamage(int damage)
    {
        pointsVie -= damage;
        if (pointsVie < 0) pointsVie = 0;
    }

    public event PropertyChangedEventHandler? PropertyChanged;

    protected void OnPropertyChanged([CallerMemberName] string propertyName = null)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
}