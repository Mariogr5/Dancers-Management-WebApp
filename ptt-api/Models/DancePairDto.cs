namespace ptt_api.Models
{
    public class DancePairDto
    {
        public int Id { get; set; }
        public string DancerName { get; set; }
        public int DancerId { get; set; }
        public string DancePartnerName { get; set; }
        public int DancePartnerId { get; set; }
        public string DancePairClubName { get; set; }
    }
}
