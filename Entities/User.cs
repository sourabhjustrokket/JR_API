using System.ComponentModel.DataAnnotations.Schema;

namespace JR_API.Entities
{
    public class User
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public string Email { get; set; }
        public byte[] PasswordHash { get; set; }
        public byte[] PasswordSalt { get; set; }
        [Column(TypeName = "varchar(1)")]
        public string UserType { get; set; }
    }
}