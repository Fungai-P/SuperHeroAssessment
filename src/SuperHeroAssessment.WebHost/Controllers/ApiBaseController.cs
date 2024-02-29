using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace SuperHeroAssessment.WebHost.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ApiBaseController : ControllerBase
    {
        private ISender _sender;

        protected ISender Sender => _sender ??= HttpContext.RequestServices.GetService<ISender>();
    }
}
