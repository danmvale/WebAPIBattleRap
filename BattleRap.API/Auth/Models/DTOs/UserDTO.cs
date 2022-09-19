namespace BattleRap.API.Auth.Models.DTOs
{
    public class UserDTO
    {
        public string Name { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string Role { get; set; }

        public User ToUser()
        {
            return new User
            {
                Name = Name,
                Username = Username,
                Password = Password,
                Role = Role,
            };
        }
    }
}
