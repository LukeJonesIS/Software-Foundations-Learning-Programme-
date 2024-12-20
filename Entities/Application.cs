using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Software_Foundations_Learning_Programme_.Entities
{
    public class Application
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        [MaxLength(50)]
        public required string Name { get; set; }

        [Required]
        [MaxLength(50)]
        public required string Email { get; set; }

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

        [Required]
        [MaxLength(10)]
        public required string Vrn { get; set; }
        
        public Application(string vrn, string name , string email)
        {
            Name = name;
            Email = email;
            Vrn = vrn;
        }

        public Application()
        {
        }
    }
}