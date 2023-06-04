using System;
using System.Text;
using Newtonsoft.Json;
using MaShopMaui.Models;
using System.Net.Http.Headers;

namespace MaShopMaui.Services
{
  public class ApiService
  {
    public ApiService()
    {
    }

    public static async Task<LoginResult> Login(string email, string password)
    {
      var login = new Login()
      {
        username = email,
        password = password
      };

      var httpClient = new HttpClient();
      var json = JsonConvert.SerializeObject(login);
      var content = new StringContent(json, Encoding.UTF8, "application/json");
      var response = await httpClient.PostAsync(AppSettings.ApiUrl + "/public/login", content);
      if (!response.IsSuccessStatusCode) return null;
      var jsonResult = await response.Content.ReadAsStringAsync();
      var result = JsonConvert.DeserializeObject<LoginResult>(jsonResult);
      return result;
    }
  }
}

