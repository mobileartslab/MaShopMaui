using System;

namespace MaShopMaui
{
	public class MonkeyDataTemplateSelector : DataTemplateSelector
  {
    public DataTemplate AmericanMonkey { get; set; }
    public DataTemplate OtherMonkey { get; set; }

    protected override DataTemplate OnSelectTemplate(object item, BindableObject container)
    {
      return ((Monkey)item).Headline.Contains("America") ? AmericanMonkey : OtherMonkey;
    }
  }
}

