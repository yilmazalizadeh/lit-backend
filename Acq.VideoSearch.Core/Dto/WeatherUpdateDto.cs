namespace Acq.VideoSearch.Core.Dto
{
    public class WeatherUpdateDto
    {
        public string UniqId { get; set; } = null!;
        public string? Summary { get; set; }
        public float TempC { get; set; }
        public DateTime Date { get; set; }
    }
}
