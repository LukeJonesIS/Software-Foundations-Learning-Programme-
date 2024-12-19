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
        
    }
}