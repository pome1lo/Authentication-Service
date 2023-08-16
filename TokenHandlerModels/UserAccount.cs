using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace JWTAuthenticationManager
{
    [Table("USER_ACCOUNTS", Schema = "dbo")]
    public class UserAccount
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("USER_ACCOUNT_ID")]
        public int Id { get; set; } = default;

        [Column("USER_ACCOUNT_EMAIL")]
        public string Name { get; set; } = string.Empty;

        //[Column("USER_ACCOUNT_PASSWORD")]
        //public string Password { get; set; } = string.Empty;

        [Column("USER_ACCOUNT_SALT")]
        public string Salt { get; set; } = string.Empty;

        [Column("USER_ACCOUNT_HASH")]
        public string Hash { get; set; } = string.Empty;

        [Column("USER_ROLE_ID")]
        public int RoleId { get; set; }

        [Column("USER_ROLE")]
        public UserRole Role { get; set; } = null!;
    }
}