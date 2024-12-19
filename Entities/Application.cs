using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Software_Foundations_Learning_Programme_.Entities
{
    public class Application
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public required int Id { get; set; }

        [Required]
        [MaxLength(50)]
        public required string Name { get; set; }

        [Required]
        [MaxLength(50)]
        public required string Email { get; set; }

        [ForeignKey("AddressId")]
        public required Address Address { get; set; }

        [Required]
        [MaxLength(10)]
        public required string Vrn { get; set; }
        
        public Application(string vrn, string name , string email)
        {
            Name = name;
            Email = email;
            Vrn = vrn;
        }
    }
}