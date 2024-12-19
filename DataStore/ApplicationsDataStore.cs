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
                    Id =  1,
                    Name = "Fake Man",
                    Email = "Londoner@fake.com",
                    Address = new AddressDto(){
                        Address_line1 = "2 Dummy Lane",
                        Address_line2 = "Fake Town",
                        City = "London",
                        Postcode = "FA12_6KE"
                    },
                    Vrn = "FA12_6KE"
                }
            };
        }
    }
}