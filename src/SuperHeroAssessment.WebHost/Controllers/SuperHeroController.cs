using Microsoft.AspNetCore.Mvc;
using SuperHeroAssessment.Api.Contracts.Requests;
using SuperHeroAssessment.Application.Handlers;

namespace SuperHeroAssessment.WebHost.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class SuperHeroController : ApiBaseController
    {
        private readonly ILogger<SuperHeroController> _logger;

        public SuperHeroController(ILogger<SuperHeroController> logger)
        {
            _logger = logger;
        }

        /// <summary>
        /// Retrives information on a Super Hero by Id 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Get(string id)
        {
            try
            {
                var response = await Sender.Send(new GetOneSuperHeroRequest(id));
                if (response == null)
                {
                    return NotFound();
                }
                return Ok(response);
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        /// <summary>
        /// Searched for Super Heros by name and returns a list of results.
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        [HttpGet("search/{name}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Search(string name)
        {
            try
            {
                var response = await Sender.Send(new GetSearchSuperHeroRequest(name));
                if (response == null)
                {
                    return NotFound();
                }
                return Ok(response);
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        /// <summary>
        /// Store your favorite super hero into the local database
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPost()]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> StoreFavoriteSuperHero(StoreSuperHeroRequest request)
        {
            try
            {
                var response = await Sender.Send(request);
                if (string.IsNullOrEmpty(response))
                {
                    return NotFound();
                }
                return Ok(response);
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}