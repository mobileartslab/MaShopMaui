using System;

namespace MaShopMaui
{
	public class InventoryDataTemplateSelector : DataTemplateSelector
  {
    public DataTemplate AmericanInventory { get; set; }
    public DataTemplate OtherInventory { get; set; }

    protected override DataTemplate OnSelectTemplate(object item, BindableObject container)
    {
      return ((Inventory)item).Headline.Contains("America") ? AmericanInventory : OtherInventory;
    }
  }
}

