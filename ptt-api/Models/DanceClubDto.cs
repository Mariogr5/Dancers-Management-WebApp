namespace ptt_api.Models
{
    public class DanceClubDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Owner { get; set; }
        public string City { get; set; }
        public string Street { get; set; }
        public string PostalCode { get; set; }
        public List<DancerDto> Dancers { get; set; }
    }
}
