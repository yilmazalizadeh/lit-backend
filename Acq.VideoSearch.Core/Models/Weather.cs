using System.ComponentModel.DataAnnotations;

namespace Acq.VideoSearch.Core.Models
{
    public class Weather
    {
        [Key] public string UniqId { get; set; } = Guid.NewGuid().ToString();
        public string? Summary { get; set; }
        [Required] public float TempC { get; set; }
        [Required] public DateTime Date { get; set; }
    }
}
