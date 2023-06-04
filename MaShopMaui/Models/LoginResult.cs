using System;
using MaShopMaui.Models;
using Newtonsoft.Json;

namespace MaShopMaui.Models
{
  public class LoginResult
  {
    public LoginResult()
    {
    }

    public string error { get; set; }
    [JsonProperty("result")]
    public LoginUser user { get; set; }
  }
}

