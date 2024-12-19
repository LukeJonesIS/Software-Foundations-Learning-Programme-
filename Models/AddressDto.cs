namespace Software_Foundations_Learning_Programme_.Models
{
    public class AddressDto
    {
        public string Address_line1 { get; set; } = string.Empty;
        public string? Address_line2 { get; set; }
        public string City { get; set; } = string.Empty;
        public string Postcode { get; set; } = string.Empty;
    }
}