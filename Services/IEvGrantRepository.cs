using Software_Foundations_Learning_Programme_.Entities;

namespace Software_Foundations_Learning_Programme_.Services
{
    public interface IEvGrantRepository
    {
        Task<List<Address>?> GetAddresses(string postcode);
        Task<Vehicle?> GetVehicle(string vrn);
    }
}