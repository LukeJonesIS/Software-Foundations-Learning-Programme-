namespace Software_Foundations_Learning_Programme_.Models
{
    public class ApplicationDto
    {
        public required int Id { get; set; }
        public required string Name { get; set; } = string.Empty;
        public required string Email { get; set; }
        public string Address { get; set; } = string.Empty;
        public required string Vrn { get; set; } = string.Empty;
    }
}