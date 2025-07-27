using Microsoft.EntityFrameworkCore;
using NZWalks.API.Models.Dmain;

namespace NZWalks.API.Data
{
    public class NZWalksDbContext:DbContext
    {

        public NZWalksDbContext(DbContextOptions<NZWalksDbContext> dbContextOptions) : base(dbContextOptions)
        {
                
        }

        public DbSet<Difficulty> Difficulties { get; set; }

        public DbSet<Region> Regions { get; set; }

        public DbSet<Walks> Walks { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Seed data for difficulties
            // Easy,Medium, Hard

            var difficulties = new List<Difficulty>()
            {
                new Difficulty()
                {
                    Id=Guid.Parse("501dfbd8-4c64-4eaa-a961-94b5ee5751c0"),
                    Name="Easy"
                },
                 new Difficulty()
                {
                    Id=Guid.Parse("8c91828d-5c9c-41b1-9a36-43ee0f7a3210"),
                    Name="Medium"
                },
                  new Difficulty()
                {
                    Id=Guid.Parse("6abaea43-513d-414a-87ab-2d5879ba5d34"),
                    Name="Hard"
                }
            };

            // Seed difficilties to the database
            modelBuilder.Entity<Difficulty>().HasData(difficulties);

            // Seed data for  Regions

            var regions = new List<Region>()
{
                new Region()
                {
                    Id = Guid.Parse("1a88e888-44e8-414d-897b-a13c120a0bec"),
                    Name = "Auckland",
                    Code = "AKL",
                    RegionImageUrl = "AucklandImageUrl"
                },
                new Region()
                {
                    Id = Guid.Parse("8d1ae977-4cf6-4477-a43a-bf3f49c50b51"),
                    Name = "Wellington",
                    Code = "WLG",
                    RegionImageUrl = "WellingtonImageUrl"
                },
                new Region()
                {
                    Id = Guid.Parse("d027a0d8-cfa9-4359-95b6-dba4c9be34d1"),
                    Name = "Christchurch",
                    Code = "CHC",
                    RegionImageUrl = "ChristchurchImageUrl"
                },
                new Region()
                {
                    Id = Guid.Parse("7579d713-bf23-4af1-9198-e1924d4f9aea"),
                    Name = "Hamilton",
                    Code = "HLZ",
                    RegionImageUrl = "HamiltonImageUrl"
                },
                new Region()
                {
                    Id = Guid.Parse("13c0cc3e-b9d6-4788-89a2-91a16d456c73"),
                    Name = "Tauranga",
                    Code = "TRG",
                    RegionImageUrl = "TaurangaImageUrl"
                },
                new Region()
                {
                    Id = Guid.Parse("ba4082ec-4094-40b7-acdc-db15ea6607e9"),
                    Name = "Dunedin",
                    Code = "DUD",
                    RegionImageUrl = "DunedinImageUrl"
                }
            };

            modelBuilder.Entity<Region>().HasData(regions);

        }


    }
}
