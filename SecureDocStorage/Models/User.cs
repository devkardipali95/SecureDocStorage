using System.ComponentModel.DataAnnotations;
using System.Reflection.Metadata;

namespace SecureDocStorage.Models
{
    public class User
    {
        public int Id { get; set; }

        [Required, MaxLength(50)]
        public string Username { get; set; } = string.Empty;

        [Required]
        public byte[] PasswordHash { get; set; }

        [Required]
        public byte[] PasswordSalt { get; set; }

        public ICollection<Document> Documents { get; set; } = new List<Document>();
    }
}
