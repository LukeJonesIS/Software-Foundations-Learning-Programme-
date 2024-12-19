namespace Software_Foundations_Learning_Programme_.Models
{
    public class ApplicationDto
    {
        public required int Id { get; set; }
        public required string Name { get; set; } = string.Empty;
        public string? Email { get; set; }
        public required AddressDto Address { get; set; }
        public required string Vrn { get; set; } = string.Empty;
    }
}