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
                if(!_dbContext.DanceEvents.Any())
                {
                    var danceevents = GetDanceEvents();
                    _dbContext.DanceEvents.AddRange(danceevents);
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

        private IEnumerable<DanceEvent> GetDanceEvents()
        {
            var danceEvents = new List<DanceEvent>()
            {
                new DanceEvent()
                {
                    Name="Tańce po hulajnodze",
                    Description = "Będziemy tańczyć i jezdzić na hulajnodze",
                    Organizer = "Czerwony Kapturek",
                    City = "Olesno",
                    EmailAdress = "kaptur@gmail.com",
                    Date = new DateTime(2012, 12, 25, 10, 30, 50),
                    DanceCompetitionCategories = new List<DanceCompetitionCategory>()
                    {
                        new DanceCompetitionCategory()
                        {
                            AgeRange = "14-15",
                            CategoryDanceClass = "B",
                            ListofPairs = new List<DancePair>()
                            {
                                new DancePair("Jaś Fasola","Zosia Kłosia","B",0,"Oborniki Wrocław")
                            }
                        }
                    }

                },
                new DanceEvent()
                {
                    Name="Tańce po hulajnodze",
                    Description = "Będziemy tańczyć i jezdzić na hulajnodze",
                    Organizer = "Czerwony Kapturek",
                    City = "Olesno",
                    EmailAdress = "kaptur@gmail.com",
                    Date = new DateTime(2012, 10, 15, 9, 30, 50),
                    DanceCompetitionCategories = new List<DanceCompetitionCategory>()
                    {
                        new DanceCompetitionCategory()
                        {
                            AgeRange = "14-15",
                            CategoryDanceClass = "B",
                            ListofPairs = new List<DancePair>()
                            {
                                new DancePair("Jaś Fasole","Zosia Kłosia","B",0,"Oborniki Wrocław")
                            }
                        }
                    }

                }
            };
            return danceEvents;
        }
    }
}
