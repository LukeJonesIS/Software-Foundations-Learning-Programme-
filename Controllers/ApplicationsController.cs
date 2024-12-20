using Microsoft.AspNetCore.Mvc;
using Software_Foundations_Learning_Programme_.DataStore;
using Software_Foundations_Learning_Programme_.Models;
using Software_Foundations_Learning_Programme_.Services;
using Software_Foundations_Learning_Programme_.Entities;


namespace Software_Foundations_Learning_Programme_.Controllers
{
    [ApiController]
    [Route("api/Applications")]
    public class ApplicationsController : ControllerBase
    {
         private readonly IEvGrantRepository _evGrantRepository;
        public ApplicationsController(IEvGrantRepository evGrantRepository){
            _evGrantRepository = evGrantRepository ??
             throw new ArgumentNullException(nameof(evGrantRepository));
        }
        
        [HttpPost("Create")] 
        public async Task<ActionResult<Application>> CreateApplication(ApplicationCreationDto application)
        {
           var maxApplicationId = ApplicationsDataStore.Current.Applications.Max(p => p.Id);

           var finalApplication = new Application()
           {
            Name = application.Name,
            Email = application.Email,
            Address_line1 = application.Address_line1,
            Address_line2 = application.Address_line2,
            Postcode = application.Postcode,
            City = application.City,
            Vrn = application.Vrn
           };
           await _evGrantRepository.AddApplication(finalApplication);
           await _evGrantRepository.SaveChangesAsync();
           return CreatedAtAction(nameof(CreateApplication), new { id = finalApplication.Id }, finalApplication);
        }
    }
        
}