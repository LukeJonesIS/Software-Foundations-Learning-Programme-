using Microsoft.AspNetCore.Mvc;
using Software_Foundations_Learning_Programme_.DataStore;
using Software_Foundations_Learning_Programme_.Models;

namespace Software_Foundations_Learning_Programme_.Controllers
{
    [ApiController]
    [Route("api/addresses")]
    public class AddressesController : ControllerBase
    {
        [HttpGet("{postcode}")] 
        public ActionResult<AddressDto> GetAddresses(string postcode)
        {
            var addressToReturn = AddressesDataStore.Current.Addresses
                .FirstOrDefault(a => a.postcode == postcode);

            if (addressToReturn == null){
                return NotFound();
            }
            return Ok(addressToReturn);
        }
    }
}