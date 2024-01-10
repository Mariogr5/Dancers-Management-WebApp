namespace ptt_api.Entities
{
    public class Dancer
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Danceclass { get; set; }
        public int NumberofPoints { get; set; }
        public string ContactNumber { get; set; }
        public string ContactEmail { get; set; }
        public int? DancePartnerId { get; set; }
        public string DancePartnerName { get; set; }
        public int DanceClubId { get; set; }
        public virtual DanceClub DancerClub{get;set;}
    }
}
