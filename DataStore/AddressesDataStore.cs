using Microsoft.AspNetCore.SignalR;
using Software_Foundations_Learning_Programme_.Models;

namespace Software_Foundations_Learning_Programme_.DataStore
{
    public class AddressesDataStore
    {
        public List<AddressDto> Addresses {get; set;}
        public static AddressesDataStore Current { get;} = new AddressesDataStore();

        public AddressesDataStore()
        {
            Addresses = new List<AddressDto>()
            {
                new AddressDto()
                {
                    Id = 1,
                    address_line1 = "2 Dummy Lane",
                    address_line2 = "Fake Town",
                    city = "London",
                    postcode = "FA12_6KE"
                },

                new AddressDto()
                {
                    Id = 2,
                    address_line1 = "3 Fake Street",
                    address_line2 = "Dummy Town",
                    city = "Manchester",
                    postcode = "NO7_4RL"
                }
            };
        }
    }
}