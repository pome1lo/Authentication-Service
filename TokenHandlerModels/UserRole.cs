using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace JWTAuthenticationManager
{
    [Table("USER_ROLES", Schema = "dbo")]
    public class UserRole
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("ROLE_ID")]
        public int Id { get; set; }

        [Column("ROLE_NAME")]
        public string RoleName { get; set; } = string.Empty;
    }
}