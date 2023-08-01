using ptt_api.Entities;

namespace ptt_api
{
    public class DancersSeeder
    {
        private readonly DancersDbContext _dbContext;

        public DancersSeeder(DancersDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void Seed()
        {
            if (_dbContext.Database.CanConnect())
            {
                if(!_dbContext.DanceClubs.Any())
                {
                    var danceclubs = GetDanceClubs();
                    _dbContext.DanceClubs.AddRange(danceclubs);
                    _dbContext.SaveChanges();
                }
            }
            
        }

        private IEnumerable<DanceClub> GetDanceClubs()
        {
            var danceclubs = new List<DanceClub>()
            {
                new DanceClub()
                {
                    Name = "Wrocławskie wygibasy",
                    Owner = "Mrzysztof Kusioł",
                    Dancers = new List<Dancer>()
                    {
                        new Dancer()
                        {
                            Name ="Mionel Lessi",
                            Danceclass = "B",
                            NumberofPoints = 3,
                            DancePartnerName = "Barbie",
                            ContactEmail = "goracymeo@gmail.com",
                            ContactNumber="000000111",

                        },

                        new Dancer()
                        {
                            Name ="Barbie",
                            Danceclass = "S",
                            NumberofPoints = 0,
                            DancePartnerName = "Mionel Lessi",
                            ContactEmail = "fajnabarbie@gmail.com",
                            ContactNumber="000000113",

                        }

                    },
                    Address = new Address()
                    {
                        City="Wrocław",
                        PostalCode ="46-300",
                        Street="Wykolejeniowa",
                    }
                }
            };
            return danceclubs;
        }
    }
}
