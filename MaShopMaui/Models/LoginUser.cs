using System;
namespace MaShopMaui.Models
{
  public class LoginUser
  {
    public LoginUser()
    {
    }

    public string username { get; set; }
    public string password { get; set; }
    public string salt { get; set; }
    public int authStatus { get; set; }
  }
}

