using Microsoft.AspNetCore.Mvc;
using VueApp.Server.Repository.Interfaces;

namespace VueApp.Server.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PersonController : ControllerBase
    {
        private readonly ILogger<PersonController> _logger;
        private readonly IPersonRepository _personRepository;

        public PersonController(ILogger<PersonController> logger, IPersonRepository personRepository)
        {
            _logger = logger;
            _personRepository = personRepository;
        }

        [HttpGet(Name = "GetPersons")]
        public async Task<IActionResult> GetPersons(int pageNumber = 0, int pageSize = 10)
        {
            try
            {
                return Ok(await _personRepository.GetAllAsync(pageNumber, pageSize));
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
                return BadRequest(ex.Message);
            }
        }
    }
}
