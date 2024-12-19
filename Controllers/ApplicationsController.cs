using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Software_Foundations_Learning_Programme_.DataStore;
using Software_Foundations_Learning_Programme_.Models;

namespace Software_Foundations_Learning_Programme_.Controllers
{
    [ApiController]
    [Route("api/Applications")]
    public class ApplicationsController : ControllerBase
    {
        [HttpPost("Create")] 
        public ActionResult<ApplicationDto> CreateApplication(ApplicationCreationDto application)
        {
           var maxApplicationId = ApplicationsDataStore.Current.Applications.Max(p => p.id);

           var finalApplication = new ApplicationDto()
           {
            id = ++maxApplicationId,
            name = application.name,
            email = application.email,
            address = application.address,
            vrn = application.vrn
           };
           
           return CreatedAtAction(nameof(CreateApplication), new { id = finalApplication.id }, finalApplication);
        }
    }
        
}