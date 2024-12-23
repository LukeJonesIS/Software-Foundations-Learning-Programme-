using System.ComponentModel.DataAnnotations;

namespace Software_Foundations_Learning_Programme_.Entities
{
    public class Vehicle
    {
        [Key]
        [Required]
        public required string Vrn { get; set; }

        [MaxLength(20)]
        public string? Make { get; set; }

        [MaxLength(20)]
        public string? Model { get; set; }
        public int? Year_made { get; set; }

        [Required]
        [MaxLength(20)]
        public string Fuel_type { get; set; } = string.Empty;
    }
}