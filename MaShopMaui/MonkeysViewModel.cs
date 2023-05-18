using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;

namespace MaShopMaui
{
  public class MonkeysViewModel : INotifyPropertyChanged
  {
    readonly IList<Monkey> source;
    Monkey selectedMonkey;
    int selectionCount = 1;

    public ObservableCollection<Monkey> Monkeys { get; private set; }
    public IList<Monkey> EmptyMonkeys { get; private set; }

    public Monkey SelectedMonkey
    {
      get
      {
        return selectedMonkey;
      }
      set
      {
        if (selectedMonkey != value)
        {
          selectedMonkey = value;
        }
      }
    }

    ObservableCollection<object> selectedMonkeys;
    public ObservableCollection<object> SelectedMonkeys
    {
      get
      {
        return selectedMonkeys;
      }
      set
      {
        if (selectedMonkeys != value)
        {
          selectedMonkeys = value;
        }
      }
    }

    public string SelectedMonkeyMessage { get; private set; }

    public ICommand DeleteCommand => new Command<Monkey>(RemoveMonkey);
    public ICommand FavoriteCommand => new Command<Monkey>(FavoriteMonkey);
    public ICommand FilterCommand => new Command<string>(FilterItems);
    public ICommand MonkeySelectionChangedCommand => new Command(MonkeySelectionChanged);

    public MonkeysViewModel()
    {
      source = new List<Monkey>();
      CreateMonkeyCollection();

      selectedMonkey = Monkeys.Skip(3).FirstOrDefault();
      MonkeySelectionChanged();

      SelectedMonkeys = new ObservableCollection<object>()
            {
                Monkeys[1], Monkeys[3], Monkeys[4]
            };
    }

    void CreateMonkeyCollection()
    {
      source.Add(new Monkey
      {
        Name = "GIBSON",
        Location = "Les Paul Custom - Ebony with Ebony Fingerboard",
        Details = "Baboons are African and Arabian Old World monkeys belonging to the genus Papio, part of the subfamily Cercopithecinae.",
        ImageUrl = "lp1.png"
      });

      source.Add(new Monkey
      {
        Name = "GIBSON",
        Location = "Slash Les Paul Standard Electric Guitar - November Burst",
        Details = "The capuchin monkeys are New World monkeys of the subfamily Cebinae. Prior to 2011, the subfamily contained only a single genus, Cebus.",
        ImageUrl = "lp2.png"
      });

      source.Add(new Monkey
      {
        Name = "GIBSON",
        Location = "Les Paul Standard \'60s Electric Guitar - Iced Tea",
        Details = "The squirrel monkeys are the New World monkeys of the genus Saimiri. They are the only genus in the subfamily Saimirinae. The name of the genus Saimiri is of Tupi origin, and was also used as an English name by early researchers.",
        ImageUrl = "lp3.png"
      });

      source.Add(new Monkey
      {
        Name = "GIBSON",
        Location = "Les Paul Standard \'50s Electric Guitar - Gold Top",
        Details = "The golden lion tamarin also known as the golden marmoset, is a small New World monkey of the family Callitrichidae.",
        ImageUrl = "lp4.png"
      });

      source.Add(new Monkey
      {
        Name = "GIBSON",
        Location = "Les Paul Standard \'60s Electric Guitar - Bourbon Burst",
        Details = "Howler monkeys are among the largest of the New World monkeys. Fifteen species are currently recognised. Previously classified in the family Cebidae, they are now placed in the family Atelidae.",
        ImageUrl = "lp5.png"
      });

      source.Add(new Monkey
      {
        Name = "EPIPHONE",
        Location = "Les Paul Classic Electric Guitar - Heritage Cherry Sunburst",
        Details = "The Japanese macaque, is a terrestrial Old World monkey species native to Japan. They are also sometimes known as the snow monkey because they live in areas where snow covers the ground for months each",
        ImageUrl = "lp6.png"
      });

      source.Add(new Monkey
      {
        Name = "GIBSON",
        Location = "Les Paul Classic: Iconic Tone and Uncompromising Playability",
        Details = "The mandrill is a primate of the Old World monkey family, closely related to the baboons and even more closely to the drill. It is found in southern Cameroon, Gabon, Equatorial Guinea, and Congo.",
        ImageUrl = "lp7.png"
      });

      source.Add(new Monkey
      {
        Name = "GIBSON",
        Location = "Les Paul Studio - Ebony",
        Details = "The proboscis monkey or long-nosed monkey, known as the bekantan in Malay, is a reddish-brown arboreal Old World monkey that is endemic to the south-east Asian island of Borneo.",
        ImageUrl = "lp8.png"
      });

      Monkeys = new ObservableCollection<Monkey>(source);
    }

    void FilterItems(string filter)
    {
      var filteredItems = source.Where(monkey => monkey.Name.ToLower().Contains(filter.ToLower())).ToList();
      foreach (var monkey in source)
      {
        if (!filteredItems.Contains(monkey))
        {
          Monkeys.Remove(monkey);
        }
        else
        {
          if (!Monkeys.Contains(monkey))
          {
            Monkeys.Add(monkey);
          }
        }
      }
    }

    void MonkeySelectionChanged()
    {
      SelectedMonkeyMessage = $"Selection {selectionCount}: {SelectedMonkey.Name}";
      OnPropertyChanged("SelectedMonkeyMessage");
      selectionCount++;
    }

    void RemoveMonkey(Monkey monkey)
    {
      if (Monkeys.Contains(monkey))
      {
        Monkeys.Remove(monkey);
      }
    }

    void FavoriteMonkey(Monkey monkey)
    {
      monkey.IsFavorite = !monkey.IsFavorite;
    }

    #region INotifyPropertyChanged
    public event PropertyChangedEventHandler PropertyChanged;

    void OnPropertyChanged([CallerMemberName] string propertyName = null)
    {
      PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
    #endregion
  }
}
