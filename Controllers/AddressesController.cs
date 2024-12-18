using Microsoft.AspNetCore.Mvc;
using Software_Foundations_Learning_Programme_.DataStore;

namespace Software_Foundations_Learning_Programme_.Controllers
{
    [ApiController]
    [Route("api/addresses")]
    public class AddressesController : ControllerBase
    {
        [HttpGet("{postcode}")]
        public JsonResult GetAddresses(string postcode)
        {
            return new JsonResult(
                AddressesDataStore.Current.Addresses.FirstOrDefault(a => a.postcode == postcode));
        }
    }
}