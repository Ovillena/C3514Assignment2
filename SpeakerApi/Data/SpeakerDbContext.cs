using System;
using Microsoft.EntityFrameworkCore;
using SpeakerLibrary;

namespace SpeakerApi.Data
{
    
        public class SpeakerDbContext : DbContext
        {
            public DbSet<Speaker> Speakers { get; set; }

            public SpeakerDbContext(DbContextOptions<SpeakerDbContext> options) : base(options) { }

            protected override void OnModelCreating(ModelBuilder builder)
            {
                base.OnModelCreating(builder);

                builder.Entity<Speaker>().HasData(
                  new
                  {
                      SpeakerId = Guid.NewGuid().ToString(),
                      FirstName = "Tom",
                      LastName = "Day",
                      Email = "tday@amazon.com",
                      MobileNumber="604-111-1111",
                      Specialization="AWS",
                      City="Vancouver",
                      Province="BC",
                      Employer="Amazon"
                  }, new
                  {
                      SpeakerId = Guid.NewGuid().ToString(),
                      FirstName = "Ann",
                      LastName = "Fox",
                      Email = "afox@microsoft.com",
                      MobileNumber = "604-222-2222",
                      Specialization = "Dotnet",
                      City = "Calgary",
                      Province = "AB",
                      Employer = "Microsoft"
                  }, new
                  {
                      SpeakerId = Guid.NewGuid().ToString(),
                      FirstName = "Art",
                      LastName = "Ash",
                      Email = "aash@meta.com",
                      MobileNumber = "604-333-3333",
                      Specialization = "Oculus",
                      City = "Toronto",
                      Province = "ON",
                      Employer = "Meta"
                  }, new
                  {
                      SpeakerId = Guid.NewGuid().ToString(),
                      FirstName = "Mia",
                      LastName = "Hay",
                      Email = "mhay@yahoo.com",
                      MobileNumber = "604-444-4444",
                      Specialization = "Yahoo Search",
                      City = "Montreal",
                      Province = "QB",
                      Employer = "Yahoo"
                  }
                );
            }
        }

    
}
