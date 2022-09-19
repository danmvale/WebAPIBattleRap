namespace BattleRap.API.Auth
{
    public class TokenConfiguration
    {
        public string Secret { get; set; }
        public string Audience { get; set; }
        public string Issuer { get; set; }
        public int ExpirationTimeInHours { get; set; }
        public string Username { get; set; }
        public string Role { get; set; }
    }
}
