using Microsoft.EntityFrameworkCore;
using Software_Foundations_Learning_Programme_.DbContexts;
using Software_Foundations_Learning_Programme_.Entities;
using Software_Foundations_Learning_Programme_.Models;
using SQLitePCL;

namespace Software_Foundations_Learning_Programme_.Services
{
    public class EvGrantRepository : IEvGrantRepository
    {
        private readonly EvGrantApplicationContext _context;

        public EvGrantRepository(EvGrantApplicationContext context){
            _context = context ?? throw new NotImplementedException(nameof(context));
        }

        public async Task<List<Application>> AddApplication(Application application)
        {
            _context.Applications.Add(application);
            return await _context.Applications.ToListAsync();
        }

        public async Task<EligibleAddress?> CheckAddress(string postcode)
        {
            return await _context.EligibleAddress.Where(a => a.Postcode == postcode).FirstOrDefaultAsync();
        }

        public async Task<EligibleFuel?> CheckVehicle(string fuel_type)
        {
            return await _context.EligibleFuel.Where(a => a.Fuel_type == fuel_type).FirstOrDefaultAsync();
        }

        public async Task<List<Address>?> GetAddresses(string postcode)
        {
            return await _context.Addresses.Where(a => a.Postcode == postcode)
                .OrderBy(a => a.Address_line1).ToListAsync();
        }

        public async Task<Vehicle?> GetVehicle(string vrn)
        {
            return await _context.Vehicles.Where(v => v.Vrn == vrn).FirstOrDefaultAsync();
        }

        public async Task<bool> SaveChangesAsync()
        {
            return (await _context.SaveChangesAsync() >=0);
        }
    }
}