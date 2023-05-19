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
        Category = "GIBSON",
        Headline = "Les Paul Custom - Ebony with Ebony Fingerboard",
        SubHeadline = "The One, the Only Les Paul Custom",
        Content = "With its sonic punch, fluid playability, and classic \"tuxedo\" appointments, the Les Paul Custom is equal parts elegance and brute strength. Fitted with a matched 490/498 humbucker set that takes you from mellow jazz tones to full shred with a pinky twist, this majestic beast is ultra-responsive to your touch. Its fast-action neck, smooth-as-silk ebony fingerboard, and medium jumbo frets facilitate the speedy, dexterous fretwork we\'ve heard across prog, fusion, and hard rock genres from guitar virtuosos like Robert Fripp, Al Di Meola, and Zakk Wylde. Gibson\'s Custom Shop luthiers selected premium mahogany for the body and capped it with a 2-piece carved maple top — a classic recipe for rich, sustaining, articulate tone that\'ll slice right through the mix.",
        ImageUrl = "lp1.png"
      });

      source.Add(new Monkey
      {
        Category = "GIBSON",
        Headline = "Slash Les Paul Standard Electric Guitar - November Burst",
        SubHeadline = "Whet Your Appetite with Slash\'s Signature Gibson Les Paul Standard",
        Content = "Part of Gibson\'s Slash Collection, the Slash Les Paul Standard is a solidbody electric guitar that\'s worthy of its namesake. Inject your playing with incredible warmth and sustain, thanks to a resonant solid mahogany body, that\'s accented by an eye-catching AAA figured maple top. Enjoy unbelievable playability, courtesy of a comfortable rosewood-capped \"C\"-shaped neck. And when you plug into your British stack, you\'ll experience a mid-forward sustain and crunch that every Slash fan is sure to recognize, by virtue of dual Custom Burstbucker Alnico II pickups. The Slash Les Paul Standard sports handwired electronics, color-coordinated hardware, and a bevy of special Slash-approved touches.",
        ImageUrl = "lp2.png"
      });

      source.Add(new Monkey
      {
        Category = "GIBSON",
        Headline = "Les Paul Standard \'60s Electric Guitar - Iced Tea",
        SubHeadline = "Burstbucker pickups deliver vintage PAF tone",
        Content = "When it comes to capturing vintage Patent Applied For (PAF) humbucker tone, nothing beats the sound of this Les Paul Standard 60\'s Burstbucker pickups. These magnets — along with period-correct unmatched windings on the bobbins — capture the subtle historical variations in true humbucker tone. Plug into your favorite amp, and experience smooth low-end response, complex midrange crunch, and sweet-sounding highs. These pickups sound great clean or they can be used to push your amp into overdrive for the legendary fat, snarling tone you can only get with a humbucker. Under the hood, the control assembly is handwired with matched potentiometers and Orange Drop capacitors, ensuring that you\'ll hear the mellifluous voice of your Les Paul Standard \'60s in all its glory, even when you back down your volume. It\'s all driven by a nimble 3-way toggle switch for lightning-fast access to those glorious heritage tones.",
        ImageUrl = "lp3.png"
      });

      source.Add(new Monkey
      {
        Category = "GIBSON",
        Headline = "Les Paul Standard \'50s Electric Guitar - Gold Top",
        SubHeadline = "Les Paul Standard \'50s: Born to Rock",
        Content = "Les Paul Standard \'50s: Born to Rock\", content: \"From its carved maple top to its stockpile of premium features, the Gibson Les Paul Standard \'50s is ready to rock. Burstbucker pickups and handwired electronics deliver a massive tone arsenal. And you\\'ll enjoy effortless playability courtesy of a satisfying vintage \'50s profile neck and fast-action rosewood fingerboard. If you\'ve been wanting a modern Les Paul with a chunky neck feel and premium appointments, Sweetwater has your axe. The Gibson Les Paul Standard \'50s is the guitar you\'ve been waiting for.",
        ImageUrl = "lp4.png"
      });

      source.Add(new Monkey
      {
        Category = "GIBSON",
        Headline = "Les Paul Standard \'60s Electric Guitar - Bourbon Burst",
        SubHeadline = "Les Paul Standard \'60s: Born to Rock",
        Content = " From its carved maple top to its stockpile of premium features, the Gibson Les Paul Standard \'60s is ready to rock. 60s Burstbucker pickups and handwired electronics deliver a massive tone arsenal. And you\\'ll enjoy effortless playability courtesy of a fast SlimTaper-profile neck and silky-smooth rosewood fingerboard with Plek\'d frets. If you\'ve been wanting a modern Les Paul with a slinky \'60s feel and premium appointments, Sweetwater has your axe. The Gibson Les Paul Standard \'60s is the guitar you\'ve been waiting for.",
        ImageUrl = "lp5.png"
      });

      source.Add(new Monkey
      {
        Category = "EPIPHONE",
        Headline = "Les Paul Classic Electric Guitar - Heritage Cherry Sunburst",
        SubHeadline = "Classic Looks and a Killer Sound",
        Content = "Modeled after Les Paul Standards produced in the late 1950s, the Epiphone Les Paul Classic has timeless visual appeal. And its modern appointments contribute to a stellar sounding LP that plays great but won\'t break the bank. Guitarists at Sweetwater were impressed by the Epiphone Les Paul Classic\'s balanced tone that evokes the sound and vibe of countless classic and modern rock hits. And, they were blown away by the super-hot Alnico Classic PRO pickups and the premium hardware and electronics package that make this guitar a total tone monster. For a legendary look and a killer sound, wrap your hands around the Les Paul Classic from Epiphone.",
        ImageUrl = "lp6.png"
      });

      source.Add(new Monkey
      {
        Category = "GIBSON",
        Headline = "Les Paul Classic: Iconic Tone and Uncompromising Playability",
        SubHeadline = "Les Paul Classic: Iconic Tone and Uncompromising Playability",
        Content = "Strap on Gibson\'s Les Paul Classic, and you\'ll experience iconic tone and uncompromising playability. A time-tested combination of maple and mahogany serves up the tone that\'s fueled a million rock anthems, while 60s Burstbucker pickups inject your playing with loads of midrange muscle and sizzling overtones. You also get coil tapping, phase reversal, and pure bypass options for an endless variety of tonal textures. As for playing comfort, the Les Paul Classic feels as amazing as it sounds, thanks to a SlimTaper neck and easy-playing rosewood fingerboard. The Les Paul Classic includes a self-lubricating Graph Tech nut, Tune-o-matic bridge, vintage-style Grover Rotomatic tuners, and gold top hat knobs.",
        ImageUrl = "lp7.png"
      });

      source.Add(new Monkey
      {
        Category = "GIBSON",
        Headline = "Les Paul Studio - Ebony",
        SubHeadline = "Weight-relieved, Coil-tapped Gibson Les Paul Studio with Endless Player Potential",
        Content = "The Gibson Les Paul Studio is celebrated by live performers and session players alike. The modern Studio covers even wider sonic territory with its coil-tapped 490R/498T humbucking pickups. This combination unlocks plenty of creative textures to flesh out musical ideas, from classic cleans and modern crunch to single-coil cluck. The Gibson Les Paul Studio also benefits from an Ultra-modern weight-relieved body; this reduction of more than a pound in weight provides extra comfort for extended sessions and performances. A feature your fingers will thank you for is the SlimTaper mahogany guitar neck, which re-creates the speed and playability some of the \'60s Les Pauls are known for. Dependable Grover Rotomatic tuners keep this Gibson Les Paul Studio pitch-perfect and ready to rock.",
        ImageUrl = "lp8.png"
      });

      Monkeys = new ObservableCollection<Monkey>(source);
    }

    void FilterItems(string filter)
    {
      var filteredItems = source.Where(monkey => monkey.Category.ToLower().Contains(filter.ToLower())).ToList();
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
      SelectedMonkeyMessage = $"Selection {selectionCount}: {SelectedMonkey.Category}";
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

    void OnPropertyChanged([CallerMemberName] string propertyCategory = null)
    {
      PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyCategory));
    }
    #endregion
  }
}
