using System.Diagnostics.Contracts;

namespace ptt_api.Entities
{
    public class DancePair
    {
        public DancePair(string dancerName, string dancePartnerName, string pairDanceClass, int PairNumberofPoints, string DancePairClubName)
        {
            this.DancerName = dancerName;
            this.DancePartnerName = dancePartnerName;
            this.PairDanceClass = pairDanceClass;
            this.PairNumberofPoints = PairNumberofPoints;
            this.DancePairClubName = DancePairClubName;
        }
        public int Id { get; set; }
        public string DancerName { get; set; }
        public string DancePartnerName { get; set; }
        public string PairDanceClass { get; set; }
        public int PairNumberofPoints { get; set; }
        public string DancePairClubName { get; set; }
    }
}
