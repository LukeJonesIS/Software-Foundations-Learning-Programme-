using Microsoft.AspNetCore.SignalR;
using Software_Foundations_Learning_Programme_.Models;

namespace Software_Foundations_Learning_Programme_.DataStore
{
    public class ApplicationsDataStore
    {
        public List<ApplicationDto> Applications {get; set;}
        public static ApplicationsDataStore Current { get;} = new ApplicationsDataStore();

        public ApplicationsDataStore()
        {
            Applications = new List<ApplicationDto>()
            {
                new ApplicationDto()
                {
                    id =  1,
                    name = "Fake Man",
                    email = "Londoner@fake.com",
                    address = new AddressDto(){
                        address_line1 = "2 Dummy Lane",
                        address_line2 = "Fake Town",
                        city = "London",
                        postcode = "FA12_6KE"
                    },
                    vrn = "FA12_6KE"
                }
            };
        }
    }
}