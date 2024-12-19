namespace Software_Foundations_Learning_Programme_.Models
{
    public class ApplicationDto
    {
        public required int id { get; set; }
        public required string name { get; set; } = string.Empty;
        public string? email { get; set; }
        public required AddressDto address { get; set; }
        public required string vrn { get; set; } = string.Empty;
    }
}