namespace Software_Foundations_Learning_Programme_.Models
{
    public class VehicleDto
    {
        public string vrn { get; set; } = string.Empty;
        public string? make { get; set; }
        public string? model { get; set; }
        public int? year_made { get; set; }
        public string fuel_type { get; set; } = string.Empty;
    }
}