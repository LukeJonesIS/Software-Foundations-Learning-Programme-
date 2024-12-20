using Microsoft.EntityFrameworkCore;
using Software_Foundations_Learning_Programme_.DbContexts;
using Software_Foundations_Learning_Programme_.Entities;
using SQLitePCL;

namespace Software_Foundations_Learning_Programme_.Services
{
    public class EvGrantRepository : IEvGrantRepository
    {
        private readonly EvGrantApplicationContext _context;

        public EvGrantRepository(EvGrantApplicationContext context){
            _context = context ?? throw new NotImplementedException(nameof(context));
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
    }
}