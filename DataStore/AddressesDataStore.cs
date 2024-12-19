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
                    Address_line1 = "2 Dummy Lane",
                    Address_line2 = "Fake Town",
                    City = "London",
                    Postcode = "FA12_6KE"
                },

                new AddressDto()
                {
                    Address_line1 = "4 Dummy Lane",
                    Address_line2 = "Fake Town",
                    City = "London",
                    Postcode = "FA12_6KE"
                },

                new AddressDto()
                {
                    Address_line1 = "3 Fake Street",
                    Address_line2 = "Dummy Town",
                    City = "Manchester",
                    Postcode = "NO7_4RL"
                }
            };
        }
    }
}