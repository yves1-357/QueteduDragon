using System.ComponentModel;
using System.Runtime.CompilerServices;
using QueteDuDragon.Data.Heroes;
using QueteDuDragon.Data.bossFinal;

namespace QueteDuDragon.Data
{
    public class EtatJeu : INotifyPropertyChanged
    {
        
        private Hero selectedHero;
        public Hero SelectedHero
        {
            get => selectedHero;
            set
            {
                if (selectedHero != value)
                {
                    selectedHero = value;
                    OnPropertyChanged(nameof(SelectedHero));
                }
            }
        }
        
        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
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

        public List<string> objetsCollectes = new List<string>();
        public List<string> ObjetsCollectes => objetsCollectes;

        private bool isCombatActive ;
        public bool IsCombatActive
        {
            get => isCombatActive;
            set
            {
                isCombatActive = value;
                OnPropertyChanged(nameof(IsCombatActive));
            }
        }

        private int combatTurns ;
        public int CombatTurns
        {
            get => combatTurns;
            set
            {
                combatTurns = value;
                OnPropertyChanged(nameof(CombatTurns));
            }
        }

        private string selectedMode = "";
        public string SelectedMode
        {
            get => selectedMode;
            set
            {
                selectedMode = value;
                OnPropertyChanged(nameof(SelectedMode));
            }
        }

        public const int MaxTurns = 10;

        public EtatJeu()
        {
            
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
            BossFinal = new Dragon(); // Réinitialise le boss au début du combat
        }

        public void EndCombat()
        {
            IsCombatActive = false;
        }

        public void AjouterObjetCollecte(string collecte)
        {
            ObjetsCollectes.Add(collecte);
            OnPropertyChanged(nameof(ObjetsCollectes));
        }

        public void IncrementCombatTurns()
        {
            CombatTurns++;
            if (CombatTurns >= MaxTurns)
            {
                EndCombat();
                throw new InvalidOperationException("Vous avez dépassé la limite de tours. Le bossFinal vous a vaincu!");
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
}
