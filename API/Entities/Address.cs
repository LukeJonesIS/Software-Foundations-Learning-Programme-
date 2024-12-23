using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Software_Foundations_Learning_Programme_.Entities
{
    public class Address
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        [MaxLength(50)]
        public string Address_line1 { get; set; } = string.Empty;
        [MaxLength(50)]
        public string? Address_line2 { get; set; }
        [Required]
        [MaxLength(20)]
        public string City { get; set; } = string.Empty;
        [Required]
        [MaxLength(20)]
        public string Postcode { get; set; } = string.Empty;
    }
}