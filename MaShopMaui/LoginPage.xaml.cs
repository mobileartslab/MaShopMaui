using MaShopMaui.Services;

namespace MaShopMaui;

public partial class LoginPage : ContentPage
{
  public event EventHandler<string> OnError;

  public LoginPage()
  {
    InitializeComponent();
  }

  public string Password
  {
    get { return password.Text; }
    set { password.Text = value; }
  }

  public string Username
  {
    get { return username.Text; }
    set { username.Text = value; }
  }



  async void Button_Clicked(System.Object sender, System.EventArgs e)
  {
    usernameError.Text = "";
    passwordError.Text = "";
    submitError.Text = "";


    if (emailValidator.IsNotValid)
    {
      usernameError.Text = emailValidator.Errors[0].ToString();
      return;
    }

    if (passwordValidator.IsNotValid)
    {
      passwordError.Text = "Password is required";
      return;
    }

    var response = await ApiService.Login(Username, Password);

    if (response != null)
    {
      var authStatus = response.user.authStatus;
      if (authStatus == Constants.STATUS_AUTHENTICATED)
      {
        await Shell.Current.GoToAsync("mainPage");
      }
      else if (authStatus == Constants.STATUS_NOT_FOUND)
      {
        submitError.Text = "User not found";
      }
      else if (authStatus == Constants.STATUS_INVALID_PASSWORD)
      {
        submitError.Text = "Invalid login";
      }
    }
    else
    {
      submitError.Text = "Server Error";
      Console.WriteLine("Server Error");
    }

  }
}
