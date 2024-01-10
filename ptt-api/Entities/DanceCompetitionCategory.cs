namespace ptt_api.Entities
{
    public class DanceCompetitionCategory
    {
        public int Id { get; set; }
        public string AgeRange { get; set; }
        public string CategoryDanceClass { get; set; }
        public List<DancePair> ListofPairs { get; set; }
        //public virtual DanceEvent DanceEvent { get; set; }
        public int DanceEventId { get; set; }
    }
}
