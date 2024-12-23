namespace Software_Foundations_Learning_Programme_.Models
{
    public class VehicleDto
    {
        public string Vrn { get; set; } = string.Empty;
        public string? Make { get; set; }
        public string? Model { get; set; }
        public int? Year_made { get; set; }
        public string Fuel_type { get; set; } = string.Empty;
    }
}