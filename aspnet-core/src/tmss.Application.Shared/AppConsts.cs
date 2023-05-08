using System;

namespace tmss
{
    /// <summary>
    /// Some consts used in the application.
    /// </summary>
    public class AppConsts
    {
        /// <summary>
        /// Default page size for paged requests.
        /// </summary>
        public const int DefaultPageSize = 10;

        /// <summary>
        /// Maximum allowed page size for paged requests.
        /// </summary>
        public const int MaxPageSize = 1000;

        /// <summary>
        /// Default pass phrase for SimpleStringCipher decrypt/encrypt operations
        /// </summary>
        public const string DefaultPassPhrase = "gsKxGZ012HLL3MI5";

        public const int ResizedMaxProfilPictureBytesUserFriendlyValue = 1024;

        public const int MaxProfilPictureBytesUserFriendlyValue = 5;

        public const string TokenValidityKey = "token_validity_key";
        public const string SecurityStampKey = "AspNet.Identity.SecurityStamp";

        public const string TokenType = "token_type";

        public static string UserIdentifier = "user_identifier";

        public const string ThemeDefault = "default";
        public const string Theme2 = "theme2";
        public const string Theme3 = "theme3";
        public const string Theme4 = "theme4";
        public const string Theme5 = "theme5";
        public const string Theme6 = "theme6";
        public const string Theme7 = "theme7";
        public const string Theme8 = "theme8";
        public const string Theme9 = "theme9";
        public const string Theme10 = "theme10";
        public const string Theme11 = "theme11";
        public const string Theme12 = "theme12";

        //public static TimeSpan AccessTokenExpiration = TimeSpan.FromDays(365);
        public static TimeSpan AccessTokenExpiration = TimeSpan.Parse("10:30:05");
        public static TimeSpan RefreshTokenExpiration = TimeSpan.Parse("10:32:30");
        // public static TimeSpan AccessTokenExpiration = TimeSpan.FromDays(1);
        // public static TimeSpan RefreshTokenExpiration = TimeSpan.FromDays(365);

        public const string DateTimeOffsetFormat = "yyyy-MM-ddTHH:mm:sszzz";

        // Notification Code
        // Chuyen giao khach hang
        public const string CustomerNotificationSalesPerson = "CNSP";
        public const string CustomerNotificationSalesManager = "CNSM";
        // Phe duyet proposal
        public const string ProposalNotificationSalesPerson = "PNSP";
        public const string ProposalNotificationSalesManager = "PNSM";
        //Phe duyet todolist : Test Drive
        public const string TodoListNotificationSalesPerson = "TDNSP";
        public const string TodoListNotificationSalesManager = "TDNSM";
        // Phe duyet Contract
        public const string ContractNotificationSalesPerson = "CNSP";
        public const string ContractNotificationSalesManager = "CNSM";
        // Nhac lich hen truoc 15 phut
        public const string DailyActivityNotification = "DAN";
        public const string TestDriveDailyActivityNotification = "TDAN";
        public const string DeliveryDailyActivityNotification = "DDAN";
        // Khi co KH duoc chuyen giaoj
        public const string CustomerNotification = "CN";
        // Binh luan lich su lien he
        public const string CommentContactHistory = "CM";
        // Khi yeu cau ho tro:  seek for
        public const string SeekForManagerNotificationSalesPerson = "SMNSP";
        public const string SeekForManagerNotificationSalesManager = "SMNSM";
        // Khi yeu cau ho tro:  seek for transaction
        public const string SeekForManagerTransNotificationSalesPerson = "STMNSP";
        public const string SeekForManagerTransNotificationSalesManager = "STMNSM";
        public const string CustomerSellOldUsedCar = "CSOUC";
        // Remind change Hotness
        public const string RemindChangeHotness = "RCH";
        public const string UriWAC = "http://14.225.19.102:9669";
        public const string UriAI = "https://ai-toyota-api.stg.vti.com.vn";

    }
}
