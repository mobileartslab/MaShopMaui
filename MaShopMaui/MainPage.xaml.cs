﻿namespace MaShopMaui;

public partial class MainPage : ContentPage
{
	public MainPage()
	{
		InitializeComponent();
    BindingContext = new InventoryViewModel();
  }
}


