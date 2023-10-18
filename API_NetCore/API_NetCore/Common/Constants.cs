namespace API_NetCore.Common
{
    public class Constants
    {
        public class Cookies
        {
            public const string TokenAdmin = "token_admin";
            public const string TokenUser = "token_user";
            public const string KeyAdmin = "ton0YlkER9ZMjqhH2BCd-";
            public const string KeyUser = "TN4Xx1Be9jzzb38PD9GR-";
        }

        public class Regular
        {
            public const string ElearningCssVersion = "2023.03.14";
            public const string CssVersion = "2023.03.19";
            public const string CssVersionAdmin = "2023.03.14";
            public const string ApiVersion = "2023.03.14";
            public const string EmailEndWith = "@ominext.com";

            public static int TokenExpireTime = 12;
            public static int TokenUserExpireTime = 12;
            public static int OtpExpire = 5;

            public static string CurrentUserAdminKey = "CURRENT_USER_ADMIN";
            public static string CurrentUserCustomerKey = "CURRENT_USER_CUSTOMER";
            public static string ApiUrl = "http://localhost:51320/";
        }
    }
}
