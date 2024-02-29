using Microsoft.AspNetCore.Mvc;
using SuperHeroAssessment.Api.Contracts.Requests;
using SuperHeroAssessment.Api.Contracts.Responses.Mappers;

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

        [HttpPost]
        public async Task<IActionResult> Create(CreateSuperHeroRequest request)
        {
            try
            {
                var response = await Sender.Send(request);
                if (response == null)
                {
                    return NotFound();
                }

                response.Response = "Success";
                return Ok(response);
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        [HttpPut]
        public async Task<IActionResult> Update(string id, UpdateSuperHeroRequest request)
        {
            try
            {
                if (id != request.Id)
                {
                    return BadRequest();
                }

                var response = await Sender.Send(request);
                if (response == null)
                {
                    return NotFound();
                }

                response.Response = "Success";
                return Ok(response);
            }
            catch (Exception ex)
            {
                throw;
            }
        }

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
                response.Response = "Success";
                return Ok(response);
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        [HttpGet("{id}/{sub}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Get(string id, string sub)
        {
            try
            {
                var response = await Sender.Send(new GetOneSuperHeroRequest(id));
                if (response == null)
                {
                    return NotFound();
                }

                switch (sub.ToLower())
                {
                    case "powerstats":
                        if (response.PowerStats == null)
                        {
                            return NotFound();
                        }
                        return Ok(response.Map(response.PowerStats));
                    case "biography":
                        if (response.Biography == null)
                        {
                            return NotFound();
                        }
                        return Ok(response.Map(response.Biography));
                    case "appearance":
                        if (response.Appearance == null)
                        {
                            return NotFound();
                        }
                        return Ok(response.Map(response.Appearance));
                    case "work":
                        if (response.Work == null)
                        {
                            return NotFound();
                        }
                        return Ok(response.Map(response.Work));
                    case "connections":
                        if (response.Connections == null)
                        {
                            return NotFound();
                        }
                        return Ok(response.Map(response.Connections));
                    case "image":
                        if (response.Image == null)
                        {
                            return NotFound();
                        }
                        return Ok(response.Map(response.Image));
                    default:
                        return NotFound();
                }
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        [HttpGet()]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetList()
        {
            try
            {
                var response = await Sender.Send(new GetListSuperHeroRequest());
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
    }
}