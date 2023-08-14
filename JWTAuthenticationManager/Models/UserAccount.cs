namespace JWTAuthenticationManager.Models
{
    public class UserAccount
    {
        public int Id { get; set; } = default;
        public string Name { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
        public int RoleId { get; set; }
        public UserRole Role { get; set; } = null!;
    }
}