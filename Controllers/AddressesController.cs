using Microsoft.AspNetCore.Mvc;

namespace Software_Foundations_Learning_Programme_.Controllers
{
    [ApiController]
    [Route("api/addresses")]
    public class AddressesController : ControllerBase
    {
        [HttpGet]
        public JsonResult GetAddresses()
        {
            return new JsonResult(
                new List<object> {
                    new {id = 1, Name = "address1"},
                    new {id = 2, Name = "address2"},
                });
        }
    }
}