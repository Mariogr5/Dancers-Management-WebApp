namespace ptt_api.Entities
{
    public class DanceClub
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Owner { get; set; }
        public virtual List<Dancer> Dancers { get; set; }
        public int AddressId { get; set; }
        public virtual Address Address { get; set; }
    }
}
