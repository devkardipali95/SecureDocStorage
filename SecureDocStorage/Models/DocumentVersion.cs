using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace SecureDocStorage.Models
{
    public class DocumentVersion
    {
        public int Id { get; set; }

        [Required]
        public int DocumentId { get; set; }

        [ForeignKey("DocumentId")]
        [JsonIgnore]
        public Document Document { get; set; }

        [Required]
        public int RevisionNumber { get; set; }

        [Required]
        [JsonIgnore]
        public byte[] FileContent { get; set; } = Array.Empty<byte>();

        [Required]
        public DateTime UploadedAt { get; set; } = DateTime.UtcNow;
    }   
}
