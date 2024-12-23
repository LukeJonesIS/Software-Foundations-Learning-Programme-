using Software_Foundations_Learning_Programme_.Entities;
using Microsoft.EntityFrameworkCore;
using Software_Foundations_Learning_Programme_.Controllers;

namespace Software_Foundations_Learning_Programme_.DbContexts
{
    public class EvGrantApplicationContext(DbContextOptions<EvGrantApplicationContext> options) : DbContext(options)
    {
        public DbSet<Application> Applications {get; set;}
        public DbSet<Vehicle> Vehicles {get; set;}
        public DbSet<Address> Addresses {get; set;}
        public DbSet<EligibleAddress> EligibleAddress { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Address>()
                .HasData(
                new Address()
                {
                    Id = 1,
                    Address_line1 = "2 Dummy Lane",
                    Address_line2 = "Fake Town",
                    City = "London",
                    Postcode = "FA12_6KE"
                },

                new Address()
                {
                    Id = 2,
                    Address_line1 = "4 Dummy Lane",
                    Address_line2 = "Fake Town",
                    City = "London",
                    Postcode = "FA12_6KE"
                },

                new Address()
                {
                    Id = 3,
                    Address_line1 = "3 Fake Street",
                    Address_line2 = "Dummy Town",
                    City = "Manchester",
                    Postcode = "NO7_4RL"
                }
                );
            modelBuilder.Entity<Vehicle>()
                .HasData(
                    new Vehicle()
                {
                    Vrn = "EVS400",
                    Make = "Tesla",
                    Model = "Series S",
                    Year_made = 2018,
                    Fuel_type = "electric"
                },

                new Vehicle()
                {
                    Vrn = "CAS300",
                    Make = "Volkswagon",
                    Model = "Fox",
                    Year_made = 2008,
                    Fuel_type = "petrol"
                }
                );
            modelBuilder.Entity<EligibleAddress>()
                .HasData(
                    new EligibleAddress()
                {
                    Postcode = "NO7_4RL"
                }
                );
            base.OnModelCreating(modelBuilder);

        }
    }
}