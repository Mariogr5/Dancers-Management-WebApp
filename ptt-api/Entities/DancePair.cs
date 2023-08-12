using System.Diagnostics.Contracts;

namespace ptt_api.Entities
{
    public class DancePair
    {
        public DancePair(string dancerName, string dancePartnerName, string pairDanceClass, int pairNumberofPoints, string dancePairClubName)
        {
            this.DancerName = dancerName;
            this.DancePartnerName = dancePartnerName;
            this.PairDanceClass = pairDanceClass;
            this.PairNumberofPoints = pairNumberofPoints;
            this.DancePairClubName = dancePairClubName;
        }
        public DancePair() { }
        public int Id { get; set; }
        public string DancerName { get; set; }
        public string DancePartnerName { get; set; }
        public string PairDanceClass { get; set; }
        public int PairNumberofPoints { get; set; }
        public string DancePairClubName { get; set; }
    }
}
