namespace Software_Foundations_Learning_Programme_.Models
{
    public class ApplicationDto
    {
        public required int Id { get; set; }
        public required string Name { get; set; } = string.Empty;
        public required string Email { get; set; }
        public string Address_line1 { get; set; } = string.Empty;
        public string? Address_line2 { get; set; }
        public string City { get; set; } = string.Empty;
        public string Postcode { get; set; } = string.Empty;
        public required string Vrn { get; set; } = string.Empty;
    }
}