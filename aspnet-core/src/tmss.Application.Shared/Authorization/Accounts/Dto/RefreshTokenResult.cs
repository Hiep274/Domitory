namespace tmss.Authorization.Accounts.Dto
{
    public class RefreshTokenResult
    {
        public string AccessToken { get; set; }

        public string EncryptedAccessToken { get; set; }

        public int ExpireInSeconds { get; set; }
        public string RefreshTokken { get; set; }
        public int RefreshTokenExpiration { get; set; }

        public RefreshTokenResult(string accessToken, string encryptedAccessToken, int expireInSeconds, string refreshToken, int refreshTokenExpiration)
        {
            AccessToken = accessToken;
            ExpireInSeconds = expireInSeconds;
            EncryptedAccessToken = encryptedAccessToken;
            RefreshTokenExpiration = refreshTokenExpiration;
            RefreshTokken = refreshToken;
        }

        public RefreshTokenResult()
        {

        }
    }
}