using System;
namespace MaShopMaui
{
  public static class Constants
  {
    public static int STATUS_NOT_FOUND = 0;
    public static int STATUS_AUTHENTICATED = 1;
    public static int STATUS_INVALID_PASSWORD = -1;
    public static int STATUS_INACTIVE = -2;
    public static int STATUS_PASSWORD_ALREADY_CREATED = -3;
    public static int STATUS_RECOVERY_CODE_EXPIRED = -4;
    public static int STATUS_RECOVERY_CODE_ALREADY_USED = -5;
    public static int STATUS_ACTIVATION_CODE_EXPIRED = -6;
    public static int STATUS_ACTIVATION_CODE_ALREADY_USED = -7;
  }
}

