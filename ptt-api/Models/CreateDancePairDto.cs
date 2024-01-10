using System.ComponentModel.DataAnnotations;

namespace ptt_api.Models
{
    public class CreateDancePairDto
    {
        [Required]
        public string PairDanceClass { get; set; }
        public int PairNumberofPoints { get; set; }
    }
}
