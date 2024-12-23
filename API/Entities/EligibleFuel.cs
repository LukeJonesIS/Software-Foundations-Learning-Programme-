using System.ComponentModel.DataAnnotations;

namespace Software_Foundations_Learning_Programme_.Entities
{
    public class EligibleFuel
    {
        [Key]
        [MaxLength(30)]
        public string Fuel_type { get; set; } = string.Empty;
    }
}