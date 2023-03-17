namespace MaShopMaui;

public partial class LoginPage : ContentPage
{
	public LoginPage()
	{
		InitializeComponent();
	}

  async void Button_Clicked(System.Object sender, System.EventArgs e)
  {
    await Shell.Current.GoToAsync("mainPage");
  }
}
