namespace Software_Foundations_Learning_Programme_.Models
{
    public class AddressDto
    {
        public string address_line1 { get; set; } = string.Empty;
        public string? address_line2 { get; set; }
        public string city { get; set; } = string.Empty;
        public string postcode { get; set; } = string.Empty;
    }
}