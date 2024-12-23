using System.ComponentModel.DataAnnotations;

namespace Software_Foundations_Learning_Programme_.Entities
{
    public class EligibleAddress
    {
        [Key]
        [MaxLength(20)]
        public string Postcode { get; set; } = string.Empty;
    }
}